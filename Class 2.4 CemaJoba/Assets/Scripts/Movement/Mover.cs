using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent m_Agent = null;
        [SerializeField] private Transform m_Target = null;

        private void Awake()
        {
            m_Agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            m_Agent.destination = m_Target.position;
        }
    }
}