//@QnSCodeCopy
//MdStart
using CommonBase.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace QnSProjectAward.AspMvc.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static HtmlString ToSelect(this IHtmlHelper htmlHelper, string css, string id, string name, IEnumerable<KeyValuePair<Enum, string>> options, Enum selVal)
        {
            options.CheckArgument(nameof(options));

            StringBuilder sb = new StringBuilder();

            sb.Append("<select");
            if (css.HasContent())
                sb.Append($" class=\"{css}\"");

            if (id.HasContent())
                sb.Append($" id=\"{id}\"");

            if (name.HasContent())
                sb.Append($" name=\"{name}\"");

            sb.Append(">");
            foreach (var item in options)
            {
                if (selVal.Equals(item.Key))
                    sb.AppendLine($"<option value=\"{item.Key}\" selected>{item.Value}</option>");
                else
                    sb.AppendLine($"<option value=\"{item.Key}\">{item.Value}</option>");
            }
            sb.AppendLine("</select>");
            return new HtmlString(sb.ToString());
        }
        public static HtmlString ToSelect(this IHtmlHelper htmlHelper, string css, string id, string name, IEnumerable<KeyValuePair<string, string>> options, string selVal)
        {
            options.CheckArgument(nameof(options));

            StringBuilder sb = new StringBuilder();

            sb.Append("<select");
            if (css.HasContent())
                sb.Append($" class=\"{css}\"");

            if (id.HasContent())
                sb.Append($" id=\"{id}\"");

            if (name.HasContent())
                sb.Append($" name=\"{name}\"");

            sb.Append(">");
            foreach (var item in options)
            {
                if (selVal.HasContent() && selVal.Equals(item.Key))
                    sb.AppendLine($"<option value=\"{item.Key}\" selected>{item.Value}</option>");
                else
                    sb.AppendLine($"<option value=\"{item.Key}\">{item.Value}</option>");
            }
            sb.AppendLine("</select>");
            return new HtmlString(sb.ToString());
        }
    }
}
//MdEnd
