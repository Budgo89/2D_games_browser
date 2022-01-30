using System.Collections.Generic;
using UnityEngine;


namespace PlatformerMVC.View
{
    public class CanonView : MonoBehaviour
    {
        [SerializeField] private Transform _muzzleTransform;
        [SerializeField] private Transform _emitterTransform;
        [SerializeField] private List<LevelObjectView> _bullets;
        [SerializeField] private float _shootingstation;

        public Transform MuzzleTransform => _muzzleTransform;
        public Transform EmitterTransform => _emitterTransform;
        public List<LevelObjectView> Bullets => _bullets;
        public float Shootingstation => _shootingstation;
    }

}
