using UnityEngine;

public class Attack : MonoBehaviour
{
    ����Stat PlayerStat;
    Enemy EnemyStat;

    void Start()
    {
        EnemyStat = GetComponent<Enemy>();
        PlayerStat = GetComponent<����Stat>();
    }

    // Update is called once per frame


   
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Enemy")
        {
            EnemyStat.TakeDamage(PlayerStat.GetAttack);
            Debug.Log("���� ������!");
        }
    }
    
}
