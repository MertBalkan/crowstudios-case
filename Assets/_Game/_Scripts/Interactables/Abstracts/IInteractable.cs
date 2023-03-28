namespace CrowStudiosCase.Interactables
{
    public interface IInteractable
    {
        void Interact();
        System.Action Messanger { get; set;  }
    }
}
