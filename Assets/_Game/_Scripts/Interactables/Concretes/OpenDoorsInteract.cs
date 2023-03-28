using System;
using UnityEngine;

namespace CrowStudiosCase.Interactables
{
    public class OpenDoorsInteract : MonoBehaviour, IInteractable
    {
        public Action Messanger { get; set; }

        public void Interact()
        {
            Messanger?.Invoke();
        }
    }
}