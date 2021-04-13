//@QnSCodeCopy
//MdStart
using CommonBase.Extensions;
using QnSProjectAward.BlazorApp.Pages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QnSProjectAward.BlazorApp.Modules.Helpers
{
    public class ItemContainer<T> 
        where T : Contracts.IIdentifiable
    {
        private IEnumerable<T> items = null;
        public IEnumerable<T> Items
        {
            get
            {
                var result = items;

                if (items == null)
                {
                    using var access = ModelPage.CreateService<T>();
                    
                    if (ModelPage.AuthorizationSession != null)
					{
                        access.SessionToken = ModelPage.AuthorizationSession.Token;
                        result = items = Task.Run(async () => await access.GetAllAsync().ConfigureAwait(false)).Result;
                    }
                    else
					{
                        result = Array.Empty<T>();
					}
                }
                return result;
            }
        }
        private ModelPage ModelPage { get; init; }

        public ItemContainer(ModelPage modelPage)
        {
            modelPage.CheckArgument(nameof(modelPage));

            ModelPage = modelPage;
        }
    }
}
//MdEnd
