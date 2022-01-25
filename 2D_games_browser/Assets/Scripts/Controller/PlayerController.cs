using Assets.Scripts.Initializer;
using Interface;

namespace Controller
{
    internal class PlayerController : IInitialization
    {
        private PlayerInitializer playerInitializer;

        public PlayerController(PlayerInitializer playerInitializer)
        {
            this.playerInitializer = playerInitializer;
        }

        public void Initialization()
        {
        }
    }
}