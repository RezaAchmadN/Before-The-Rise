﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMonk : MonoBehaviour
{
    public Animator animator;
    public void Destroy()
    {
        Destroy(gameObject);
    }
    public void AttackFalse()
    {
        animator.SetBool("Attack", false);
    }
}
