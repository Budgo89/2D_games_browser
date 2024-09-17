using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.View;
using PlatformerMVC.View;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class LiftsManager : IDisposable
    {
        private List<LiftViews> _liftViews;
        private List<LevelObjectView> _turnTriggers;
        private JointMotor2D _jointMotor;
        private SliderJoint2D _sliderJoint;
        public LiftsManager(List<LiftViews> liftViews, List<LevelObjectView> turnTriggers)
        {
            _liftViews = liftViews;
            _turnTriggers = turnTriggers;
            foreach (var item in _liftViews)
            {
                item.OnLevelObjectContact += OnLevelObjectContact;
            }
        }

        private void OnLevelObjectContact(LevelObjectView lift)
        {
            if (_turnTriggers.Contains(lift))
            {
                _sliderJoint = _liftViews[0].JointMotor2D;
            }

            _jointMotor = _sliderJoint.motor;
            _jointMotor.motorSpeed *= -1;
            _sliderJoint.motor = _jointMotor;
        }

        public void Dispose()
        {
            foreach (var item in _turnTriggers)
            {
                item.OnLevelObjectContact -= OnLevelObjectContact;
            }
        }

    }
}
