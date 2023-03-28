using CrowStudiosCase.Controllers;
using CrowStudiosCase.Movements;
using UnityEngine;

namespace CrowStudiosCase.NPCs
{
    public class PassengerNpc : MonoBehaviour, ILook
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
                var lookRotation = Quaternion.LookRotation(new Vector3(relativePos.x, 0f, relativePos.z));
                
                transform.rotation = lookRotation;
            }
        }
    }
}
