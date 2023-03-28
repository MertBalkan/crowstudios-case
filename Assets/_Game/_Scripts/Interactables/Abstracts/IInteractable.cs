namespace CrowStudiosCase.Interactables
{
    public interface IInteractable
    {
        void Interact();
        System.Action Messenger { get; set;  }
    }
}
