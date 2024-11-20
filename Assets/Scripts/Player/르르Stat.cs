using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 르르Stat : MonoBehaviour
{
    public int GetMaxJumpCount {get {return maxJumpCount; } }
    public float GetMaxHP { get { return maxHP; } }
    public float GetCurrentHP { get { return currentHP; } }
    public float GetAttack { get { return attack; } }
    public float GetArmor { get { return armor; } }
    public float GetMoveSpeed { get { return moveSpeed; } }
    public float GetJumpSpeed { get { return jumpSpeed; } }
    public float GetRotationSpeed { get { return rotationSpeed; } }

    [Header("Player Stats")]
    [SerializeField] protected float maxHP = 100f;
    [SerializeField] protected float currentHP;
    [SerializeField] protected float attack = 20f;
    [SerializeField] protected float armor = 15f;
    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected float jumpSpeed = 20f;
    [SerializeField] protected float rotationSpeed = 0.5f;
    [SerializeField] protected int maxJumpCount = 2;

    private void Start()
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
