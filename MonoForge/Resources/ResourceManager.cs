using System;
using System.IO;
using System.Threading.Tasks;
using Zion.Serialization.NSD;

namespace MonoForge
{
    public static class ResourceManager
    {
        private static readonly string RootPath;
        public  static readonly string SavesPath;

        private static readonly ResourceLoader Loader;

        private static readonly ResourceRegistry ResourceRegistry;
        private static readonly SceneRegistry    SceneRegistry;


        static ResourceManager()
        {
            RootPath = Path.Combine
            (
                AppDomain.CurrentDomain.BaseDirectory, "..", "..", ".."
            );
            SavesPath = Directory.CreateDirectory
            (
                Path.Combine(RootPath, "Saves")
            ).FullName;

            #if DEBUG
                Loader = new DebugResourceLoader() { RootPath = RootPath };
            #else
                Loader = new ReleaseResourceLoader() { RootPath = RootPath };
            #endif

            var ResourceRegistryLoading = LoadResourceRegistryAsync();
            var SceneRegistryLoading = LoadSceneRegistryAsync();

            Task.WaitAll(ResourceRegistryLoading, SceneRegistryLoading);

            ResourceRegistry = ResourceRegistryLoading.Result;
            SceneRegistry = SceneRegistryLoading.Result;
        }


        public static async Task<ProjectSettings> LoadProjectSettingsAsync()
        {
            return await LoadSettingsAsync<ProjectSettings>("ProjectSettings.nsd");
        }

        public static async Task<ResourceRegistry> LoadResourceRegistryAsync()
        {
            return await LoadSettingsAsync<ResourceRegistry>("ResourceRegistry.nsd");
        }

        public static async Task<SceneRegistry> LoadSceneRegistryAsync()
        {
            return await LoadSettingsAsync<SceneRegistry>("SceneRegistry.nsd");
        }


        private static async Task<T> LoadSettingsAsync<T>(string FileName) where T : INSDContainer<T>
        {
            string RelativePath = Path.Combine("ProjectSettings", FileName);

            if (!Loader.Exists(RelativePath))
            {

            }

            T Result = default!;

            using (NSDReader Reader = new NSDReader(Loader.Open(RelativePath), () => Loader.Open(RelativePath)))
            {
                Reader.ReadContainer<T>("Root", X => Result = X);
            }

            if (Result is null)
            {
                //TODO: Check Result is null
            }

            return Result;
        }
    }
}