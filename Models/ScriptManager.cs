using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YouTubeEmbed.Services;

namespace YouTubeEmbed.Models
{
    public class ScriptManager : IScriptManager
    {
        private readonly List<ScriptReference> _scripts = new List<ScriptReference>();

        public List<ScriptReference> Scripts => _scripts;
        public List<string> ScriptTexts { get; } = new List<string>();

        public void AddScript(ScriptReference scriptReference)
        {
            if (Scripts.All(x => x.ScriptPath != scriptReference.ScriptPath))
                _scripts.Add(scriptReference);
        }

        public void AddScriptText(string scriptTextExecute)
        {
            if (!ScriptTexts.Contains(scriptTextExecute))
                ScriptTexts.Add(scriptTextExecute);
        }
    }
}
