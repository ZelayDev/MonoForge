using Microsoft.Xna.Framework.Graphics;
using System;
using System.Threading.Tasks;

namespace MonoForge
{
    public sealed class GameManager : IDisposable
    {
        private readonly GameHost Host;

        private ProjectSettings  ProjectSettings;

        public Scene ActiveScene { get; private set; }

        private float FixedUpdateAccumulator;


        public GameManager()
        {
            Host = new(this);
        }


        public void Run()
        {
            Host.Run();
        }


        internal void Initialize()
        {
            ProjectSettings = ResourceManager.LoadProjectSettingsAsync().GetAwaiter().GetResult();
        }

        internal void Update(float ElapsedTime)
        {
            FixedUpdateAccumulator += ElapsedTime;

            Time.DeltaTime = ElapsedTime;

            //Update()
            //LastUpdate()

            FixedUpdate();
        }

        internal void Render(SpriteBatch Batch)
        {
            //...
        }


        private void FixedUpdate()
        {
            float Accumulator = FixedUpdateAccumulator;
            float DeltaTime = Time.FixedDeltaTime;

            while (Accumulator >= DeltaTime)
            {
                //...

                Accumulator -= DeltaTime;
            }

            FixedUpdateAccumulator = Accumulator;
        }


        public void Dispose()
        {
            Host.Dispose();
        }
    }
}