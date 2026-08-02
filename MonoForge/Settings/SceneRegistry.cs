using Zion.Serialization.NSD;

namespace MonoForge
{
    public sealed class SceneRegistry : INSDContainer<SceneRegistry>
    {
        public readonly int BootScene;


        public void Write(NSDWriteContext Context)
        {
            throw new System.NotImplementedException();
        }

        public static SceneRegistry Read(NSDReadContext Context)
        {
            throw new System.NotImplementedException();
        }
    }
}