using UnityEngine;

namespace CrowStudiosCase
{
    public class PCInputSystem : IInputService
    {
        public float TurnKeyHold => Input.GetAxis("Horizontal");
        public float MoveKeyHold => Input.GetAxis("Vertical");
        public bool BreakKeyHold => Input.GetKey(KeyCode.Space);
    }
}
