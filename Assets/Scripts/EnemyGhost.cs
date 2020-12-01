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

    GameObject Boss1;


    float lastAttackTime = 3;


    public EnemyAI enemyAI;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        Boss1 = GameObject.FindWithTag("Boss");
        levelHandler = GameObject.FindWithTag("levelhandler");
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
        Boss1.GetComponent<Level1Boss>().BossDead = true;

            if (Boss1.GetComponent<Level1Boss>().BossDead == true)
        {
            Debug.Log("remove Boss called");
            levelHandler.GetComponent<SceneHandler>().FadeToNextLevel();
        }
    }

    public void EndAttack()
    {
        animator.SetBool("Attack", false);
    }

   



}
