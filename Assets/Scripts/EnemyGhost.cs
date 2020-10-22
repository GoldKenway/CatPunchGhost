using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGhost : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 3;
    int currentHealth;
    bool isDead = false;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        Debug.Log("Enemy died!");
        isDead = true;
        animator.SetBool("isDead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

    }


}
