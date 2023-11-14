using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Cir : MonoBehaviour
{
    public Transform trans;
    //public Rigidbody body;
    [SerializeField] GameObject target;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        //body = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.transform.position;
    }

}
