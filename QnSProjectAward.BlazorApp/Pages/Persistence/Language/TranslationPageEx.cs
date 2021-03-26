//@QnSCodeCopy
//MdStart

using QnSProjectAward.BlazorApp.Pages.Persistence.Configuration;
using QnSProjectAward.BlazorApp.Shared.Components.Persistence.Language;
using QnSProjectAward.Contracts.Persistence.Language;
using Radzen;
using System.Threading.Tasks;
using TContract = QnSProjectAward.Contracts.Persistence.Language.ITranslation;


namespace QnSProjectAward.BlazorApp.Pages.Persistence.Language
{
    partial class TranslationPage
    {
        private static readonly string CommandSaveUnstored = nameof(CommandSaveUnstored);
        protected override void OnInitialized()
        {
            MenuItems.Add(new Models.Modules.Menu.MenuItem()
            {
                Text = TranslateFor("Save unstored items"),
                Value = CommandSaveUnstored,
                Icon = "save",
            });
            base.OnInitialized();
        }

        public override async void OnMenuItemClick(MenuItemEventArgs args)
        {
            base.OnMenuItemClick(args);

            if (args.Value != null && args.Value.Equals(CommandSaveUnstored))
            {
                await InvokePageAsync(async() => await SaveUnstoredItemsAsync().ConfigureAwait(false)).ConfigureAwait(false);
            }
        }
        private async Task SaveUnstoredItemsAsync()
        {
            using var adapter = ServiceAdapter.Create<ITranslation>(AuthorizationSession.Token);

            foreach (var item in Translator.GetUnstoredTranslations())
            {
                var entity = await adapter.CreateAsync().ConfigureAwait(false);

                entity.Key = item.Key;
                entity.Value = item.Value;
                await adapter.InsertAsync(entity).ConfigureAwait(false);
            }
        }
        partial void BeforeFirstRender(ref bool handled)
        {
            handled = true;

            AdapterAccess = ServiceAdapter.Create<TContract>();
            DataGridHandler = new TranslationDataGridHandler(this, new TranslationAdapterAccess(AdapterAccess, Translator));
            DataGridHandler.PageSize = Settings.GetValueTyped<int>($"{ComponentName}.{nameof(DataGridHandler.PageSize)}", DataGridHandler.PageSize);
        }

    }
}
//MdEnd
