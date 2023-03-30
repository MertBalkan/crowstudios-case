using System;
using System.Collections.Generic;
using System.Linq;
using CrowStudiosCase.Controllers;
using CrowStudiosCase.Utils;
using UnityEngine;

namespace CrowStudiosCase
{
    public class BusStopManager : SingletonMonoBehaviour<BusStopManager>
    {
        [SerializeField] private SimpleArrowController arrow;
        [SerializeField] private List<BusStopController> busStops;

        private int _busStopCount;
        private int _totalAmountOfPassengerTaken;

        public List<BusStopController> BusStops => busStops;
        
        private void Awake()
        {
            SetupInstance();
        }

        private void Start()
        {
            busStops = FindObjectsOfType<BusStopController>().ToList();
            _busStopCount = busStops.Count;
        }

        private void Update()
        {
            // busStops.ForEach(busStopController =>
            // {
            //     if (busStopController.IsPassengersTaken)
            //     {
            //         _totalAmountOfPassengerTaken++;
            //     }     
            // });
        }
    }
}
