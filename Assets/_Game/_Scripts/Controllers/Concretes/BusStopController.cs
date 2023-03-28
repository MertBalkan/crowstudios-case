using System;
using CrowStudiosCase.Enums;
using CrowStudiosCase.UIs;
using UnityEngine;

namespace CrowStudiosCase.Controllers
{
    public class BusStopController : MonoBehaviour
    {
        [SerializeField] private PassengerCountText passengerCountText;
        
        private SpawnerController _spawner;
        private BusDoorController _busDoorController;
        
        private void Awake()
        {
            _spawner = GetComponent<SpawnerController>();
            _busDoorController = FindObjectOfType<BusDoorController>();
        }

        private void Start()
        {
            _spawner.SpawnObject();
        }

        private void Update()
        {
            passengerCountText.UpdatePassengerCountText(_spawner.NpcCount);
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag.Equals("Bus"))
            {
                Debug.Log(_busDoorController.DoorMode.ToString());
                
                switch (_busDoorController.DoorMode)
                {
                    case DoorMode.DOOR_CLOSE:
                        Debug.LogWarning("OPEN DOORS BEFORE TAKE PASSENGERS");
                        break;
                    case DoorMode.DOORS_OPEN:
                        _spawner.ClearList();
                        break;
                }
            }
        }
    }
}