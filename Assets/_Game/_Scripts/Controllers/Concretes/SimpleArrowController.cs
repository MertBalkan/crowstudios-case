using System.Collections.Generic;
using System.Linq;
using CrowStudiosCase.Movements;
using DG.Tweening;
using UnityEngine;

namespace CrowStudiosCase.Controllers
{
    public class SimpleArrowController : MonoBehaviour, ILook
    {
        [SerializeField] private float scaleAmount = 1.2f;
        
        private List<BusStopController> _busStops;

        private Vector3 _initialScale;
        private Vector3 _scaleTo;

        private void Start()
        {
            _busStops = FindObjectsOfType<BusStopController>().ToList();

            _initialScale = transform.localScale;
            _scaleTo = _initialScale * scaleAmount;
            
            ScaleArrow();
        }

        private void Update()
        {
            LookTarget();
        }

        public void LookTarget()
        { 
            if (GetClosestBusStop() != null)
            {
                var targetPosition = GetClosestBusStop().transform.position;
                var relativePos = targetPosition - (transform.position);
                var lookRotation = Quaternion.LookRotation(new Vector3(relativePos.x, 0, relativePos.z));
                transform.rotation = lookRotation;
            }
        }

        private void ScaleArrow()
        {
            transform.DOScale(_scaleTo, 0.3f).OnComplete(() =>
            {
                transform.DOScale(_initialScale, 0.3f).SetDelay(0.4f).OnComplete(ScaleArrow);
            });
        }

        private BusStopController GetClosestBusStop()
        {
            var minDistance = float.MaxValue;
            BusStopController closestBusStop = null;

            foreach (var busStop in _busStops)
            {
                var distance = Vector3.Distance(transform.position, busStop.gameObject.transform.position);

                if (distance < minDistance && !busStop.IsPassengersTaken)
                {
                    minDistance = distance;
                    closestBusStop = busStop.GetComponent<BusStopController>();
                }
            }
            return closestBusStop;
        }
    }
}
