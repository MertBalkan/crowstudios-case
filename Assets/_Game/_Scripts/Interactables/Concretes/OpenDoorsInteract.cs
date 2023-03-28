using UnityEngine;

namespace CrowStudiosCase.Interactables
{
    public class OpenDoorsInteract : MonoBehaviour, IInteractable
    {
        public System.Action OnDoorsOpened;

        public void Interact()
        {
            OnDoorsOpened?.Invoke();
        }
    }
}