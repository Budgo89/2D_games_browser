using System;
using System.Collections.Generic;
using Configs;
using Controller;
using Data;
using Interface;
using UnityEngine;

namespace Animators
{
    public class SpriteAnimator :IDisposable, IExecute, IAwakeExecute
    {
        private GameObject player;
        private class Animation
        {
            public Track Track;
            internal List<Sprite> Sprites;
            internal bool Loop = false;
            internal float Speed =10;
            internal float Counter;
            internal bool Sleeps;


            public void Update()
            {
                if(Sleeps) return;
                Counter += Time.deltaTime * Speed;
                if (Loop)
                {
                    while (Counter> Sprites.Count)
                    {
                        Counter -= Sprites.Count;
                    }
                }
                else if (Counter > Sprites.Count)
                {
                    Counter = Sprites.Count - 1;
                    Sleeps = true;
                }
            }
        }

        private SpriteAnimationsConfig _config;
        internal Transform _transform;
        internal SpriteRenderer _spriteRenderer;
        internal Rigidbody2D _rigidbody2D;
        internal Collider2D _collider2D;

        private Dictionary<SpriteRenderer, Animation> _activeAnimations =
            new Dictionary<SpriteRenderer, Animation>();

        public SpriteAnimator(SpriteAnimationsConfig config, GameData gameData)
        {
            _config = config;
            player = gameData.PlayerData.PlayerPrefab;
            _transform = gameData.PlayerData.Transform;
            _spriteRenderer = gameData.PlayerData.SprirteRenderer;
            _rigidbody2D = gameData.PlayerData.Rigidbody2D;
            _collider2D = gameData.PlayerData.Collider2D;
        }

        public void StartAnimation(SpriteRenderer spriteRenderer, 
            Track track, bool loop, float speed)
        {
            if (_activeAnimations.TryGetValue(spriteRenderer, out var animation))
            {
                animation.Loop = loop;
                animation.Speed = speed;
                animation.Sleeps = false;
                if (animation.Track != track)
                {
                    animation.Track = track;
                    animation.Sprites = _config.Sequences.Find(sequence => sequence.Track == track).Sprites;
                    animation.Counter = 0;
                }
            }
            else
            {
                _activeAnimations.Add(spriteRenderer, new Animation()
                {
                    Track = track,
                    Sprites = _config.Sequences.Find(sequence => sequence.Track == track).Sprites,
                    Loop = loop,
                    Speed = speed
                });
            }
        }
        public void StopAnimation(SpriteRenderer sprite)
        {
            if (_activeAnimations.ContainsKey(sprite))
            {
                _activeAnimations.Remove(sprite);
            }
        }

        public void Dispose()
        {
            _activeAnimations.Clear();
        }

        public void Execute(float deltaTime)
        {
            foreach (var animation in _activeAnimations)
            {
                animation.Value.Update();
               if (animation.Value.Counter < animation.Value.Sprites.Count)
                {
                    animation.Key.sprite = animation.Value.Sprites[(int)animation.Value.Counter];
                }
            }
        }

        public void AwakeExecute()
        {
            //SpriteRenderer spriteRenderer = player.GetComponent<SpriteRenderer>();
            StartAnimation(_spriteRenderer, Track.Idle, true, 10);
        }
    }
}