using CrowStudiosCase.Enums;
using CrowStudiosCase.Interactables;
using DG.Tweening;
using UnityEngine;

namespace CrowStudiosCase.Controllers
{
    public class BusDoorController : MonoBehaviour
    {
        [Header("Door Transforms"), Space(10)]
        [SerializeField] private Transform fDoor1;
        [SerializeField] private Transform fDoor2;
        [SerializeField] private Transform bDoor1;
        [SerializeField] private Transform bDoor2;
        
        [Header("Door Rotate 'Y' Coordinates"), Space(10)]
        [SerializeField] private float fDoor1RotatePoint = 180;
        [SerializeField] private float fDoor2RotatePoint = 0;
        [SerializeField] private float bDoor1RotatePoint;
        [SerializeField] private float bDoor2RotatePoint;

        [Header("Duration Value"), Space(10)] 
        [SerializeField] private float duration;

        [Header("Duration Mode"), Space(10)] 
        [SerializeField] private DoorMode doorMode;

        private OpenDoorsInteract _openDoors;
        private CloseDoorsInteract _closeDoors;

        public DoorMode DoorMode => doorMode;

        private void Awake()
        {
            _openDoors = FindObjectOfType<OpenDoorsInteract>();
            _closeDoors = FindObjectOfType<CloseDoorsInteract>();
        }

        private void Start()
        {
            _openDoors.Messenger += OpenDoors;
            _closeDoors.Messenger += CloseDoors;
        }

        private void OnDisable()
        {
            _openDoors.Messenger -= OpenDoors;
            _closeDoors.Messenger -= CloseDoors;
        }

        public void OpenDoors()
        {
            fDoor1.transform.DOLocalRotate(new Vector3(0, fDoor1RotatePoint, 0), duration);
            fDoor2.transform.DOLocalRotate(new Vector3(0, fDoor2RotatePoint, 0), duration);
            bDoor1.transform.DOLocalRotate(new Vector3(0, bDoor1RotatePoint, 0), duration);
            bDoor2.transform.DOLocalRotate(new Vector3(0, bDoor2RotatePoint, 0), duration);

            doorMode = DoorMode.DOORS_OPEN;
        }

        public void CloseDoors()
        {
            fDoor1.transform.DOLocalRotate(new Vector3(0, 90, 0), duration);
            fDoor2.transform.DOLocalRotate(new Vector3(0, 90, 0), duration);
            bDoor1.transform.DOLocalRotate(new Vector3(0, 90, 0), duration);
            bDoor2.transform.DOLocalRotate(new Vector3(0, 90, 0), duration);
            
            doorMode = DoorMode.DOOR_CLOSE;
        }
    }
}