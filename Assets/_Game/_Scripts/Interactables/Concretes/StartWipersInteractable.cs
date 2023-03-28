using System;
using UnityEngine;

namespace CrowStudiosCase.Interactables
{
    public class StartWipersInteractable : MonoBehaviour, IInteractable
    {
        public Action Messenger { get; set; }
        
        public void Interact()
        {
            Messenger?.Invoke();
        }
    }
}