using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Boss : MonoBehaviour
{

    public GameObject levelHandler;
    public int BossHealth;

    public GameObject Progress; // gets progress bar stuff ([something cool like progress bar being the boss healthbar)
    public Animator animator;
    bool isDead = false;
    public int Deaths;
    bool touchingPlayer;


    float lastAttackTime = 3;


    public EnemyAI enemyAI;

    // Start is called before the first frame update
    void Start()
    {
        Progress = GameObject.FindWithTag("ProgressBar");
        BossHealth = Progress.GetComponent <ProgressBar>().GetProgress();
        levelHandler = GameObject.FindWithTag("levelhandler");
    }

    // Update is called once per frame
    void Update()
    {
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
        BossHealth -= damage;
        if (BossHealth <= 0)
        {
            Die();
        }
    }


    void Die()
    {

        Debug.Log("Enemy died!");
        isDead = true;
        animator.SetBool("isDead", true);

        gameObject.tag = "Untagged";
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        remove();

    }

    void remove()
    {
        Destroy(gameObject, 10);
        //levelHandler.GetComponent<SceneHandler>().FadeToNextLevel();
    }

    public void EndAttack()
    {
        animator.SetBool("Attack", false);
    }

}