using CrowStudiosCase.Controllers;
using CrowStudiosCase.Enums;
using CrowStudiosCase.Inputs;
using UnityEngine;

namespace CrowStudiosCase.Components
{
    /// <summary>
    /// Include this module if you want to implement different camera modes
    /// In case of needed, you can access camera mode.
    /// </summary>
    public class CameraSwitchComponent : MonoBehaviour
    {
        [SerializeField] private Transform tpsCamera;
        [SerializeField] private Transform fpsCamera;
        
        private bool _isFpsMode = true;
        
        private IInputService _input;
        private CameraMode _cameraMode;

        public CameraMode CameraMode => _cameraMode;
        
        private void Start()
        {
            _input = GetComponent<BusController>().InputService;
        }

        public void SwitchCamera()
        {
            if (_input.SwitchCameraKeyPressed)
                _isFpsMode = !_isFpsMode;
            
            if (!_isFpsMode)
            {
                tpsCamera.gameObject.SetActive(true);
                fpsCamera.gameObject.SetActive(false);
                _cameraMode = CameraMode.TPS_CAM;
            }
            else
            {
                tpsCamera.gameObject.SetActive(false);
                fpsCamera.gameObject.SetActive(true);
                _cameraMode = CameraMode.FPS_CAM;
            }
        }
    }
}