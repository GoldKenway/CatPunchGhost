using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGhost : MonoBehaviour
{
    public GameObject Progress;
    public Animator animator;
    public int maxHealth = 3;
    int currentHealth = 3;
    bool isDead = false;
    private int Deaths;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Progress = GameObject.FindWithTag("ProgressBar");

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
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

        Deaths++;
        Progress.GetComponent<ProgressBar>().SetProgress(Deaths);

        remove();

    }

    void remove()
    {
        Destroy(gameObject, 0);
    }

}
