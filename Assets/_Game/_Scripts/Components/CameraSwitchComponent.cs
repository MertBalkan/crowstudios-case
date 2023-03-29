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
        [SerializeField] private Transform perspectiveCamera;
        
        private int _camIndex;
        
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
            {
                _camIndex++;
                if (_camIndex > 2) _camIndex = 0;
            }

            switch (_camIndex)
            {
                case 0:
                    EnableTpsCam();
                    break;
                case 1:
                    EnableFpsCam();
                    break;
                case 2:
                    EnablePersCam();
                    break;
            }
        }

        private void EnableFpsCam()
        {
            fpsCamera.gameObject.SetActive(false);
            tpsCamera.gameObject.SetActive(true);
            perspectiveCamera.gameObject.SetActive(false);
            _cameraMode = CameraMode.FPS_CAM;
        }

        private void EnableTpsCam()
        {
            fpsCamera.gameObject.SetActive(true);
            tpsCamera.gameObject.SetActive(false);
            perspectiveCamera.gameObject.SetActive(false);
            _cameraMode = CameraMode.TPS_CAM;
        }

        private void EnablePersCam()
        {
            perspectiveCamera.gameObject.SetActive(true);
            tpsCamera.gameObject.SetActive(false);
            fpsCamera.gameObject.SetActive(false);
            _cameraMode = CameraMode.PERSPECTIVE_CAM;
            
        }
    }
}