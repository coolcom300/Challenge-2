using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CircleControllerAI : MonoBehaviour
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
        agent.enabled = true;
        target = GameObject.FindWithTag("Enemy");
        if(target == this.gameObject)
        {
            target = null;
        }
        if (target == null)
        {
            target = GameObject.FindWithTag("Player");
            agent.destination = target.transform.position;
        }
        else
        {
            agent.enabled = false;
            trans.position = target.transform.position;
        }
        
        
        
        
    }
}
