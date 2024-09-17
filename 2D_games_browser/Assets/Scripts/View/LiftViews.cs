using PlatformerMVC.View;
using UnityEngine;

namespace Assets.Scripts.View
{
    public class LiftViews : LevelObjectView
    {
        [SerializeField] private SliderJoint2D _jointMotor2D;
        public SliderJoint2D JointMotor2D => _jointMotor2D;
    }
}

