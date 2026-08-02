using Zion;

namespace MonoForge
{
    public sealed class GameServices
    {
        public static readonly GameServices Global = new();

        private readonly TypeMap Services = new();
    }
}