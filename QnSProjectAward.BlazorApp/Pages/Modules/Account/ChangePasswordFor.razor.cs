//@QnSCodeCopy
using Microsoft.AspNetCore.Components.Forms;
using Radzen;
using System;
using System.Threading.Tasks;
using TModel = QnSProjectAward.BlazorApp.Models.Modules.Account.ChangePasswordForModel;

namespace QnSProjectAward.BlazorApp.Pages.Modules.Account
{
    public partial class ChangePasswordFor
    {

        private TModel formModel = null;

        private TModel FormModel
        {
            get => formModel ??= new TModel();
            set => formModel = value;
        }
        private EditContext editContext = null;
        private EditContext EditContext
        {
            get => editContext ??= new EditContext(FormModel);
            set => editContext = value;
        }
        private string error = null;
        private string Error
        {
            get => error ??= string.Empty;
            set => error = value;
        }

        protected override Task OnFirstRenderAsync()
        {
            FormModel.UserName = AuthorizationSession?.Username;
            FormModel.Email = AuthorizationSession?.Email;

            return base.OnFirstRenderAsync();
        }

        protected async Task OnSubmitAsync()
        {
            if (EditContext.Validate())
            {
                Error = string.Empty;
                try
                {
                    await AccountService.ChangePasswordForAsync(FormModel.Email, FormModel.NewPassword).ConfigureAwait(false);
                    FormModel.NewPassword = FormModel.ConfirmPassword = string.Empty;
                    await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
                    ShowNotification(new NotificationMessage()
                    {
                        Severity = NotificationSeverity.Success,
                        Summary = Translator.Translate("ResetPassword"),
                        Detail = Translate("Password reseted successfully!"),
                        Duration = 4000
                    });
                }
                catch (Exception ex)
                {
                    Error = Translate(GetExceptionError(ex));
                    ShowNotification(new NotificationMessage()
                    {
                        Severity = NotificationSeverity.Error,
                        Summary = Translator.Translate("ResetPassword"),
                        Detail = Translate(GetExceptionError(ex)),
                        Duration = 4000
                    });
                }
            }
            else
            {
                await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
            }
        }
        private void ShowNotification(NotificationMessage message)
        {
            NotificationService.Notify(message);
        }
    }
}
