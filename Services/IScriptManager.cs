using System.Collections.Generic;
using YouTubeEmbed.Models;

namespace YouTubeEmbed.Services
{
    public interface IScriptManager
    {
        List<ScriptReference> Scripts { get; }

        List<string> ScriptTexts { get; }

        void AddScriptText(string scriptTextExecute);

        void AddScript(ScriptReference script);
    }
}
