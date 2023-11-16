using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Attacking : State
{
    public Idle idleState;
    public bool inRange;
    public Attacking AttackingState;
    public Transform trans;
    //public Rigidbody body;
    GameObject target;
    public NavMeshAgent agent;
    public float rotSpeed, moveSpeed,attackRange,timer;
    bool isattacking;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        //body = GetComponent<Rigidbody>();
        agent = GetComponentInParent<NavMeshAgent>();
        
    }
    public override State RunCurrentState()
    {
        if(timer == 0)
        {
            timer = Time.time;
        }
        target = GameObject.FindWithTag("Player");
        agent.destination = target.transform.position;
        CheckDistance();
        agent.angularSpeed = rotSpeed;
        agent.speed = moveSpeed;
        Charge();
        if (inRange == false && isattacking==false)
        {
            return idleState;
        }
        else
        {
            return this;
        }
    }
    void Charge()
    {
        if(Time.time - timer < 2)
        {
            Debug.DrawRay(trans.position+new Vector3(0,1,0), trans.forward*10,Color.white);
            Debug.Log("charge");
            isattacking = true;
        }
        else
        {
            Attack();
        }
    }

    void Attack()
    {
        if (Time.time - timer < 5)
        {
            Debug.DrawRay(trans.position + new Vector3(0, 1, 0), trans.forward * 10, Color.red);
            Debug.Log("attacking");
        }
        else
        {
            timer = 0;
            isattacking=false;
        }
    }
    void CheckDistance()
    {
        if(Vector3.Distance(target.transform.position,trans.position) <= attackRange)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }
    }
}
