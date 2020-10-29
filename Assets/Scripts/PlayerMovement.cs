﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animator animator;
    private Rigidbody2D _rigidbody;
    public Transform PunchAttackPoint;

    public float movementSpeed = 3;
    public float attackRange = 0.5f;
    public float attackRate = 2f;
    
    public LayerMask enemyLayers;
    public int hit = 1;
    float nextAttackTime = 0f;

    public int hitCount = 0;
    float lastAttackTime = 0;
    public float maxComboDelay = 0.9f;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I am alive!");
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("isPunching", false);
        _rigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastAttackTime > maxComboDelay)
        {
            hitCount = 0;
        }

        //Debug.Log("Hitcount is " + hitCount);

        transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * Time.deltaTime * movementSpeed;
        //if (Time.time >= nextAttackTime)
        //{
            if (Input.GetKeyDown(KeyCode.F))
            {
                //print("F has been pressed");
                lastAttackTime = Time.time;
                hitCount++;
                PunchAttack();

            if (hitCount == 1)
            {
                print("hitCount = 1");
                animator.SetBool("Punch 1", true);
                animator.SetBool("Punch 2", false);
                animator.SetBool("Punch 3", false);

                //animator.Play("Punch 1", -1, 0f);
                PunchAttack();
            }
            else if (hitCount == 2)
            {
                print("hitCount = 2");
                animator.SetBool("Punch 1", false);
                animator.SetBool("Punch 2", true);
                animator.SetBool("Punch 3", false);

                //animator.Play("Punch 1", -1, 0f);
                PunchAttack();
            }
            else if (hitCount == 3)
            {
                print("hitCount = 3");
                animator.SetBool("Punch 1", false);
                animator.SetBool("Punch 2", false);
                animator.SetBool("Punch 3", true);
                //animator.Play("Punch 1", -1, 0f);
                PunchAttack();
            }
            

            hitCount = Mathf.Clamp(hitCount, 0, 3);
                //nextAttackTime = Time.time + 1f / attackRate;
            }
        //}


    

    }

    public void return1()
    {
        Debug.Log("Return 1");

        if (hitCount >= 2)
        {
            //animator.Play("Punch 2", -1, 0f);
            animator.SetBool("Punch 2", true);

            PunchAttack();
        }
        else
        {
            animator.SetBool("Punch 1", false);
            hitCount = 0;
        }
            
    }

    public void return2()
    {
        Debug.Log("Return 2");

        if (hitCount >= 3)
        {
            //animator.Play("Punch 3", -1, 0f);
            animator.SetBool("Punch 3", true);

            PunchAttack();
        }
        else
        {
            animator.SetBool("Punch 2", false);
            hitCount = 0;
        }

    }

    public void return3()
    {
        Debug.Log("Return 3");

        animator.SetBool("Punch 1", false);
        animator.SetBool("Punch 2", false);
        animator.SetBool("Punch 3", false);

        hitCount = 0;
    }



    void PunchAttack()
    {
        //attack animation currently plays through Update

        //detect enemies in range of punch
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(PunchAttackPoint.position, attackRange, enemyLayers);

        //damage enemies
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<EnemyGhost>().TakeDamage(hit);
        }

    }


    //shows punch attack point on screen when editing
    void OnDrawGizmosSelected()
    {
        if (PunchAttackPoint == null)
            return;
        Gizmos.DrawWireSphere(PunchAttackPoint.position, attackRange);
    }


}
