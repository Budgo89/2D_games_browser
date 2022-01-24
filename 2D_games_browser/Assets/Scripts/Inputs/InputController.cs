using Controller;
using Data;
using Interface;
using System;
using UnityEngine;

namespace Assets.Scripts.Inputs
{
    internal class InputController : IFixed, IInitialization
    {

        private readonly Rigidbody2D _player;
        private readonly float _speed;
        private bool isFacingRight = true;

        public InputController (GameData gameData)
        {
            _player = gameData.PlayerData.PlayerPrefab.GetComponent<Rigidbody2D>();
            _speed = gameData.PlayerData.Speed;
        }
        public void FixedExecute()
        {
            float move = Input.GetAxis("Horizontal");
            _player.velocity = new Vector2(_speed, _player.velocity.y);
            if (move >= 0 && !isFacingRight)
            {
                Flip();
            }
            else if (move < 0 && isFacingRight)
            {
                Flip();
            }
        }

        public void Initialization()
        {
        }

        private void Flip()
        {
            isFacingRight = !isFacingRight;
        }
    }
}
