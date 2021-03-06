﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1AI : MonoBehaviour
{
    private Rigidbody2D rg2d;

    public GameObject Boss;

    public GameObject Player;

    public Animator animator;

    public EnemyAI enemyAI;

    bool facingR = false;

    float lastAttackTime = 3;

    private bool isDead = false;

    public GameObject levelHandler;

    public int BossHealth;

    public EnemyGhost eGhost;

    //bool BossAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        eGhost = GameObject.FindWithTag("Boss").GetComponent<EnemyGhost>();

        BossHealth = eGhost.maxHealth;

        levelHandler = GameObject.FindWithTag("levelhandler");

        rg2d = this.GetComponent<Rigidbody2D>();
        Boss = GameObject.FindWithTag("Boss");
        Player = GameObject.FindWithTag("MainCharacter");

        //animator.Play("Boss_Clap1");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastAttackTime > 2)
        {
            lastAttackTime = Time.time;
            BossAttack();
            //animator.SetBool("Attack", true);
        }

        Debug.Log(BossHealth);
        if (BossHealth <= 0)
        {
            Die();

        }


    }

    void BossAttack()
    {

        if (facingR == false)
        {
            Debug.Log("i");
            animator.SetBool("FacingRight", false);
            if (getPlayerPosition(Player.transform, Boss.transform) >= 5f)
            {
                Debug.Log("u");

                //stop the boss



                // do the clap attack

                StartCoroutine(ClapDuration(4f));

                //takes dmaage



                //wait for some time

            }
            else if (getPlayerPosition(Player.transform, Boss.transform) <= 5f && this.GetComponent<EnemyGhost>().maxHealth < 6)
            {

                // do the clap and take damage
                StartCoroutine(ShakeDuration(6f));

            }


            // do nomal punch if neither are true

            animator.SetBool("Attack", true);
        }
        else
        {
            animator.SetBool("FacingRight", true);

            if (getPlayerPosition(Player.transform, Boss.transform) >= 5f)
            {

                // do the clap attack

                StartCoroutine(ClapDuration(4f));

                //takes dmaage



                //wait for some time

            }
            else if (getPlayerPosition(Player.transform, Boss.transform) <= 5f)
            {

                // do the clap
                StartCoroutine(ShakeDuration(6f));


                //takes damage

            }


            // do nomal punch if neither are true

            animator.SetBool("Attack", true);




        }
    }


    IEnumerator ClapDuration(float Duration)
    {
        enemyAI.movement = new Vector2(0f, 0f);
        animator.SetTrigger("PlayerisClose");
        enemyAI.Attack();
        animator.Play("Clap1");
        yield return new WaitForSeconds(Duration);

        Debug.Log("trigger activated");

        animator.ResetTrigger("PlayerisClose");


    }

    IEnumerator ShakeDuration(float Duration)
    {
        enemyAI.movement = new Vector2(0f, 0f);

        animator.SetTrigger("PlayerisFar");
        enemyAI.Attack();

        yield return new WaitForSeconds(Duration);

        animator.ResetTrigger("PlayerisFar");

    }



    float getPlayerPosition(Transform player, Transform Boss)
    {
        float difference = Mathf.Abs(player.position.x - Boss.position.x);

        return difference;
    }



    void Die()
    {


        isDead = true;
        animator.SetBool("isDead", true);

        gameObject.tag = "Untagged";
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        remove();

    }

    void remove()
    {
        Debug.Log("remove called");
        Destroy(gameObject, 0);

        //bump into next level
        {
            Debug.Log("remove Boss called");
            levelHandler.GetComponent<SceneHandler>().FadeToNextLevel();
        }


    }

}

