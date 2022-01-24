using Data;
using UnityEngine;

namespace Assets.Scripts.Initializer
{
    public class PlayerInitializer
    {
        private readonly GameObject _player;

        public Transform Player => _player.transform;

        public PlayerInitializer(GameData gameData)
        {
            var playerPrefab = gameData.PlayerData.PlayerPrefab;
            _player = Object.Instantiate(playerPrefab);
        }
    }
}
