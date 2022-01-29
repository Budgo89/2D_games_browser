using PlatformerMVC.Controllers;
using PlatformerMVC.View;

namespace PlatformerMVC.Configs
{
    public class CoinController
    {
        private SpriteAnimatorController _coinAnimator;
        private float _animationSpeed = 10f;

        public CoinController(LevelObjectView coin, SpriteAnimatorController coinAnimator)
        {
            _coinAnimator = coinAnimator;
            _coinAnimator.StartAnimation(coin.SpriteRenderer, AnimStatePlayer.Idle, true, _animationSpeed);
        }

        public void Update()
        {
            _coinAnimator.Update();
        }
    }
}
