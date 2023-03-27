namespace CrowStudiosCase.Inputs
{
    public interface IInputService
    {
        float TurnKeyHold { get; }
        float MoveKeyHold { get; } 
        bool BreakKeyHold { get; }
        public bool SwitchCameraKeyPressed { get; }
        public bool WiperKeyPressed { get; }
        public bool HornKeyPressed { get; }
    }
}
