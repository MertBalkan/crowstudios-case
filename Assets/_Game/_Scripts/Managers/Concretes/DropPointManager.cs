using System.Collections.Generic;
using System.Linq;
using CrowStudiosCase.Controllers;
using CrowStudiosCase.Utils;
using UnityEngine;

namespace CrowStudiosCase.Managers
{
    public class DropPointManager : SingletonMonoBehaviour<DropPointManager>
    {
        [SerializeField] private List<PassengerDropPointController> dropPoints;
        private PassengerDropPointController _currentDropPoint;
        
        private void Awake()
        {
            SetupInstance();
        }

        private void Start()
        {
            dropPoints = FindObjectsOfType<PassengerDropPointController>().ToList();
            _currentDropPoint = dropPoints[0];
        }
        
    }
}
