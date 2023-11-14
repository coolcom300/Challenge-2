using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class lazerAI : MonoBehaviour
{
    public Transform trans;
    //public Rigidbody body;
    GameObject target;
    public NavMeshAgent agent;
    public float attackRot, idleRot, attackSpeed, idleSpeed;
    public bool attacking;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        //body = GetComponent<Rigidbody>();
        agent = GetComponentInParent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
    //    if (attacking)
    //    {
    //        agent.angularSpeed = attackRot;
    //        agent.speed = attackSpeed;
    //    }
    //    else
    //    {
    //        agent.angularSpeed = idleRot;
    //        agent.speed = idleSpeed;
    //    }
        target = GameObject.FindWithTag("Player");
        agent.destination = target.transform.position;
    }

    private void OnTriggerStay(Collider other)
    {
        attacking = true;
        Attack();
    }

    void Attack()
    {
        agent.angularSpeed = attackRot;
        agent.speed = attackSpeed;
    }
}
