using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using YouTubeEmbed.Models;
using YouTubeEmbed.Services;

namespace YouTubeEmbed.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("YouTubeEmbed")]
    public class YouTubeEmbedTagHelper : TagHelper
    {
        private readonly IScriptManager _scriptManager;

        public YouTubeEmbedTagHelper(IScriptManager scriptManager)
        {
            _scriptManager = scriptManager;
        }

        public string YouTubeId { get; set; }    

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            _scriptManager.AddScript(
                new ScriptReference("/lib/jquery/dist/jquery.js", 1000));

            _scriptManager.AddScript(
                new ScriptReference("/lib/non-sucky-youtube-embed/jquery.nonSuckyYouTubeEmbed.js", 1000));

            output.Attributes.Add(new TagHelperAttribute("youtubeid", YouTubeId));
            output.Attributes.Add(new TagHelperAttribute("class", "nsyte"));
            
            var scriptTextExecute = @"
                  <script>$(document).ready(function () {
                        $('.nsyte').nonSuckyYouTubeEmbed();
                });</script>
            ";

            _scriptManager.AddScriptText(scriptTextExecute);

        }
    }
}
