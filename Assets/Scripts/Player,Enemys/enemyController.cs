using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("comp")]
    Animator animator;
    public GameObject arrowAdd;
    public PlayerController pl;

    [Header("val")]
    private bool isLive = true;
    public float moveSpeed;
    

    public void Start()
    {
        animator = GetComponent<Animator>();
        pl = GetComponent<PlayerController>();
    }
    void Update()
    {
        RunLeft();
    }
    public void RunLeft()
    {
        if (isLive == true)
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
    }

    public void Death()
    {
        if (gameObject.name != "Fire")
        {
            isLive = false; // set death
            animator.SetTrigger("Death"); //trigger to death animation
            Destroy(gameObject, 0.3f); //destroy the object

            float arrowDrop = Random.Range(0, 3);
            //İf the enemy is a skeleton create arrow and move toward the player
            if (arrowDrop==1)
                Instantiate(arrowAdd, transform.position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D cls)
    {
        if (cls.gameObject.CompareTag("Bullet"))
        {
            Death();
            Destroy(cls.gameObject);
        }
        if (cls.gameObject.CompareTag("Player"))
        {
            cls.gameObject.GetComponent<PlayerController>().Death();
            Debug.Log("öldü");

        }
    }
}
