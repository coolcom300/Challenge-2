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
    float timer;
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
        if (timer == 0)
        {   
            
            timer = Time.time;
        }
        if(Time.time - timer < 11)
        {
            
            return this;
        }
        else
        {   
            timer = 0;
            return attackState;
        }
        
    }
}
