#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections.Generic;
using CrowStudiosCase.NPCs;
using UnityEngine;

namespace CrowStudiosCase
{
    [RequireComponent(typeof(SphereCollider))]
    public class SpawnerController : MonoBehaviour
    {
        [Header("Editor Stuffs"), Space(10)]
        [SerializeField] [Range(2, 10)]private float spawnRadius;

        [Header("Spawn System"), Space(10)]
        [SerializeField] private PassengerNpc npc;
        [SerializeField] private int npcCount;
        [SerializeField] private float addTime = 0;
        [SerializeField] private bool isPassengersTaken = false;

        [SerializeField] private Transform npcParent;

        [SerializeField] private List<PassengerNpc> _npcs = new List<PassengerNpc>();
        public int NpcCount => npcCount;
        public float AddTime => addTime;
        public bool IsPassengersTaken
        {
            get => isPassengersTaken;
            set => isPassengersTaken = value;
        }
        
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Handles.color = Color.red;
            Handles.DrawWireArc(transform.position, Vector3.up, transform.position, 360, spawnRadius);
            Handles.color = Color.magenta;
            Handles.DrawDottedLine(transform.position, new Vector3(transform.position.x, transform.position.y + 6, transform.position.z), 5);
            
            // Setting up collider radius.
            GetComponent<SphereCollider>().radius = spawnRadius;
        }
#endif

        public void SpawnObject()
        {
            for (var i = 0; i < npcCount; i++)
            {
                var randomSpawnPointZ = Random.Range(-spawnRadius, spawnRadius);
                var randomSpawnPointX = Random.Range(-spawnRadius, spawnRadius);
                var position = transform.position;

                var passenger = Instantiate(npc, new Vector3(position.x + randomSpawnPointX, position.y, position.z + randomSpawnPointZ), Quaternion.identity);
                passenger.transform.SetParent(npcParent.transform);
                _npcs.Add(passenger);
            }
        }

        public void ClearList()
        {
            _npcs.ForEach(p => p.gameObject.SetActive(false));
            _npcs.Clear();
        }
    }
}