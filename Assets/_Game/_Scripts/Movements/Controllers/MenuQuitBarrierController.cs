using UnityEngine;

namespace CrowStudiosCase
{
    public class MenuQuitBarrierController : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag.Equals("Bus"))
                GameManager.Instance.QuitGame();
        }
    }
}
