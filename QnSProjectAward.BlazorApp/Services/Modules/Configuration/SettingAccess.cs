//@QnSCodeCopy
//MdStart
using QnSProjectAward.BlazorApp.Services.Modules.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QnSProjectAward.BlazorApp.Services.Modules.Configuration
{
	public abstract partial class SettingAccess : ISettingAccess
    {
        protected IAccountService AccountService { get; init; }
        protected IServiceAdapter ServiceAdapter { get; init; }

        protected Dictionary<string, string> storedEntries = null;
        protected Dictionary<string, string> StoredEntries
        {
            get
            {
                if (storedEntries == null)
                {
                    Init();
                }
                return storedEntries ?? new Dictionary<string, string>();
            }
        }
        protected Dictionary<string, string> UnstoredEntries { get; } = new Dictionary<string, string>();

        public SettingAccess(IAccountService accountService, IServiceAdapter serviceAdapter)
        {
            AccountService = accountService;
            ServiceAdapter = serviceAdapter;
        }
        private void Init()
        {
            Task.Run(async () =>
            {
                var handled = false;

                BeginLoadData(ref handled);
                if (handled == false)
                {
                    await LoadDataAsync().ConfigureAwait(false);
                }
            }).Wait();
            EndLoadData();
        }
        partial void BeginLoadData(ref bool handled);
        partial void EndLoadData();

        public void Reload()
        {
            Task.Run(async () =>
            {
                var handled = false;

                BeginLoadData(ref handled);
                if (handled == false)
                {
                    await LoadDataAsync().ConfigureAwait(false);
                }
            }).Wait();
            EndLoadData();
        }
        protected abstract Task LoadDataAsync();

        public bool ContainsKey(string key)
        {
            return StoredEntries.ContainsKey(key);
        }
        public string GetValue(string key, string defaultValue)
        {
            var hasItem = StoredEntries.TryGetValue(key, out string result);

            if (hasItem == false)
            {
                result = defaultValue;
                if (UnstoredEntries.ContainsKey(key) == false)
                {
                    UnstoredEntries.Add(key, defaultValue);
                }
            }
            return result;
        }
        public T GetValueTyped<T>(string key, object defaultValue)
        {
            var value = GetValue(key, defaultValue?.ToString());

            return (T)Convert.ChangeType(value, typeof(T));
        }

        public KeyValuePair<string, string>[] GetUnstoredSettings()
        {
            return UnstoredEntries.ToArray();
        }
        public KeyValuePair<string, string>[] QueryStoredSettings(Func<KeyValuePair<string, string>, bool> predicate)
        {
            return StoredEntries.Where(predicate).ToArray();
        }
        public KeyValuePair<string, string>[] QueryUnstoredSettings(Func<KeyValuePair<string, string>, bool> predicate)
        {
            return UnstoredEntries.Where(predicate).ToArray();
        }
    }
}
//MdEnd
