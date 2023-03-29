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

        private int _currentCapacity = 0;
        private float _currentSpeed;
        
        public float BusSpeed => _currentSpeed;
        public bool IsBusStopped => _currentSpeed < 2;
        public int CurrentCapacity => _currentCapacity;

        public System.Action<BusStopController> OnPassengersEntered;
        
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

        private void DisplaySpeed()
        {
            _currentSpeed = CalculateSpeedByKilometer();
            busSpeedText.UpdateBusSpeedText(_currentSpeed);
        }

        private float CalculateSpeedByKilometer()
        {
            return (float)Math.Round(_rb.velocity.magnitude * 3.6f, 0);
        }

        public void IncreaseSeatCount(int count)
        {
            _currentCapacity += count;
        }

        public void EnteredPassengers(BusStopController whichBusStop)
        {
            OnPassengersEntered?.Invoke(whichBusStop);
        }
    }
}