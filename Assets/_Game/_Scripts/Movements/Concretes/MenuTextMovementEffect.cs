using UnityEngine;

namespace CrowStudiosCase.Movements
{
    public class MenuTextMovementEffect : MonoBehaviour
    {
        [SerializeField] private float speed = 4;
        [SerializeField] private float length = 5;
        private void Update()
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(speed * Time.time, length),
                transform.position.z);
        }
    }
}
