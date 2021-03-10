//@QnSCodeCopy

using Microsoft.AspNetCore.Components;
using QnSProjectAward.BlazorApp.Modules.SessionStorage;
using QnSProjectAward.BlazorApp.Services.Modules.Language;
using System;
using System.Threading.Tasks;

namespace QnSProjectAward.BlazorApp.Shared
{
	public partial class CommonLayout : LayoutComponentBase
    {
        [Inject]
        protected ITranslatorService Translator { get; private set; }
        [Inject]
        protected IProtectedBrowserStorage ProtectedBrowserStore { get; private set; }

        protected string Translate(string key) => Translator.Translate(key);
        protected string Translate(string key, string defaultValue) => Translator.Translate(key, defaultValue);
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender).ConfigureAwait(false);

            var startedTime = await ProtectedBrowserStore.GetAsync<DateTime?>(StaticLiterals.AppStartedTimeKey).ConfigureAwait(false);

            if (startedTime == null)
            {
                await ProtectedBrowserStore.SetAsync(StaticLiterals.AppStartedTimeKey, DateTime.Now).ConfigureAwait(false);
            }
        }
    }
}
