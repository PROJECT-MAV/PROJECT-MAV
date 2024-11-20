using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    르르Stat PlayerStat;
    Enemy EnemyStat;

    void Start()
    {
        EnemyStat = GetComponent<Enemy>();
        PlayerStat = GetComponent<르르Stat>();
    }



    public void OnCollisionEnter2D(Collision2D collision)
    {
 
        if (collision.gameObject.tag == "Player")
        {
            PlayerStat.TakeDamage(EnemyStat.GetAttack);
            Debug.Log("르르 아파요ㅠㅠ");
        }
    }
}
