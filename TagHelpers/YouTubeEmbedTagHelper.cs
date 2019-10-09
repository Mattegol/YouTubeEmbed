﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace YouTubeEmbed.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("YouTubeEmbed")]
    public class YouTubeEmbedTagHelper : TagHelper
    {
        public string YouTubeId { get; set; }    

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";
            var sb = new StringBuilder();
            sb.Append(@"
                    <script src='/lib/jquery/dist/jquery.js'></script>
                ");
            sb.Append(@"
                    <script src='/lib/non-sucky-youtube-embed/jquery.nonSuckyYouTubeEmbed.js'></script>
                ");
            sb.AppendFormat("<div class=\"nsyte\" youtubeid=\"{0}\"></div>", YouTubeId);
            var scriptTextExecute = string.Format(@"
                  <script>$(document).ready(function () {{
                        $('.nsyte').nonSuckyYouTubeEmbed();
                }});</script>
            ");
            sb.Append(scriptTextExecute);
            output.PostContent.AppendHtml(sb.ToString());
        }
    }
}
