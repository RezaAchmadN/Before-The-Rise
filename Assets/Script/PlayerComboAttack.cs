using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComboAttack : MonoBehaviour
{
    public Animator animator;
    public int noOfClick = 0;
    public float maxComboDelay = 0.9f;
    float lastClickedTime = 0;

    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;
    public int attackDamage = 40;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClick = 0;
        }

        if(Input.GetButtonDown("Fire1") && animator.GetInteger("JumpState") == 0 && animator.GetFloat("Speed") == 0)
        {
            lastClickedTime = Time.time;
            noOfClick++;
            if(noOfClick == 1)
            {
                animator.SetBool("Attack1", true);
                Attack();
            }
            noOfClick = Mathf.Clamp(noOfClick, 0, 3);
        }
    }

    public void return1()
    {
        if(noOfClick >= 2)
        {
            animator.SetBool("Attack2", true);
            Attack();
        }
        else
        {
            animator.SetBool("Attack1", false);
            noOfClick = 0;
        }
    }
    
    public void return2()
    {
        if(noOfClick >= 3)
        {
            animator.SetBool("Attack3", true);
            Attack();
        }
        else
        {
            animator.SetBool("Attack2", false);
            noOfClick = 0;
        }
    }
    
    public void return3()
    {
        animator.SetBool("Attack1", false);
        animator.SetBool("Attack2", false);
        animator.SetBool("Attack3", false);
        noOfClick = 0;
        
    }

    void Attack()
    {
        //Detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void onDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
