using QnSProjectAward.Adapters.Modules.Account;
using QnSProjectAward.Contracts.Persistence.App;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace QnSProjectAward.ConApp
{
    partial class Program
    {
        static readonly string PAPath = @"C:\Users\Gerhard\OneDrive - HTBLA Leonding\PA2021";
        static readonly string JuryFolder = "Jury";
        static readonly string ProgramFolder = "Programm";

        static async partial void EndExecuteMain()
        {
            var jury = new List<IJuror>();
            var projects = new List<IProject>();
            var members = new List<IMember>();
            var ratings = new List<IRating>();
            var award = await ImportAwardAsync();

            jury.AddRange(await ImportJuryAsync(award));
            projects.AddRange(await ImportProgramAsync(award, members));
            ratings.AddRange(await ImportEvaluationAsync(jury, projects));

            WriteProgramToCsv("Programm.csv");
            WriteEmailJury("EmailJury.txt", jury);
            WriteEmailMembers("EmailMembers.txt", members);
            WriteEvaluationTableToCsv("EvaluationTable.csv", jury, projects);
        }

        static void WriteProgramToCsv(string fileName)
        {
            var lines = new List<string>();
            var filePath = Path.Combine(PAPath, ProgramFolder);

            foreach (var item in new DirectoryInfo(filePath).GetDirectories())
            {
                var data = item.Name.Split(' ');

                lines.Add(string.Join(";", data));
            }
            File.WriteAllLines(Path.Combine(PAPath, fileName), lines.ToArray(), System.Text.Encoding.UTF8);
        }
        static void WriteEvaluationTableToCsv(string fileName, IEnumerable<IJuror> jury, IEnumerable<IProject> projects)
        {
            var lines = new List<string>();

            foreach (var juror in jury)
            {
                foreach (var project in projects)
                {
                    lines.Add($"{juror.Name};{project.Title};Best Of Project;");
                    lines.Add($"{juror.Name};{project.Title};Best Of Business;");
                    lines.Add($"{juror.Name};{project.Title};Best Of Innovation;");
                    lines.Add(";;;");
                }
            }
            File.WriteAllLines(Path.Combine(PAPath, fileName), lines.ToArray(), System.Text.Encoding.UTF8);
        }
        static void WriteEmailJury(string fileName, IEnumerable<IJuror> jury)
        {
            var line = string.Empty;

            foreach (var item in jury)
            {
                if (item.Email != null && item.Email.Equals("---") == false)
                {
                    if (line.Length > 0)
                        line += ";";

                    line += item.Email;
                }
            }
            File.WriteAllText(Path.Combine(PAPath, fileName), line, System.Text.Encoding.UTF8);
        }
        static void WriteEmailMembers(string fileName, IEnumerable<IMember> members)
        {
            var line = string.Empty;

            foreach (var item in members)
            {
                if (item.Email != null && item.Email.Equals("---") == false)
                {
                    if (line.Length > 0)
                        line += ";";

                    line += item.Email;
                }
            }
            File.WriteAllText(Path.Combine(PAPath, fileName), line, System.Text.Encoding.UTF8);
        }
        static async Task<IAward> ImportAwardAsync()
        {
            var accMngr = new AccountManager();
            var login = await accMngr.LogonAsync(SaEmail, SaPwd, string.Empty).ConfigureAwait(false);
            string filePath = Path.Combine(PAPath, "Award.txt");
            using var adapter = Adapters.Factory.Create<IAward>(login.SessionToken);
            var entity = await adapter.CreateAsync();
            var lines = File.ReadAllLines(filePath);

            entity.Title = lines[0];
            entity.Location = lines[1];
            entity.From = DateTime.Parse(lines[2]);
            entity.To = DateTime.Parse(lines[3]);
            entity.State = (Contracts.Modules.Common.AwardState)Convert.ToInt32(lines[4]);
            entity = await adapter.InsertAsync(entity);
            await accMngr.LogoutAsync(login.SessionToken).ConfigureAwait(false);

            return entity;
        }

        static async Task<IEnumerable<IJuror>> ImportJuryAsync(IAward award)
        {
            var result = new List<IJuror>();
            var accMngr = new AccountManager();
            var login = await accMngr.LogonAsync(SaEmail, SaPwd, string.Empty).ConfigureAwait(false);
            string filePath = Path.Combine(PAPath, JuryFolder, "Jurylist.txt");
            using var adapter = Adapters.Factory.Create<IJuror>(login.SessionToken);
            var lines = File.ReadAllLines(filePath).Where(l => string.IsNullOrEmpty(l) == false).ToArray();

            for (int i = 0; i < lines.Length;)
            {
                var entity = await adapter.CreateAsync();

                entity.AwardId = award.Id;
                entity.Name = lines[i++];
                entity.Position = lines[i++];
                entity.Institution = lines[i++];
                entity.Email = lines[i++];
                entity = await adapter.InsertAsync(entity);
                result.Add(entity);
            }
            await accMngr.LogoutAsync(login.SessionToken).ConfigureAwait(false);
            return result;
        }
        static async Task<IEnumerable<IProject>> ImportProgramAsync(IAward award, List<IMember> members)
        {
            var result = new List<IProject>();
            var accMngr = new AccountManager();
            var login = await accMngr.LogonAsync(SaEmail, SaPwd, string.Empty).ConfigureAwait(false);
            string filePath = Path.Combine(PAPath, ProgramFolder);
            using var adapter = Adapters.Factory.Create<IProject>(login.SessionToken);

            members ??= new List<IMember>();

            foreach (var item in new DirectoryInfo(filePath).GetDirectories())
            {
                var data = item.Name.Split(' ');

                if (data.Length == 5)
                {
                    var entity = await adapter.CreateAsync();
                    var fileDescription = Path.Combine(filePath, item.Name, "Description.txt");
                    var fileLogo = Path.Combine(filePath, item.Name, "Logo.png");
                    var fileMembers = Path.Combine(filePath, item.Name, "Members.txt");

                    entity.AwardId = award.Id;
                    entity.From = TimeSpan.ParseExact(data[0], "hhmm", null);
                    entity.To = TimeSpan.ParseExact(data[1], "hhmm", null);
                    entity.School = $"{data[2]} - {data[3]}";
                    entity.Title = data[4];
                    entity.Description = File.Exists(fileDescription) ? File.ReadAllText(fileDescription) : "No description";
                    entity.Logo = File.Exists(fileLogo) ? File.ReadAllBytes(fileLogo) : null;
                    entity = await adapter.InsertAsync(entity);
                    result.Add(entity);

                    if (File.Exists(fileMembers))
                    {
                        members.AddRange(await ImportMembersAsync(login.SessionToken, entity, fileMembers));
                    }
                }
            }
            await accMngr.LogoutAsync(login.SessionToken).ConfigureAwait(false);
            return result;
        }
        static async Task<IEnumerable<IMember>> ImportMembersAsync(string token, IProject project, string filePath)
        {
            var result = new List<IMember>();
            var accMngr = new AccountManager();
            using var adapter = Adapters.Factory.Create<IMember>(token);
            var lines = File.ReadAllLines(filePath).Where(l => string.IsNullOrEmpty(l) == false).ToArray();

            for (int i = 0; i < lines.Length;)
            {
                var entity = await adapter.CreateAsync();

                entity.ProjectId = project.Id;
                entity.Course = lines[i++].Trim();
                entity.Role = lines[i++].Trim();
                entity.Name = lines[i++].Trim();
                entity.Email = lines[i++].Trim();
                entity.Phone = lines[i++].Trim();
                entity = await adapter.InsertAsync(entity);
                result.Add(entity);
            }
            return result;
        }
        static async Task<IEnumerable<IRating>> ImportEvaluationAsync(IEnumerable<IJuror> jury, IEnumerable<IProject> projects)
        {
            var result = new List<IRating>();
            var accMngr = new AccountManager();
            var login = await accMngr.LogonAsync(SaEmail, SaPwd, string.Empty).ConfigureAwait(false);
            using var adapter = Adapters.Factory.Create<IRating>(login.SessionToken);

            foreach (var juror in jury)
            {
                foreach (var project in projects)
                {
                    var entity = await adapter.CreateAsync();

                    entity.JurorId = juror.Id;
                    entity.ProjectId = project.Id;
                    entity.Category = Contracts.Modules.Common.RateCategory.BestOfProject;
                    entity.Rate = Contracts.Modules.Common.Rate.Undefined;
                    entity = await adapter.InsertAsync(entity);
                    result.Add(entity);

                    entity = await adapter.CreateAsync();

                    entity.JurorId = juror.Id;
                    entity.ProjectId = project.Id;
                    entity.Category = Contracts.Modules.Common.RateCategory.BestOfBusiness;
                    entity.Rate = Contracts.Modules.Common.Rate.Undefined;
                    entity = await adapter.InsertAsync(entity);
                    result.Add(entity);

                    entity = await adapter.CreateAsync();

                    entity.JurorId = juror.Id;
                    entity.ProjectId = project.Id;
                    entity.Category = Contracts.Modules.Common.RateCategory.BestOfInnovation;
                    entity.Rate = Contracts.Modules.Common.Rate.Undefined;
                    entity = await adapter.InsertAsync(entity);
                    result.Add(entity);
                }
            }
            await accMngr.LogoutAsync(login.SessionToken).ConfigureAwait(false);
            return result;
        }
    }
}
