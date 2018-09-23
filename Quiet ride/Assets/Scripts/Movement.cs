using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    void FixedUpdate()
    {
        transform.position += Vector3.forward * Time.deltaTime;
    }
}
