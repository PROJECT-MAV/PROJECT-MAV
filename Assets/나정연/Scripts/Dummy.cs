using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public float maxHealth = 100f;
    private float curHealth;

    private Rigidbody rigid;
    private BoxCollider boxCollider;

    void Awake()
    {
        curHealth = maxHealth;
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }

    public void TakeDamage(int damage)
    {
        curHealth -= damage;
        Debug.Log(damage + "의 피해를 입었습니다.");
    }
}
