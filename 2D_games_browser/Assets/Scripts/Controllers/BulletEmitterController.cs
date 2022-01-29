using System.Collections.Generic;
using PlatformerMVC.View;
using UnityEngine;

namespace PlatformerMVC.Controllers
{
    public class BulletEmitterController
    {
        private List<BulletController> _bullets = new List<BulletController>();
        private Transform _transform;
        private float _shootingStation;

        private int _currentIndex;
        private float _timeBetweenBulletShots;
        private const float _delay = 1f;
        private const float _startingSpeed = 9;



        public BulletEmitterController(List<LevelObjectView> bulletViews, Transform transform, float shootingStation)
        {
            _transform = transform;
            _shootingStation = shootingStation;
            foreach (var bulletView in bulletViews)
            {
                    _bullets.Add(new BulletController(bulletView));            
            }
        }

        public void Update(Vector3 vector3Player, Vector3 vector3Connon)
        {
            if (Vector3.Distance(vector3Player, vector3Connon) > _shootingStation)
            {
                return;
            }
            if (_timeBetweenBulletShots > 0)
            {
                _bullets[_currentIndex].Active(false);
                _timeBetweenBulletShots -= Time.deltaTime;
            }
            else
            {
                _timeBetweenBulletShots = _delay;
                _bullets[_currentIndex].Shoot(_transform.position, _transform.up * _startingSpeed);
                _currentIndex++;
                if (_currentIndex >= _bullets.Count)
                {
                    _currentIndex = 0;
                }
            }
        }
    }
}