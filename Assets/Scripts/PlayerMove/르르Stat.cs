using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 르르Stat : MonoBehaviour
{
    public float MaxHP { get { return maxHP; } }
    public float CurrentHP { get { return currentHP; } }
    public float Armor { get { return armor; } }
    public float MoveSpeed { get { return moveSpeed; } }
    public float Attack { get { return attack; } }



    [SerializeField] protected float maxHP;
    [SerializeField] protected float currentHP;
    [SerializeField] protected float armor;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float attack;

    public void OnUpdateStat(float maxHP, float currentHP, float armor, float moveSpeed, float attack)
    {
        this.maxHP = maxHP;
        this.currentHP = currentHP;
        this.armor = armor;
        this.moveSpeed = moveSpeed;
        this.attack = attack;
    }

}
