using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGhost : MonoBehaviour
{
    public GameObject Progress;
    public Animator animator;
    public int maxHealth = 3;
    int currentHealth;
    bool isDead = false;
    public int Deaths;
    bool touchingPlayer;
    public GameObject levelHandler;
    float stunTime = 0.3f;

    //getting the script
    GameObject Enemy;


    GameObject Boss1;


    float lastAttackTime = 3;


    public EnemyAI enemyAI;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        Boss1 = GameObject.FindWithTag("Boss");
        levelHandler = GameObject.FindWithTag("levelhandler");

        Enemy = GameObject.FindWithTag("Enemy");

    }

    // Update is called once per frame
    void Update()
    {


        Progress = GameObject.FindWithTag("ProgressBar");
        if (enemyAI.isTouching())
        {
            if (Time.time - lastAttackTime > 2)
            {
                lastAttackTime = Time.time;
                enemyAI.Attack();
                animator.SetBool("Attack", true);
            }
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            enemyAI.Attack();
            animator.SetBool("Attack", true);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        ComboCounter.hitCount += 1;
        ComboCounter.currentTime = 3f;
        
    }


    void Die()
    {

        Debug.Log("Enemy died!");
        isDead = true;
        animator.SetBool("isDead", true);

        gameObject.tag = "Untagged";
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        Progress.GetComponent<ProgressBar>().EnemiesKilled++;
        Progress.GetComponent<ProgressBar>().SetProgress(Progress.GetComponent<ProgressBar>().EnemiesKilled);

        remove();

    }

    void remove()
    {
        Debug.Log("remove called");
        Destroy(gameObject, 0);
    }

    public void EndAttack()
    {
        animator.SetBool("Attack", false);
    }

    public void Stun()
    {
       
        StartCoroutine(StunTimer());

    }


    IEnumerator StunTimer() {

        Enemy.GetComponent<EnemyAI>().enabled = false;
        yield return null;


        yield return new WaitForSecondsRealtime(stunTime);
        Enemy.GetComponent<EnemyAI>().enabled = true;


    }


}
