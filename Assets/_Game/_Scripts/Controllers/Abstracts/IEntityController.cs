namespace CrowStudiosCase
{
    public interface IEntityController 
    {
        UnityEngine.Transform transform { get; }
        
        public float BreakingForce { get; }
        public float Acceleration { get; }
        public float TurnAngle { get; }
    }
}
