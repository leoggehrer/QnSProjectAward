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
            var award = await ImportAwardAsync();

            await ImportJuryAsync(award);
            await ImportProgramAsync(award);
            WriteProgramToCsv("Programm.csv");
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

        static async Task ImportJuryAsync(IAward award)
        {
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
            }
            await accMngr.LogoutAsync(login.SessionToken).ConfigureAwait(false);
        }
        static async Task ImportProgramAsync(IAward award)
        {
            var accMngr = new AccountManager();
            var login = await accMngr.LogonAsync(SaEmail, SaPwd, string.Empty).ConfigureAwait(false);
            string filePath = Path.Combine(PAPath, ProgramFolder);
            using var adapter = Adapters.Factory.Create<IProject>(login.SessionToken);

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

                    if (File.Exists(fileMembers))
                    {
                        await ImportMembersAsync(login.SessionToken, entity, fileMembers);
                    }
                }
            }
            await accMngr.LogoutAsync(login.SessionToken).ConfigureAwait(false);
        }
        static async Task ImportMembersAsync(string token, IProject project, string filePath)
        {
            var accMngr = new AccountManager();
            var login = await accMngr.LogonAsync(SaEmail, SaPwd, string.Empty).ConfigureAwait(false);
            using var adapter = Adapters.Factory.Create<IMember>(token);
            var lines = File.ReadAllLines(filePath).Where(l => string.IsNullOrEmpty(l) == false).ToArray();

            for (int i = 0; i < lines.Length;)
            {
                var entity = await adapter.CreateAsync();

                entity.ProjectId = project.Id;
                entity.Course = lines[i++];
                entity.Role = lines[i++];
                entity.Name = lines[i++];
                entity.Email = lines[i++];
                entity.Phone = lines[i++];
                entity = await adapter.InsertAsync(entity);
            }
        }
    }
}
