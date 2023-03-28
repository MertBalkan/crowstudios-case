using UnityEngine;

namespace CrowStudiosCase.Interactables
{
    public class CloseDoorsInteract : MonoBehaviour, IInteractable
    {
        public System.Action OnDoorsClosed;
        
        public void Interact()
        { 
            OnDoorsClosed?.Invoke();
        }
    }
}
