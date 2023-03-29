using UnityEditor;
using UnityEngine;

namespace CrowStudiosCase.Controllers
{
    [RequireComponent(typeof(SphereCollider))]
    public class PassengerDropPointController : MonoBehaviour
    {
        [Header("Editor Stuffs"), Space(10)]
        [SerializeField] [Range(2, 10)]private float dropPointRadius;
        
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Handles.color = Color.yellow;
            Handles.DrawWireArc(transform.position, Vector3.up, transform.position, 360, dropPointRadius);
            
            // Setting up collider radius.
            GetComponent<SphereCollider>().radius = dropPointRadius;
        }
#endif
    }
}