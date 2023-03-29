using System;
using CrowStudiosCase.Enums;
using CrowStudiosCase.UIs;
using UnityEngine;

namespace CrowStudiosCase.Controllers
{
    public class BusStopController : MonoBehaviour
    {
        [SerializeField] private PassengerCountText passengerCountText;
        [SerializeField] private NotificationText notificationText;
        
        private SpawnerController _spawner;
        private BusDoorController _busDoorController;
        private BusController _busController;

        private bool _isPassengersTaken = false;

        public bool IsPassengersTaken => _isPassengersTaken;
        
        private void Awake()
        {
            _spawner = GetComponent<SpawnerController>();
            _busDoorController = FindObjectOfType<BusDoorController>();
            _busController = FindObjectOfType<BusController>();
        }

        private void Start()
        {
            _spawner.SpawnObject();
            passengerCountText.UpdatePassengerCountText(_spawner.NpcCount);
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag.Equals("Bus"))
            {
                notificationText.EnableText();
                TakePassengersFromBusStop();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag.Equals("Bus"))
            {
                notificationText.DisableText();
            }
        }

        private void TakePassengersFromBusStop()
        {
            if(!_isPassengersTaken)
                notificationText.DisplayNotificationText(_busDoorController.DoorMode == DoorMode.DOORS_OPEN, _busController.IsBusStopped);

            if (_busDoorController.DoorMode == DoorMode.DOORS_OPEN)
            {
                if (!_busController.IsBusStopped) return;
                    
                _isPassengersTaken = true;
                _spawner.ClearList();
                passengerCountText.DisableText();
            }
        }
    }
}