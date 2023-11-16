using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CircleTheAI : State
{
    public Transform trans;
    //public Rigidbody body;
    [SerializeField] GameObject target;
    NavMeshAgent agent;
    public CircleIdle idleState;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        //body = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }
    public override State RunCurrentState()
    {
        agent.enabled = false;
        target = GameObject.FindWithTag("Enemy");
        trans.position = target.transform.position;
        if (target == this.gameObject)
        {
            target = null;
        }
        
        if (target == null)
        {
            return idleState;
        }
        else
        {
            return this;
        }

        

    }
}
