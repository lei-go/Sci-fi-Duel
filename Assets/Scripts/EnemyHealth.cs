using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health = 100f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        //GetComponent<EnemyAI>().OnDamageTaken(); //not the best way, use broadcast
        BroadcastMessage("OnDamageTaken");
    }
}
