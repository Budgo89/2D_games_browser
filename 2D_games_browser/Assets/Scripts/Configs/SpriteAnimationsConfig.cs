using System;
using System.Collections.Generic;
using UnityEngine;

namespace Configs
{
    
    public enum Track
    {
        Idle = 0,
        Jump = 1,
        Run = 2
    }
    [CreateAssetMenu(fileName = "SpriteAnimationsConfig", menuName = "GameData/SpriteAnimationsConfig",
        order = 1)]
    public class SpriteAnimationsConfig : ScriptableObject
    {
        [Serializable] public class SpritesSequence
        {
            public Track Track;
            public List<Sprite> Sprites = new List<Sprite>();
        }   

        public List<SpritesSequence> Sequences = new List<SpritesSequence>();
    }
}