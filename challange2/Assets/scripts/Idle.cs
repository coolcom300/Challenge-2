using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle : State
{
    public Attacking AttackingState;
    public bool inRange;
    public Transform trans;
    //public Rigidbody body;
    GameObject target;
    public NavMeshAgent agent;
    public float rotSpeed, moveSpeed, attackRange;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        //body = GetComponent<Rigidbody>();
        agent = GetComponentInParent<NavMeshAgent>();
    }
    public override State RunCurrentState()
    {
        target = GameObject.FindWithTag("Player");
        agent.destination = target.transform.position;
        CheckDistance();
        agent.angularSpeed = rotSpeed;
        agent.speed = moveSpeed;
        if (inRange)
        {
            Debug.Log("swaped");
            return AttackingState;
        }
        else
        {
            return this;
        }

    }

    void CheckDistance()
    {
        if (Vector3.Distance(target.transform.position, trans.position) <= attackRange)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Player")
        //{
        //    inRange = true;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.tag == "Player")
        //{
        //    inRange = false;
        //}
    }
}
