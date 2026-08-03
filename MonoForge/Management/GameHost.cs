using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Zion;

namespace MonoForge
{
    public sealed class GameHost : Game
    {
        private readonly GameManager Manager;

        private SpriteBatch SpriteBatch;


        public GameHost(GameManager Manager)
        {
            this.Manager = Manager.NotNull();
        }


        protected override void Initialize()
        {
            Manager.Initialize();
        }

        protected override void Update(GameTime GameTime)
        {
            float Elapsed = (float)GameTime.ElapsedGameTime.TotalSeconds;
            Manager.Update(Elapsed);
            base.Update(GameTime);
        }

        protected override void Draw(GameTime GameTime)
        {
            Manager.Render(SpriteBatch);
            base.Draw(GameTime);
        }
    }
}