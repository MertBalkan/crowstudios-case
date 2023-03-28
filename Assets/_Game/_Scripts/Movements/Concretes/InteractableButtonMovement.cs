using CrowStudiosCase.Interactables;
using DG.Tweening;
using UnityEngine;

namespace CrowStudiosCase.Movements
{
    public class InteractableButtonMovement : MonoBehaviour
    {
        private float _currPos = 0.05f;
        
        private IInteractable _interactable;

        private void Awake()
        {
            _interactable = GetComponentInParent<IInteractable>();
        }

        private void Start()
        {
            _interactable.Messenger += MoveButton;
        }

        private void OnDisable()
        {
            _interactable.Messenger -= MoveButton;
        }

        private void MoveButton()
        {
            transform.DOLocalMoveY(_currPos -= 0.02f, 0.5f).OnComplete(() =>
            {
                _currPos = 0.05f;
                transform.DOLocalMoveY(_currPos, 0.5f);
            });
        }
    }
}