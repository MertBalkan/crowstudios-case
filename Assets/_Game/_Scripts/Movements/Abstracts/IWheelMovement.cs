namespace CrowStudiosCase
{
    public interface IWheelMovement
    {
        void StartWheels();
        void UpdateWheels();
        void SetMotorTorque();
        void SetBreakForce();
        void TurnCar();
    }
}
