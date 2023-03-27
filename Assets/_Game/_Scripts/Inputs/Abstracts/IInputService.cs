using UnityEngine;

namespace CrowStudiosCase
{
    public interface IInputService
    {
        float TurnKeyHold { get; }
        float MoveKeyHold { get; } 
        bool BreakKeyHold { get; }
    }
}
