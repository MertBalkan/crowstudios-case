using System;
using CrowStudiosCase.Components;
using CrowStudiosCase.UIs;
using UnityEngine;

namespace CrowStudiosCase.Controllers
{
    public sealed class BusController : BaseCarController
    {
        [SerializeField] private BusSpeedText busSpeedText;
        private CameraSwitchComponent _cameraSwitchComponent;
        private Rigidbody _rb;
        
        private float _currentSpeed;
        public float BusSpeed => _currentSpeed;
        public bool IsBusStopped => _currentSpeed < 2;
        
        protected override void Awake()
        {
            base.Awake();
            
            _rb = GetComponent<Rigidbody>();
            _cameraSwitchComponent = GetComponent<CameraSwitchComponent>();
        }

        protected override void Update()
        {
            base.Update();
            
            if(_cameraSwitchComponent != null)
                _cameraSwitchComponent.SwitchCamera();
            
            DisplaySpeed();
        }

        private float CalculateSpeedByKilometer()
        {
            return (float)Math.Round(_rb.velocity.magnitude * 3.6f, 0);
        }

        private void DisplaySpeed()
        {
            _currentSpeed = CalculateSpeedByKilometer();
            busSpeedText.UpdateBusSpeedText(_currentSpeed);
        }
    }
}