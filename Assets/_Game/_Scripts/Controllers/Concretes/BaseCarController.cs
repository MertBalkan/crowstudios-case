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

        protected IInputService input;
        protected IWheelMovement wheelMovement;

        public IInputService InputService => input;
        
        protected virtual  void Awake()
        {
            input = new PCInputSystem();
            wheelMovement = new WheelColliderMovement(this, input, wheels, frontWheelTransforms);
        }

        protected virtual  void Start()
        {
            wheelMovement.StartWheels();
        }

        protected virtual void Update()
        {
            wheelMovement.UpdateWheels();
        }
    }
}
