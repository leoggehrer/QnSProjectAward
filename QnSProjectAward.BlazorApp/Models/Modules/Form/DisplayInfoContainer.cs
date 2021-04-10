//@QnSCodeCopy
//MdStart

using CommonBase.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;

namespace QnSProjectAward.BlazorApp.Models.Modules.Form
{
    public partial class DisplayInfoContainer : IEnumerable<KeyValuePair<string, DisplayInfo>>
    {
        private readonly Dictionary<string, DisplayInfo> displayInfos = new();
        public DisplayInfo this[string key]
        {
            get
            {
                return displayInfos[key];
            }
        }
        private void Add(DisplayInfo displayInfo)
        {
            displayInfo.CheckArgument(nameof(displayInfo));

            displayInfos.Add(displayInfo.Key, displayInfo);
        }
        public void AddOrSet(DisplayInfo displayInfo)
        {
            displayInfo.CheckArgument(nameof(displayInfo));
            displayInfo.Key.CheckNotNullOrEmpty(nameof(displayInfo.Key));

            if (displayInfos.ContainsKey(displayInfo.Key))
            {
                displayInfos[displayInfo.Key] = displayInfo;
            }
            else
            {
                Add(displayInfo);
            }
        }
        public void AddOrSet(string key, Action<DisplayInfo> action)
        {
            key.CheckNotNullOrEmpty(nameof(key));

            DisplayInfo displayInfo;                ;

            if (displayInfos.ContainsKey(key))
            {
                displayInfo = displayInfos[key];
            }
            else
            {
                displayInfo = new DisplayInfo(key);
                displayInfos.Add(key, displayInfo);
            }
            action?.Invoke(displayInfo);
        }

        public bool TryGetValue(string key, out DisplayInfo displayInfo)
        {
            return displayInfos.TryGetValue(key, out displayInfo);
        }
        public void SetValue(string key, Action<DisplayInfo> action)
        {
            action?.Invoke(this[key]);
        }

        public bool ContainsKey(string key)
        {
            return displayInfos.ContainsKey(key);
        }
        public IEnumerator<KeyValuePair<string, DisplayInfo>> GetEnumerator()
        {
            return displayInfos.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return displayInfos.GetEnumerator();
        }
    }
}
//MdEnd
