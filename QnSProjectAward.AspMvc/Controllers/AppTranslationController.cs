//@QnSCodeCopy
//MdStart
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QnSProjectAward.AspMvc.Controllers
{
    public class AppTranslationController : AccessController
    {
        public AppTranslationController(IFactoryWrapper factoryWrapper)
            : base(factoryWrapper)
        {

        }

        public IActionResult Index(string error = null)
        {
            string page = SessionWrapper.GetStringValue(nameof(page), "A");

            Modules.Language.Translator.Init();
            return RedirectToAction(nameof(Translations), new { page, error });
        }

        public IActionResult Translations(string page = null, string error = null)
        {
            var model = new Models.Modules.Language.AppTranslation
            {
                Action = "UpdateTranslations",
                ActionError = error,
            };
            model.NavLinks.Add(new Models.ActionItem
            {
                Text = "Stored translations",
                Action = nameof(Translations),
                Controller = ControllerName,
                Active = true,
            });
            model.NavLinks.Add(new Models.ActionItem
            {
                Text = "Unstored translations",
                Action = nameof(UnstoredTranslations),
                Controller = ControllerName,
                Active = false,
            });
            page = string.IsNullOrEmpty(page) ? "A" : page;
            SessionWrapper.SetStringValue(nameof(page), page);

            Modules.Language.Translator.StoredTranslations
                                       .Where(i => string.IsNullOrEmpty(page) || page.Equals("All") || i.Key.ToUpper().StartsWith(page))
                                       .OrderBy(i => i.Key)
                                       .ToList()
                                       .ForEach(e => model.Entries.Add(e.Key, e.Value));
            return View("Index", model);
        }
        public IActionResult UnstoredTranslations(string page = null, string error = null)
        {
            var model = new Models.Modules.Language.AppTranslation
            {
                Action = "StoreTranslations",
                ActionError = error,
            };
            model.NavLinks.Add(new Models.ActionItem
            {
                Text = "Stored translations",
                Action = nameof(Translations),
                Controller = ControllerName,
                Active = false,
            });
            model.NavLinks.Add(new Models.ActionItem
            {
                Text = "Unstored translations",
                Action = nameof(UnstoredTranslations),
                Controller = ControllerName,
                Active = true,
            });
            page = string.IsNullOrEmpty(page) ? "A" : page;
            SessionWrapper.SetStringValue(nameof(page), page);

            Modules.Language.Translator.UnstoredTranslations
                                       .Where(i => string.IsNullOrEmpty(page) || page.Equals("All") || i.Key.StartsWith(page))
                                       .OrderBy(i => i.Key)
                                       .ToList()
                                       .ForEach(e => model.Entries.Add(e.Key, e.Value));
            return View("Index", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("UpdateTranslations")]
        public async Task<IActionResult> UpdateTranslationsAsync(IFormCollection formCollection)
        {
            var index = 0;
            var action = nameof(Translations);
            var page = SessionWrapper.GetStringValue("page");
            var error = string.Empty;
            var keyValuePairs = new List<KeyValuePair<string, Models.Modules.Language.TranslationEntry>>();

            while (formCollection.TryGetValue($"id[{index}]", out StringValues idValues)
                   && formCollection.TryGetValue($"key[{index}]", out StringValues keyValues)
                   && formCollection.TryGetValue($"value[{index++}]", out StringValues valueValues))
            {
                keyValuePairs.Add(new KeyValuePair<string, Models.Modules.Language.TranslationEntry>(keyValues[0],
                    new Models.Modules.Language.TranslationEntry
                    {
                        Id = Convert.ToInt32(idValues[0]),
                        Value = valueValues[0]
                    }));
            }
            try
            {
                await Modules.Language.Translator.UpdateTranslationsAsync(keyValuePairs).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                error = GetExceptionError(ex);
            }
            return RedirectToAction(action, new { page, error });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("StoreTranslations")]
        public async Task<IActionResult> StoreTranslationsAsync(IFormCollection formCollection)
        {
            var index = 0;
            var action = nameof(UnstoredTranslations);
            var page = SessionWrapper.GetStringValue("page");
            var error = string.Empty;
            var keyValuePairs = new List<KeyValuePair<string, Models.Modules.Language.TranslationEntry>>();

            while (formCollection.TryGetValue($"id[{index}]", out StringValues idValues)
                   && formCollection.TryGetValue($"key[{index}]", out StringValues keyValues)
                   && formCollection.TryGetValue($"value[{index++}]", out StringValues valueValues))
            {
                keyValuePairs.Add(new KeyValuePair<string, Models.Modules.Language.TranslationEntry>(keyValues[0],
                    new Models.Modules.Language.TranslationEntry
                    {
                        Id = Convert.ToInt32(idValues[0]),
                        Value = valueValues[0]
                    }));
            }
            try
            {
                await Modules.Language.Translator.StoreTranslationsAsync(keyValuePairs).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                error = GetExceptionError(ex);
                action = nameof(UnstoredTranslations);
            }
            return RedirectToAction(action, new { page, error });
        }
    }
}
//MdEnd
