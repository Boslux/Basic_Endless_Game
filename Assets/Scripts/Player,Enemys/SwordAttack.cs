using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [Header("comp")]
    private Animator anim;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    [Header("val")]
    public float attackRange = 0.5f;


    void Start()
    {
        anim=GetComponent<Animator>();
    }

    public void Attack2()
    {
        // Çevredeki tüm Collider2D bileşenlerini al
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Çevredeki her Collider2D bileşeni için kontrol yap
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("enemy"))
            {
                EnemyController enemyController = collider.GetComponent<EnemyController>();
                if (enemyController != null)
                {
                    enemyController.Death();
                }
            }
        }
        anim.SetTrigger("Attack2");        
    }


    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
