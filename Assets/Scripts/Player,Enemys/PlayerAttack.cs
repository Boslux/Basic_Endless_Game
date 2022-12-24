using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemy;
    void Update()
    {
        if (timeBtwAttack<=0)
        {
            if (Input.GetKey(KeyCode.K)) {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position,attackRange, whatIsEnemy);
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else {timeBtwAttack -=Time.deltaTime;}
       
    }
}
