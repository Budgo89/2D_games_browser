using UnityEngine;
using System.IO;
using Configs;

namespace Data
{
    [CreateAssetMenu(fileName = "GameData", menuName = "GameData/GameData", order = 0)]
    public class GameData : ScriptableObject
    {
        private const string _gameDataFolder = "GameData/";
        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _animationPath;

        private PlayerData _playerData;
        private SpriteAnimationsConfig _spriteAnimationsConfig;

        public PlayerData PlayerData
        {
            get
            {
                if (_playerData == null) 
                    _playerData = Load<PlayerData>(_gameDataFolder + _playerDataPath);
                return _playerData;
            }
        }
        public SpriteAnimationsConfig SpriteAnimationsConfig
        {
            get
            {
                if (_spriteAnimationsConfig == null)
                    _spriteAnimationsConfig = Load<SpriteAnimationsConfig>(_gameDataFolder + _animationPath);
                return _spriteAnimationsConfig;
            }
        }

        private T LoadPath<T>(string path) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(path, null));
        private T Load<T>(string resourcesPath) where T : Object => Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));

    }
}