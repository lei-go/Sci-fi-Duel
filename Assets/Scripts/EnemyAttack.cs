using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;

    [SerializeField] float damage;
    // Start is called before the first frame update

    public void AttackHitEvent()
    {
        if (target == null)
        {
            return;
        }
        else
        {
            Debug.Log("I (enemy) am attacking the " + target.name);
        }
    }
}
