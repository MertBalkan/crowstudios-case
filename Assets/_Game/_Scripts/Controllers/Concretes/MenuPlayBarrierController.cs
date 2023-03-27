using UnityEngine;

namespace CrowStudiosCase.Controllers
{
    public class MenuPlayBarrierController : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag.Equals("Bus"))
                GameManager.Instance.LoadNextScene();
        }
    }
}
