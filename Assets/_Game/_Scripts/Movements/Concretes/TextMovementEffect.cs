using DG.Tweening;
using UnityEngine;

namespace CrowStudiosCase.Movements
{
    public class TextMovementEffect : MonoBehaviour
    {
        [SerializeField] private float speed = 4;
        [SerializeField] private float length = 5;
        [SerializeField] private float offset;
        
        private void Update()
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(speed * Time.time, length) + offset,
                transform.position.z);
        }
    }
}
