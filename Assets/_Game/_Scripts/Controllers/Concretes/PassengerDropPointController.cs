using CrowStudiosCase.Enums;
using CrowStudiosCase.Managers;
using CrowStudiosCase.Utils;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace CrowStudiosCase.Controllers
{
    [RequireComponent(typeof(SphereCollider))]
    public class PassengerDropPointController : MonoBehaviour
    {
        [Header("Editor Stuffs"), Space(10)]
        [SerializeField] [Range(2, 10)]private float dropPointRadius;
        
        [FormerlySerializedAs("_notificationText")]
        [Header("Required Texts"), Space(10)]
        [SerializeField] private NotificationText notificationText;

        private BusController _busController;
        private BusDoorController _busDoorController;

        private void Awake()
        {
            _busController = FindObjectOfType<BusController>();
            _busDoorController = FindObjectOfType<BusDoorController>();
        }

        private void Start()
        {
            _busController.OnPassengersDisembark += DisembarkPassengersFromBus;
        }

        private void OnDisable()
        {
            _busController.OnPassengersDisembark -= DisembarkPassengersFromBus;
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag.Equals("Bus"))
            {
                _busController.DisembarkPassengers(this);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag.Equals("Bus"))
                notificationText.DisableText();
        }

        
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Handles.color = Color.yellow;
            Handles.DrawWireArc(transform.position, Vector3.up, transform.position, 360, dropPointRadius);
            
            // Setting up collider radius.
            GetComponent<SphereCollider>().radius = dropPointRadius;
        }
#endif
        
        private void DisembarkPassengersFromBus(PassengerDropPointController passengerDropPointController)
        {
            if (passengerDropPointController != this) return;

            var isDoorsOpen = _busDoorController.DoorMode == DoorMode.DOORS_OPEN;
            var isBusStopped = _busController.IsBusStopped;

            if (!isBusStopped)
                notificationText.DisplayPassengerDropPointNotification();
            
            if(!_busController.IsSomeoneInTheBus) return;
                
            if (isDoorsOpen && isBusStopped)
            {
                ScoreManager.Instance.IncreaseScore(_busController.CurrentCapacity * ScoreAndTimerConstants.PassengerDropPointScoreAmount);
                InGameTimeManager.Instance.AddTimer(ScoreAndTimerConstants.IncreaseTimerAwardAmount);
                
                _busController.ResetSeatCount();
            }
        }
    }
}