using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float GetMaxHP { get { return maxHP; } }
    public float GetCurrentHP { get { return currentHP; } }
    public float GetArmor { get { return armor; } }
    public float GetMoveSpeed { get { return moveSpeed; } }
    public float GetAttack { get { return attack; } }

    

    [SerializeField] protected float maxHP = 100f;
    [SerializeField] protected float currentHP;
    [SerializeField] protected float armor = 20f;
    [SerializeField] protected float moveSpeed = 10f;
    [SerializeField] protected float attack = 30f;

    public void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;

        if (currentHP <= 0) Die();
    }

    protected virtual void Die()
    {
        Debug.Log($"{gameObject.name}이(가) 사망했습니다!");
        gameObject.SetActive(false);
    }

}
