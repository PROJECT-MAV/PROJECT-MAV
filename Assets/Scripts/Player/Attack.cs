using UnityEngine;

public class Attack : MonoBehaviour
{
    르르Stat PlayerStat;
    Enemy EnemyStat;

    void Start()
    {
        EnemyStat = GetComponent<Enemy>();
        PlayerStat = GetComponent<르르Stat>();
    }

    // Update is called once per frame


   
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Enemy")
        {
            EnemyStat.TakeDamage(PlayerStat.GetAttack);
            Debug.Log("르르 공격중!");
        }
    }
    
}
