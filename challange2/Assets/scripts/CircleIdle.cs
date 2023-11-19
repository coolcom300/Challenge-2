using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CircleIdle : State
{
    public Transform trans;
    //public Rigidbody body;
    [SerializeField] GameObject target;
    NavMeshAgent agent;
    public CircleAttack attackState;
    public CircleTheAI circleState;
    public Spin spin;
    public float timer,attackTime;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        //body = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }
    public override State RunCurrentState()
    {
        if (timer == 0)
        {   
            
            timer = Time.time;
        }
        agent.enabled = true;
        spin.spin = true;
        target = GameObject.FindWithTag("Enemy");
        if (target == this.gameObject)
        {
            target = null;
        }
        if (target != null)
        {
            return circleState;
        }
        target = GameObject.FindWithTag("Player");
        //Vector3.RotateTowards(trans.);
        
        if(Time.time - timer < attackTime)
        {
            
            return this;
        }
        else
        {   
            Debug.Log("leaveIdle/enterAttack");
            timer = 0;
            spin.spin = false;
            return attackState;
            
        }
        
    }
}
