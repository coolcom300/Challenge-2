using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CircleAttack : State
{
    public Transform trans;
    //public Rigidbody body;
    /*[SerializeField]*/ GameObject target;
    NavMeshAgent agent;
    public CircleIdle idleState;
    public Spin spin;
    public float overshoot;
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
            //agent.destination = trans.position + (-trans.position + targetpos).normalized * (Vector3.Distance(trans.position, targetpos) + overshoot);
            agent.destination = targetpos;
            agent.destination = trans.position + (-trans.position + agent.destination).normalized * (Vector3.Distance(trans.position, agent.destination) + overshoot);

        }
        float distance = Vector3.Distance(trans.position,agent.destination)+overshoot;
        Debug.DrawRay(trans.position,(-trans.position + agent.destination).normalized*distance);
        
        if (agent.remainingDistance == 0)
        {
            //Debug.Log("agent" + agent.transform.position + "/ transform" + trans.position);
            //spin.spin = true;
            target = null;
            Debug.Log("leaveAttack/enterIdle");
            return idleState;
        }
        else
        {
            return this;
        }
        
    }
}
