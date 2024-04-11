using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("comp")]
    Rigidbody2D rb;
    public Animator animator;
    public Text[] text; //index0=bullet, index1=skill
    public GameObject[] obj; //index0=bullet, index1=untouchable
    public SwordAttack sw;

    [Header("val")]
    public float jumpPower;
    public bool isLive;
    bool canAttack=true;
    public float coolDown;
    public int bulletAmmo;
    public bool canJump=true;
    private bool untouchable;
    private bool canSkillAtackle=true;
    public float skillCoolDown;


    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sw = GetComponent<SwordAttack>();
    }

    
    void Update()
    {
        Controls();
        text[0].text = ""+ bulletAmmo;

        if (skillCoolDown<=0)
            text[1].text = "Skill: Ready";
    }

    void Controls()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        if (Input.GetKeyDown(KeyCode.S))
            Attack();

        if (Input.GetKeyDown(KeyCode.D))
            StartCoroutine(Skill());
        
    }
    IEnumerator Skill()
    {
        if (canSkillAtackle)
        {
            untouchable = true;
            obj[1].SetActive(true);
            yield return new WaitForSeconds(2);
            obj[1].SetActive(false);
            untouchable = false;
            canSkillAtackle = false;
            Invoke("SkillCoolDown", skillCoolDown);
        }
    }
    void SkillCoolDown()
    {           
            canSkillAtackle=true;     
    }
    public void Attack()
    {
        if (bulletAmmo>0 &&canAttack)
        {
            animator.SetTrigger("Attack");
            Instantiate(obj[0], transform.position, Quaternion.identity);
            bulletAmmo--;
            canAttack = false;
            Invoke("CanAttack", coolDown);
        }
    }
    public void Jump()
    {
        if (canJump == true)
        {
            rb.velocity = Vector2.up * jumpPower;
            animator.SetTrigger("Jump");
        }
        canJump = false;
    }
    void CanAttack()
    {
        canAttack = true;
    }
     public void Death()
    {
        if (!untouchable)
        {
            animator.SetTrigger("Death");
            Destroy(gameObject, 0.4f);
        }

    }
    private void OnTriggerEnter2D(Collider2D cls)
    {
        //Add Arrow
        if (cls.gameObject.CompareTag("ArrowAdd"))
        {
            bulletAmmo += 5;
            Destroy(cls.gameObject);
        }
    }
    //Ground Check
    private void OnCollisionEnter2D(Collision2D cls)
    {
        if (cls.gameObject.CompareTag("Ground"))
            canJump = true;
    }
}
