using System.Collections.Generic;
using UnityEngine;

namespace CrowStudiosCase
{
    public abstract class BaseCarController : MonoBehaviour, IEntityController
    {
        [SerializeField] private CarSettingsScriptableObject carSettingsSo;
        [SerializeField] private List<WheelCollider> wheels;
        [SerializeField] private Transform[] frontWheelTransforms;
        
        public float BreakingForce => carSettingsSo.breakingForce;
        public float Acceleration => carSettingsSo.acceleration;
        public float TurnAngle => carSettingsSo.turnAngle;

        private IInputService _input;
        private IWheelMovement _wheelMovement;

        private void Awake()
        {
            _input = new PCInputSystem();
            _wheelMovement = new WheelColliderMovement(this, _input, wheels, frontWheelTransforms);
        }

        private void Start()
        {
            _wheelMovement.StartWheels();
        }

        private void Update()
        {
            _wheelMovement.UpdateWheels();
        }
    }
}
