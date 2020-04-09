using System.Globalization;
using System.Web.Mvc;

namespace WebApp.Helpers.Action
{
    public static class ActionEx
    {
        public static MvcHtmlString ScriptInitiate(this HtmlHelper helper)
        {
            return AddScriptLiteral(helper, "window.urls = window.urls || {};");
        }

        public static MvcHtmlString ScriptAssignment(this HtmlHelper helper, string variableName, string value)
        {
            return AddScriptLiteral(helper,
                string.Format(CultureInfo.InvariantCulture, "{0}='{1}'", variableName, value));
        }

        private static MvcHtmlString AddScriptLiteral(HtmlHelper helper, string scriptText)
        {
            if (!string.IsNullOrEmpty(scriptText))
            {
                scriptText = string.Format(CultureInfo.InvariantCulture, "<script>{0}</script>", scriptText);
                var rawData = helper.Raw(scriptText).ToHtmlString();
                return MvcHtmlString.Create(rawData);
            }

            return MvcHtmlString.Empty;
        }
    }
}