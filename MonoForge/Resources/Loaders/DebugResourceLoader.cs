using System.IO;

namespace MonoForge
{
    public sealed class DebugResourceLoader : ResourceLoader
    {
        public override Stream Open(string RelativePath)
        {
            throw new System.NotImplementedException();//TODO
        }

        public override bool Exists(string RelativePath)
        {
            throw new System.NotImplementedException();//TODO
        }
    }
}