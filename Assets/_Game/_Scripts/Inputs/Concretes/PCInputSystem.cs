using UnityEngine;

namespace CrowStudiosCase.Inputs
{
    public class PCInputSystem : IInputService
    {
        public float TurnKeyHold => Input.GetAxis("Horizontal");
        public float MoveKeyHold => Input.GetAxis("Vertical");
        public bool BreakKeyHold => Input.GetKey(KeyCode.Space);
        public bool SwitchCameraKeyPressed => Input.GetKeyDown(KeyCode.V);
        public bool InteractKeyHold => Input.GetMouseButtonDown(0);
        public bool ResetGameKeyPressed => Input.GetKeyDown(KeyCode.R);
    }
}