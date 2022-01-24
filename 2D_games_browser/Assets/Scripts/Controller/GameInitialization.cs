using Animators;
using Assets.Scripts.Initializer;
using Assets.Scripts.Inputs;
using Data;

namespace Controller
{
    public class GameInitialization
    {
        public GameInitialization(Controllers controllers, GameData gameData)
        {
            var playerInitializer = new PlayerInitializer(gameData);
            
            var playerController = new PlayerController(playerInitializer);
            var inputController = new InputController(gameData);
            var spriteAnimator = new SpriteAnimator(gameData.SpriteAnimationsConfig, gameData);
            controllers.Add(playerController);
            controllers.Add(inputController);
            controllers.Add(spriteAnimator);
        }
    }

}