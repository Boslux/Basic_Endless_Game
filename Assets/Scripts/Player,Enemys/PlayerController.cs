using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] private float jumpPower;

    public GameObject bullet;
    public int bulletAmmo=5;
    public Text Ammo;

    public GameObject sword;
    public bool canJump=true;


    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            Jump();
        }
        if (Input.GetKeyDown("s"))
        {
            Attack();
        }
        if (Input.GetKeyDown("a"))
        {
            Attack2();
        }
        Ammo.text = ""+ bulletAmmo;


    }
    public void Attack()
    {
        if (bulletAmmo>0)
        {
            animator.SetTrigger("Attack");
            Instantiate(bullet, transform.position, Quaternion.identity);
            bulletAmmo--;
        }
    }
    public void Attack2()
    {
        animator.SetTrigger("Attack2");
       
        StartCoroutine(SwordController());
    }
    public void Death()
    {
        animator.SetTrigger("Death");
        Destroy(gameObject, 0.3f);
    }

    public void Jump()
    {
        if (canJump==true)
        {
            rb.velocity = Vector2.up * jumpPower;
            animator.SetTrigger("Jump");
        }
        canJump = false;
        
    }  
    IEnumerator SwordController()
    {   //Sword obj Control 
        sword.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        sword.SetActive(false);

    }
    private void OnTriggerEnter2D(Collider2D cls)
    {
        if (cls.gameObject.CompareTag("ArrowAdd"))
        {
            bulletAmmo += 5;
            Destroy(cls.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D cls)
    {
        if (cls.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }

}
