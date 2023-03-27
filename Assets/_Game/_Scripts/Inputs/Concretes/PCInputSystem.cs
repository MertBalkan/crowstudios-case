using UnityEngine;

namespace CrowStudiosCase.Inputs
{
    public class PCInputSystem : IInputService
    {
        public float TurnKeyHold => Input.GetAxis("Horizontal");
        public float MoveKeyHold => Input.GetAxis("Vertical");
        public bool BreakKeyHold => Input.GetKey(KeyCode.Space);
        public bool SwitchCameraKeyPressed => Input.GetKeyDown(KeyCode.V);
        public bool WiperKeyPressed => Input.GetKeyDown(KeyCode.E);
        public bool HornKeyPressed => Input.GetKeyDown(KeyCode.T);
    }
}