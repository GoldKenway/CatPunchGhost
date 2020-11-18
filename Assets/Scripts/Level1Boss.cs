using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Boss : MonoBehaviour
{

    public GameObject levelHandler;
    public int BossHealth = 9;

    public GameObject Progress; // gets progress bar stuff ([something cool like progress bar being the boss healthbar)
    public Animator animator;
    bool isDead = false;
    public int Deaths;
    bool touchingPlayer;
    bool BossDead = false;


    float lastAttackTime = 3;


    public EnemyAI enemyAI;

    // Start is called before the first frame update
    void Start()
    {
        Progress = GameObject.FindWithTag("ProgressBar");
        //BossHealth = Progress.GetComponent <ProgressBar>().GetProgress();
        BossHealth = 5;
        levelHandler = GameObject.FindWithTag("levelhandler");
    }

    // Update is called once per frame
    void Update()
    {

    }
        public bool isBossDead()
        {
            if (BossHealth <= 0)
            {
                BossDead = true;
            }

        return BossDead;
        }

        public void remove()
        {
            //Destroy(gameObject, 10);
            levelHandler.GetComponent<SceneHandler>().FadeToNextLevel();
        }

        public void EndAttack()
        {
            animator.SetBool("Attack", false);
        }


}