using System;
using Fsm;
using UnityEngine;
using UnityEngine.AI;

namespace Role
{
    public class UnitBase : MonoBehaviour
    {
        public Animator Animator;
        public NavMeshAgent NavMeshAgent;

        public RoleBaseData roleData;
        public FsmSystem FsmSystem;

        private void Awake()
        {
            Animator = GetComponent<Animator>();
            NavMeshAgent = GetComponent<NavMeshAgent>();
        }

        public void Init()
        {
            roleData = new RoleBaseData(100,100,10,10,5);
            FsmSystem = new FsmSystem();
        }
    }
}
