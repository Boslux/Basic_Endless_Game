using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyController : MonoBehaviour
{
    public Transform playerPos;
    public float speed;
    Animator animator;
    private bool isLive = true;


    void Start()
    {
        animator=GetComponent<Animator>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void Update()
    {
        FollowPlayer();
    }
    public void FollowPlayer()
    {
        if (isLive==true)
        {
            Vector2 enemyFollow = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
            transform.position = enemyFollow;
        }
     
    }

    public void Death()
    {
        Destroy(gameObject, 0.3f);
        isLive = false;
        animator.SetTrigger("Death");
    }
    private void OnTriggerEnter2D(Collider2D cls)
    {
        if (cls.gameObject.CompareTag("Player"))
        {
            cls.gameObject.GetComponent<PlayerController>().Death();
        }
        if (cls.gameObject.CompareTag("Bullet"))
        {
            Death();     
        }
        if (cls.gameObject.CompareTag("Sword"))
        {
            Death();  
        }
    }
}
