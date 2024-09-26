using Controller;
using Data;
using Interface;
using System;
using Animators;
using Assets.Scripts.Helper;
using Configs;
using UnityEngine;

namespace Assets.Scripts.Inputs
{
    public class InputController : IExecute //IFixed, IInitialization
    {
        private const float _walkSpeed = 3f;
        private const float _animationsSpeed = 10f;
        private const float _jumpStartSpeed = 8f;
        private const float _movingThresh = 0.1f;
        private const float _flyThresh = 1f;
        private const float _groundLevel = 0.5f;
        private const float _g = -10f;

        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);

        private float _xAxisInput;
        private bool _doJump = false;
        private float _yVelocity;

        private PlayerData _view;
        private SpriteAnimator _spriteAnimator;

        public InputController(GameData gameData, SpriteAnimator spriteAnimator)
        {
            _view = gameData.PlayerData;
            _spriteAnimator = spriteAnimator;
        }

        #region Error

        //private readonly Rigidbody2D _player;
        //private readonly float _speed;
        //private bool isFacingRight = true;

        //public InputController (GameData gameData)
        //{
        //    _player = gameData.PlayerData.PlayerPrefab.GetComponent<Rigidbody2D>();
        //    _speed = gameData.PlayerData.Speed;
        //}
        //public void FixedExecute()
        //{
        //    float move = Input.GetAxis("Horizontal");
        //    _player.velocity = new Vector2(_speed, _player.velocity.y);
        //    if (move >= 0 && !isFacingRight)
        //    {
        //        Flip();
        //    }
        //    else if (move < 0 && isFacingRight)
        //    {
        //        Flip();
        //    }
        //}

        //public void Initialization()
        //{
        //}

        //private void Flip()
        //{
        //    isFacingRight = !isFacingRight;
        //}

        #endregion
        public void Execute(float deltaTime)
        {
            _doJump = Input.GetAxis("Vertical") > 0;
            _xAxisInput = Input.GetAxis("Horizontal");
            var goSideWay = Mathf.Abs(_xAxisInput) > _movingThresh;

            if (IsGrounded())
            {
                if (goSideWay) GoSideWay(deltaTime);
                    _spriteAnimator.StartAnimation(_view.SprirteRenderer, goSideWay ? Track.Idle:Track.Run, true, _animationsSpeed);
                    if (_doJump && _yVelocity == 0)
                    {
                        _yVelocity = _jumpStartSpeed;
                    }
                    else if (_yVelocity < 0)
                    {
                        _yVelocity = 0;
                        _view.Transform.position = _view.Transform.position.Change(y: _groundLevel);
                    }
            }
            else
            {
                if (goSideWay)
                    GoSideWay(deltaTime);
                if (Mathf.Abs(_yVelocity)> _flyThresh)
                {
                    _spriteAnimator.StartAnimation(_view.SprirteRenderer, Track.Jump, true, _animationsSpeed);
                }

                _yVelocity += _g * deltaTime;
                _view.Transform.position += Vector3.up* (deltaTime *_yVelocity);
            }
        }

        private void GoSideWay(float deltaTime)
        {
            _view.Transform.position += Vector3.right * (deltaTime * _walkSpeed * (_xAxisInput < 0 ? -1 : 1));
            _view.Transform.localScale = (_xAxisInput < 0 ? _leftScale : _rightScale);

        }

        private bool IsGrounded()
        {
            return _view.Transform.position.y <= _groundLevel + float.Epsilon && _yVelocity <= 0;
        }
    }
}
