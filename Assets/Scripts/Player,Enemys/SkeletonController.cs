using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    public float MoveSpeed;
    //public Text goldText;
    // public int gold;
    Animator animator;
    private bool isLive = true;
    public GameObject arrowAdd;
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        RunLeft();
        // goldText.text = "Gold:" + gold;
    }
    public void RunLeft()
    {
        if (isLive == true)
        {
            transform.Translate(-MoveSpeed * Time.deltaTime, 0, 0);
        }
    }

    public void Death()
    {
        isLive = false;
        animator.SetTrigger("Death");
        Destroy(gameObject, 0.3f);
        Instantiate(arrowAdd, transform.position, Quaternion.identity);
    }

    /*   private void OnCollisionEnter2D(Collision2D cls)
       {

       }   
    */
    private void OnTriggerEnter2D(Collider2D cls)
    {
        if (cls.gameObject.CompareTag("Bullet"))
        {
            //add Score system
            Death();
            Destroy(cls.gameObject);
            //  gold++;
            
        }
        if (cls.gameObject.CompareTag("Sword"))
        {
            Death();
           
        }
        if (cls.gameObject.CompareTag("Player"))
        {
            cls.gameObject.GetComponent<PlayerController>().Death();
        }
    }
}
