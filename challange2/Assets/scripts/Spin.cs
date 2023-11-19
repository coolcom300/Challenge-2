using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public Transform trans,parTrans;
    public Rigidbody body;
    public float speed;
    public bool spin;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        //parTrans = GetComponentInParent<Transform>();
        body = GetComponent<Rigidbody>();
        //body.AddTorque(trans.up * speed);
    }

    // Update is called once per frame
    void Update()
    {
        trans.position = parTrans.transform.position;
        if (spin)
        {
            body.angularVelocity = trans.up*speed;
        }
        else
        {

            body.angularVelocity = Vector3.zero;
        }
    }
}
