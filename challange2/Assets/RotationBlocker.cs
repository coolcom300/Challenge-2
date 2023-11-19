using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBlocker : MonoBehaviour
{
    Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        trans.rotation = Quaternion.identity;
    }
}
