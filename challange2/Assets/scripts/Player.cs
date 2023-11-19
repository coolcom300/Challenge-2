using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform trans;
    public Rigidbody body;
    public float speed;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(-Input.GetAxis("Vertical"), 0f, Input.GetAxis("Horizontal")).normalized;
        
    }

    private void FixedUpdate()
    {
        body.AddForce(direction * speed);
    }
}
