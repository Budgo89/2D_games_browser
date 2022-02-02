using System.Collections.Generic;
using PlatformerMVC.Controllers;
using PlatformerMVC.View;

namespace PlatformerMVC.Configs
{
    public class CoinController
    {
        private SpriteAnimatorController _coinAnimator;
        private float _animationSpeed = 10f;

        public CoinController(List<LevelObjectView> coin, SpriteAnimatorController coinAnimator)
        {
            _coinAnimator = coinAnimator;
            foreach (var VARIABLE in coin)
            {
                
                _coinAnimator.StartAnimation(VARIABLE.SpriteRenderer, AnimStatePlayer.Idle, true, _animationSpeed);

            }

        }

        public void Update()
        {
            _coinAnimator.Update();
        }
    }
}
