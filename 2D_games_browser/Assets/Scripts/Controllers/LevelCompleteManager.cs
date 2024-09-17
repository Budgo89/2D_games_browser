using System;
using System.Collections.Generic;
using PlatformerMVC.View;
using UnityEngine;

namespace PlatformerMVC.Controllers
{
    public class LevelCompleteManager : IDisposable
    {
        private Vector3 _startPosition;
        private LevelObjectView _characterView;
        private List<LevelObjectView> _deathZones;
        private List<LevelObjectView> _winZones;

        public LevelCompleteManager(LevelObjectView characterView, List<LevelObjectView> deathZones, List<LevelObjectView> winZones, Vector3 startPosition)
        {
            _startPosition = characterView.Transform.position;
            characterView.OnLevelObjectContact += OnLevelObjectContact;

            _characterView = characterView;
            _deathZones = deathZones;
            _winZones = winZones;
            _startPosition = startPosition;
        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_deathZones.Contains(contactView))
            {
                _characterView.Transform.position = _startPosition;
            }

            if (_winZones.Contains(contactView))
            {
                _characterView.Transform.position = _startPosition;
            }
        }

        public void Dispose()
        {
            _characterView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }

}
