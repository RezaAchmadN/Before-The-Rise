using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWizardAI : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    float enemyRange;

    [SerializeField]
    float stopingDistance;

    [SerializeField]
    float moveSpeed;
    new Rigidbody2D rigidbody2D;

    [SerializeField]
    Animator animator;

    float distToPlayer;
    Vector3 defaultPosition;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        defaultPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //distance to player
        distToPlayer = Vector2.Distance(transform.position, player.position);
        
        if(distToPlayer < enemyRange && distToPlayer > stopingDistance)
        {
            //code to chase player
            ChasePlayer();
        } else
        {
            //stop chasing player
            StopChasingPlayer();
        }
    }

    void StopChasingPlayer()
    {
        if(distToPlayer > enemyRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, defaultPosition,moveSpeed*Time.deltaTime);
            animator.SetBool("PlayerApproach", false);
            if(transform.position.x < defaultPosition.x)
            {
                transform.localScale = new Vector2(-1,1);
            } else
            {
                transform.localScale = new Vector2(1,1); 
            }
        }
        
    }

    void ChasePlayer()
    {
            //player in right of enemy, move right
            transform.position = Vector2.MoveTowards(transform.position, player.position,moveSpeed*Time.deltaTime);
            animator.SetBool("PlayerApproach", true);
            if(transform.position.x < player.position.x)
            {
                transform.localScale = new Vector2(-1,1);
            } else
            {
               transform.localScale = new Vector2(1,1); 
            }
        
    }
}
