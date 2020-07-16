using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;

    [SerializeField] float damage;
    // Start is called before the first frame update
    private void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (target == null)
        {
            return;
        }
        else
        {
            //target.GetComponent<PlayerHealth>().TakeDamage(damage);
            target.TakeDamage(damage);
        }
    }
}
