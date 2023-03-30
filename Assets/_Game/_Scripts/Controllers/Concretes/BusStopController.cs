using CrowStudiosCase.Enums;
using CrowStudiosCase.Managers;
using CrowStudiosCase.UIs;
using UnityEngine;

namespace CrowStudiosCase.Controllers
{
    public class BusStopController : MonoBehaviour
    {
        [Header("Required Texts"), Space(10)]
        [SerializeField] private PassengerCountText passengerCountText;
        [SerializeField] private NotificationText notificationText;
        [SerializeField] private SeatsText seatText;

        private SpawnerController _spawner;
        private BusDoorController _busDoorController;
        private BusController _busController;

        public bool IsPassengersTaken
        {
            get => _spawner.IsPassengersTaken;
            set => _spawner.IsPassengersTaken = value;
        }
        
        private void Awake()
        {
            _spawner = GetComponent<SpawnerController>();
            _busDoorController = FindObjectOfType<BusDoorController>();
            _busController = FindObjectOfType<BusController>();
        }

        private void Start()
        {
            _spawner.SpawnObject();
            passengerCountText.UpdatePassengerCountText(_spawner.NpcCount, _spawner.AddTime);
            
            _busController.OnPassengersBoard += TakePassengersFromBusStop;
            _busController.OnPassengersBoard += passengerCountText.DisableText;
        }

        private void OnDisable()
        {
            _busController.OnPassengersBoard -= TakePassengersFromBusStop;
            _busController.OnPassengersBoard -= passengerCountText.DisableText;
        }

        private void Update()
        {
            seatText.UpdateSeatText(_busController.CurrentCapacity, _busController.MaxCapacity);
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag.Equals("Bus"))
                _busController.BoardedPassengers(this);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag.Equals("Bus"))
                notificationText.DisableText();
        }

        private void TakePassengersFromBusStop(BusStopController busStopController)
        {
            if (busStopController != this) return;

            var isDoorsOpen = _busDoorController.DoorMode == DoorMode.DOORS_OPEN;
            var isBusStopped = _busController.IsBusStopped;
            
            if(!IsPassengersTaken)
                notificationText.DisplayBusStopNotificationText(isDoorsOpen, isBusStopped);
            
            if(_busController.IsBussFull)
                notificationText.DisplayBusFullNotification();

            if (isDoorsOpen && !IsPassengersTaken && !_busController.IsBussFull)
            {
                if (!isBusStopped) return;
                    
                IsPassengersTaken = true;
                 
                InGameTimeManager.Instance.AddTimer(_spawner.AddTime);
                ScoreManager.Instance.IncreaseScore(_spawner.ScoreAmountPerSpawnPoint);

                _busController.IncreaseSeatCount(_spawner.NpcCount);
                _spawner.ClearList();
            }
        }
    }
}