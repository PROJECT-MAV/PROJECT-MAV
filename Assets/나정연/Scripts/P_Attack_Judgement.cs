using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Attack_Judgement : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Dummy"))
        {
            other.GetComponent<Dummy>().TakeDamage(5);
        }
    }
}
