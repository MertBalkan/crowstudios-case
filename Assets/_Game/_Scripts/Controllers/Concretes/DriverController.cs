using CrowStudiosCase.Inputs;
using CrowStudiosCase.Interactables;
using UnityEngine;

namespace CrowStudiosCase.Controllers
{
    public class DriverController : MonoBehaviour
    {
        [SerializeField] private LayerMask interactLayer;
        
        private IInputService _input;
        private Vector3 _mouseInput;
        
        private void Awake()
        {
            _input = new PCInputSystem();
        }

        private void Update()
        {
            InteractWithObjects();
        }

        private void InteractWithObjects()
        {
            _mouseInput = Input.mousePosition;
            
            var ray = Camera.main.ScreenPointToRay(_mouseInput);

            if (Physics.Raycast(ray, out var raycastHit, 10, interactLayer))
            {
                var interactableObj = raycastHit.transform.GetComponent<IInteractable>();
                
                if(interactableObj != null && _input.InteractKeyHold)
                    interactableObj.Interact();
                else
                    Debug.LogWarning("The object " + raycastHit.transform.name + " does not have a OpenDoorsInteract component.");
                
                Debug.DrawLine(Camera.main.transform.position, raycastHit.point, Color.green, 5);
            }
        }
    }
}
