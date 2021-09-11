using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventEnemyAttack : MonoBehaviour
{
    private EnemyAttack _enemyAttack;

    private void Awake()
    {
        _enemyAttack = GetComponentInParent<EnemyAttack>();
    }

    public void AttackInAnimation()
    {
        _enemyAttack.Attack();
    }
}
