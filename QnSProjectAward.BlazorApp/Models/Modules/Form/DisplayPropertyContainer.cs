//@QnSCodeCopy
//MdStart

using CommonBase.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;

namespace QnSProjectAward.BlazorApp.Models.Modules.Form
{
    public partial class DisplayPropertyContainer : IEnumerable<KeyValuePair<string, DisplayProperty>>
    {
        private readonly Dictionary<string, DisplayProperty> displayProperties = new();
        public DisplayProperty this[string key]
        {
            get
            {
                return displayProperties[key];
            }
        }
        public void Add(DisplayProperty displayProperty)
        {
            displayProperty.CheckArgument(nameof(displayProperty));

            displayProperties.Add(displayProperty.Key, displayProperty);
        }
        public void AddOrSet(DisplayProperty displayProperty)
        {
            displayProperty.CheckArgument(nameof(displayProperty));
            displayProperty.Key.CheckNotNullOrEmpty(nameof(displayProperty.Key));

            if (displayProperties.ContainsKey(displayProperty.Key))
            {
                displayProperties[displayProperty.Key] = displayProperty;
            }
            else
            {
                Add(displayProperty);
            }
        }
        public void AddOrSet(string key, Action<DisplayProperty> action)
        {
            key.CheckNotNullOrEmpty(nameof(key));

            DisplayProperty displayProperty;

            if (displayProperties.ContainsKey(key))
            {
                displayProperty = displayProperties[key];
            }
            else
            {
                displayProperty = new DisplayProperty(key);
                displayProperties.Add(key, displayProperty);
            }
            action?.Invoke(displayProperty);
        }

        public bool TryGetValue(string key, out DisplayProperty displayProperty)
        {
            return displayProperties.TryGetValue(key, out displayProperty);
        }
        public void SetValue(string key, Action<DisplayProperty> action)
        {
            action?.Invoke(this[key]);
        }

        public bool ContainsKey(string key)
        {
            return displayProperties.ContainsKey(key);
        }
        public IEnumerator<KeyValuePair<string, DisplayProperty>> GetEnumerator()
        {
            return displayProperties.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return displayProperties.GetEnumerator();
        }
    }
}
//MdEnd
