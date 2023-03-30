using System;
using CrowStudiosCase.Components;
using CrowStudiosCase.Managers;
using CrowStudiosCase.UIs;
using CrowStudiosCase.Utils;
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
        public bool IsBussFull => _currentCapacity >= MaxCapacity;
        public bool IsSomeoneInTheBus => _currentCapacity > 0;

        public System.Action<BusStopController> OnPassengersBoard;
        public System.Action<PassengerDropPointController> OnPassengersDisembark;

        protected override void Awake()
        {
            base.Awake();

            _rb = GetComponent<Rigidbody>();
            _cameraSwitchComponent = GetComponent<CameraSwitchComponent>();
        }

        protected override void Update()
        {
            base.Update();

            if (Input.GetKeyDown(KeyCode.J)) _currentCapacity += 20;

            if (_cameraSwitchComponent != null)
                _cameraSwitchComponent.SwitchCamera();

            DisplaySpeed();
            ControlSeats();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag.Equals("GroundObj"))
                PunishPlayer();
        }

        public void IncreaseSeatCount(int count)
        {
            _currentCapacity += count;
        }

        public void ResetSeatCount()
        {
            _currentCapacity = 0;
        }

        public void DecreaseSeatCount(int amount)
        {
            if (amount == 0) return;
            if (amount > _currentCapacity) _currentCapacity = 0;

            _currentCapacity -= amount;
        }

        public void BoardedPassengers(BusStopController whichBusStop)
        {
            OnPassengersBoard?.Invoke(whichBusStop);
        }

        public void DisembarkPassengers(PassengerDropPointController dropPointController)
        {
            OnPassengersDisembark?.Invoke(dropPointController);
        }

        private void DisplaySpeed()
        {
            _currentSpeed = CalculateSpeedByKilometer();
            busSpeedText.UpdateBusSpeedText(_currentSpeed);
        }

        private float CalculateSpeedByKilometer()
        {
            return (float)System.Math.Round(_rb.velocity.magnitude * 3.6f, 0);
        }

        private void ControlSeats()
        {
            if (IsBussFull) _currentCapacity = MaxCapacity;
        }

        private void PunishPlayer()
        {
            ScoreManager.Instance.DecreaseScore((int)_currentSpeed);
            InGameTimeManager.Instance.DecreaseTimer(ScoreAndTimerConstants.DecreaseTimerPunishmentAmount);
        }
    }
}