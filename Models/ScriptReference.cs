namespace YouTubeEmbed.Models
{
    public class ScriptReference
    {
        public string ScriptPath { get; private set; }
        public int IncludeOrderPriority { get; private set; }

        public ScriptReference(string scriptPath, int includeOrderPriority = 0)
        {
            ScriptPath = scriptPath;
            IncludeOrderPriority = includeOrderPriority;
        }
    }
}
