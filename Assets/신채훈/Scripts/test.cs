using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private Rigidbody rb;

     void OnCollisionEnter(Collision col) {
        int dir;

        if (col.collider.name == "Player") {
            if (col.collider.transform.position.x > this.transform.position.x)
                dir = -1;

            else
                dir = 1;
                
            rb.AddForce(new Vector3(dir,1,0)*6, ForceMode.Impulse);
        }
    }

    void Start() {
        rb = GetComponent<Rigidbody>();
    }
}
