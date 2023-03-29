using CrowStudiosCase.Controllers;
using CrowStudiosCase.Movements;
using UnityEngine;

namespace CrowStudiosCase.UIs
{
    public class BusCanvas : MonoBehaviour, ILook
    {
        private DriverController _driverController;
        
        private void Awake()
        {
            _driverController = FindObjectOfType<DriverController>();
        }
        
        private void Update()
        {
            LookTarget();
        }

        public void LookTarget()
        {
            if (_driverController != null)
            {
                var targetPosition =_driverController.transform.position;
                var relativePos = targetPosition - transform.position;
                var lookRotation = Quaternion.LookRotation(new Vector3(relativePos.x * -1, 0f, relativePos.z * -1));
            
                transform.rotation = lookRotation;
            }
        }
    }
}
