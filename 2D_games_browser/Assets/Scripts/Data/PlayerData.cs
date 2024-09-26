using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "GameData/PlayerData", fileName = "PlayerData")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private GameObject _playerPrefabPath;
        [SerializeField] private Transform _transform;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private Collider2D _collider2D;


        public GameObject PlayerPrefab => _playerPrefabPath;
        public float Speed => _speed;
        public Transform Transform
        {
            get => _transform;
            set => _transform = value;
        }

        public SpriteRenderer SprirteRenderer
        {
            get => _spriteRenderer;
            set => _spriteRenderer = value;
        }

        public Rigidbody2D Rigidbody2D => _rigidbody2D;
        public Collider2D Collider2D => _collider2D;
    }
}