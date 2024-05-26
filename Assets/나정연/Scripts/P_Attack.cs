using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class P_Attack : MonoBehaviour
{
    public enum Type { Hit, Skill };
    public Type attackType;
    public float attackSpeed;
    public Collider hitArea;
    
    public void Use()
    {
        if(attackType == Type.Hit)
        {
            StopCoroutine("Boxing1");
            StartCoroutine("Boxing1");
        }
    }

    IEnumerator Boxing1()
    {
        yield return new WaitForSeconds(0.1f);
        hitArea.enabled = true;
        yield return new WaitForSeconds(0.1f);
        hitArea.enabled = false;
    }
}
