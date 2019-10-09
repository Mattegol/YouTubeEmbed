using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using YouTubeEmbed.Services;

namespace YouTubeEmbed.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("body")]
    public class BodyTagHelper : TagHelper
    {
        private readonly IScriptManager _scriptManager;
        public BodyTagHelper(IScriptManager scriptManager)
        {
            _scriptManager = scriptManager;
        }
        public override async Task ProcessAsync(TagHelperContext context,
            TagHelperOutput output)
        {
            (await output.GetChildContentAsync()).GetContent();

            var sb = new StringBuilder();
            if (_scriptManager.Scripts.Count > 0)
            {
                foreach (var scriptRef in
                    _scriptManager.Scripts.OrderBy(a => a.IncludeOrderPriority))
                    sb.AppendLine($"<script src='{scriptRef.ScriptPath}' ></script>");
                sb.AppendLine("<script type='text/javascript'>");
                foreach (var scriptText in _scriptManager.ScriptTexts)
                    sb.AppendLine(scriptText);
                sb.AppendLine("</script>");
            }
            output.PostContent.AppendHtml(sb.ToString());
        }
    }
}
