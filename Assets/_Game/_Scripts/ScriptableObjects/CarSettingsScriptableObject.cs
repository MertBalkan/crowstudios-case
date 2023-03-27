using UnityEngine;

namespace CrowStudiosCase
{
    [CreateAssetMenu(order = 1, menuName = "CrowStudiosCase/Car Setting", fileName = "New Car Setting")]
    public class CarSettingsScriptableObject : ScriptableObject
    {
        [Header("Movement Settings"), Space(10)]
        public float breakingForce;
        public float acceleration;
        public float turnAngle; 
    }
}

