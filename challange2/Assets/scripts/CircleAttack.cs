using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CircleAttack : State
{
    public Transform trans;
    //public Rigidbody body;
    [SerializeField] GameObject target;
    NavMeshAgent agent;
    public CircleIdle idleState;
    public Spin spin;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        //body = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }
    public override State RunCurrentState()
    {
        agent.enabled = true;
        spin.spin = false;
        if(target == null)
        {
            target = GameObject.FindWithTag("Player");
            Vector3 targetpos = target.transform.position;
            //float targetlength = Vector3.Distance(trans.position, targetpos) + 3;
            //targetpos = (targetpos - trans.position).normalized*targetlength;
            agent.destination = (-trans.position + agent.destination).normalized * (Vector3.Distance(trans.position, agent.destination) + 3);
            agent.destination = targetpos;
            
        }
        float distance = Vector3.Distance(trans.position,agent.destination)+3;
        Debug.DrawRay(trans.position,(-trans.position + agent.destination).normalized*distance);
        
        if (agent.remainingDistance == 0)
        {
            spin.spin = true;
            target = null;
            return idleState;
        }
        else
        {
            return this;
        }
        
    }
}
