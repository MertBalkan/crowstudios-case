using System.Collections.Generic;
using CrowStudiosCase.Inputs;
using CrowStudiosCase.Movements;
using CrowStudiosCase.ScriptableObjects;
using UnityEngine;

namespace CrowStudiosCase.Controllers
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

        public IInputService InputService => _input;
        
        protected virtual  void Awake()
        {
            _input = new PCInputSystem();
            _wheelMovement = new WheelColliderMovement(this, _input, wheels, frontWheelTransforms);
        }

        protected virtual  void Start()
        {
            _wheelMovement.StartWheels();
        }

        protected virtual void Update()
        {
            _wheelMovement.UpdateWheels();
        }
    }
}
