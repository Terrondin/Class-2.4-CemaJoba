using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent m_Agent = null;
        [SerializeField] private Animator m_Animator = null;

        private void Awake()
        {
            m_Agent = GetComponent<NavMeshAgent>();
            m_Animator = GetComponent<Animator>();
        }

        private void Update()
        {
            MoveTo();

            UpdateAnimations();
        }

        public void MoveTo()
        {
            RaycastHit hit;

            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);

            if (hasHit == true)
            {
                if (Input.GetMouseButton(0))
                {
                    m_Agent.destination = hit.point;

                    Debug.DrawRay(GetMouseRay().origin, GetMouseRay().direction * 100, Color.red);
                }
            }
        }

        public Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        private void UpdateAnimations()
        {
            m_Animator.SetFloat("Forward", m_Agent.velocity.magnitude);
        }
    }
}