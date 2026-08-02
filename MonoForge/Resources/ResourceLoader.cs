using System;
using System.IO;

namespace MonoForge
{
    public static class ResourceLoader
    {
        private static readonly string RootPath;
        public  static readonly string SavesPath;

        static ResourceLoader()
        {
            RootPath = Path.Combine
            (
                AppDomain.CurrentDomain.BaseDirectory, "..", "..", ".."
            );
            SavesPath = Directory.CreateDirectory
            (
                Path.Combine(RootPath, "Saves")
            ).FullName;
        }
    }
}