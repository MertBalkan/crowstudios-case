using System;
using UnityEngine;

namespace CrowStudiosCase.Interactables
{
    public class StartWipersInteractable : MonoBehaviour, IInteractable
    {
        public Action Messanger { get; set; }
        
        public void Interact()
        {
            Messanger?.Invoke();
        }
    }
}
