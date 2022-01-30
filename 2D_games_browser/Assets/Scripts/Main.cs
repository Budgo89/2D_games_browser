using System;
using System.Collections;
using System.Collections.Generic;
using PlatformerMVC.Configs;
using PlatformerMVC.Controllers;
using PlatformerMVC.View;
using UnityEngine;


namespace PlatformerMVC
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig _playerAnimatorConfig;
        [SerializeField] private SpriteAnimatorConfig _coinAnimatorConfig;
        [SerializeField] private int _animationSpeed;
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private CanonView _canonView;
        [SerializeField] private LevelObjectView _coin;
        [SerializeField] private List<LevelObjectView> _coinViews;
        [SerializeField] private List<LevelObjectView> _deathZones;
        [SerializeField] private List<LevelObjectView> _winZones;
        [SerializeField] private Vector3 _startPosition;

        private SpriteAnimatorController _playerAnimator;
        private SpriteAnimatorController _coinAnimator;
        private CameraController _cameraController;
        private PlayerController _playerController;
        private CoinController _coinController;
        private CanonAimController _canonAimController;
        private BulletEmitterController _bulletEmitterController; //The intialization of BulletController we make here
        private CoinsManager _coinsManager;
        private LevelCompleteManager _levelCompleteManager;


        private void Start()
        {
            _playerAnimatorConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimatorConfig");
            _coinAnimatorConfig = Resources.Load<SpriteAnimatorConfig>("CoinAnimatorConfig");
            if (_playerAnimatorConfig)
            {
                _playerAnimator = new SpriteAnimatorController(_playerAnimatorConfig);
            }

            if (_coinAnimatorConfig)
            {
                _coinAnimator = new SpriteAnimatorController(_coinAnimatorConfig);
            }
            _cameraController = new CameraController(_playerView.Transform, Camera.main.transform);
            _playerController = new PlayerController(_playerView, _playerAnimator);
            _coinController = new CoinController(_coin,_coinAnimator);
            _canonAimController = new CanonAimController(_canonView.MuzzleTransform, _playerView.Transform);
            _bulletEmitterController = new BulletEmitterController(_canonView.Bullets, _canonView.EmitterTransform, _canonView.Shootingstation);
            _coinsManager = new CoinsManager(_playerView, _coinViews, _playerAnimator);
            _levelCompleteManager = new LevelCompleteManager(_playerView, _deathZones, _winZones, _startPosition);
        }

        private void LateUpdate()
        {
            _playerController.Update();
            _cameraController.Update();
            _canonAimController.Update();
            _bulletEmitterController.Update(_playerView.Transform.position, _canonView.transform.position);
            _coinAnimator.Update();
        }
    }
}

