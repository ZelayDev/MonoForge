using System.IO;

namespace MonoForge
{
    public abstract class ResourceLoader
    {
        public required string RootPath { protected get; init; }


        public abstract Stream Open(string RelativePath);

        public abstract bool Exists(string RelativePath);


        protected string GetFullPath(string RelativePath)
        {
            return Path.Combine(RootPath, RelativePath);
        }
    }
}