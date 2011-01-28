using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bbsharp.Renderers.Html
{
    public static partial class HtmlRenderer
    {
        /// <summary>
        /// Internal method for rendering a BBCode tag that corresponds to a class on the HTML tag
        /// </summary>
        public static string ClassConvert(BBCodeNode Node, bool ThrowOnError, object LookupTable)
        {
            string converted;
            switch (Node.TagName)
            {
                case "s":
                case "S":
                    converted = "<span style=\"text-decoration: line-through\">"
                    + Node.Children.ToHtml(ThrowOnError, LookupTable)
                    + "</span>";
                    break;
                case "u":
                case "U":
                    converted = "<span style=\"text-decoration: underline\">"
                    + Node.Children.ToHtml(ThrowOnError, LookupTable)
                    + "</span>";
                    break;
                case "size":
                    converted = string.Format("<span style=\"font-size: {0}px\">", Node.Attribute)
                    + Node.Children.ToHtml(ThrowOnError, LookupTable)
                    + "</span>";
                    break;
                default:
                    converted = "<div class=\"" + Node.TagName + "\">"
                    + Node.Children.ToHtml(ThrowOnError, LookupTable)
                    + "</div>";
                    break;
            }
            return converted;
        }
    }
}
