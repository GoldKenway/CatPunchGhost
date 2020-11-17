using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform player;
    public GameObject playerObj;
    public float moveSpeed = .6f;
    private Vector2 movement;
    public Animator animator;


    public Transform nearEnemyTracker;
    public Transform AttackPoint;
    public float nearPlayerRange = 1f;
    public float attackRange = .75f;
    public int damage;


    public LayerMask character;
    public CharacterStats charStats;

    //helps with flipping ghosts
    private bool facingLeft = true;

    /*protected override moveCharacter()
    {
        //Enemy Movement that we want to be different for whatever reason

    }
*/

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        playerObj = GameObject.FindWithTag("MainCharacter");
        player = playerObj.GetComponent<Transform>();
        charStats = GameObject.FindWithTag("MainCharacter").GetComponent<CharacterStats>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        //make it follow you
        //move it
            direction.Normalize();
            movement = direction;
        
        
    }

    private void FixedUpdate()
    {
        Vector3 direction = player.position - transform.position;
        if (Mathf.Abs(direction.x) > 1.7 || Mathf.Abs(direction.y) > 2)
        {
            moveCharacter(movement);

        }

    }

    protected virtual void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));

        if (direction.x > 0 && facingLeft)
        {
            flip();
        }
        else if (direction.x < 0 && facingLeft)
        {
            flip();
        }

        
        
    }

    private void flip()
    {
        facingLeft = !facingLeft;
        transform.Rotate(0, 180, 0);
    }


    void OnDrawGizmosSelected()
    {
        //if (nearEnemyTracker == null)
        //    return;
        Gizmos.DrawWireSphere(nearEnemyTracker.position, nearPlayerRange);
        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);

    }

    public void Attack()
    {
        Collider2D[] playableCharacter = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, character);
        animator.SetBool("Attack", true);
        
        foreach(Collider2D MainCharacter in playableCharacter)
        {
            Debug.Log("Ghost hit player.");
            charStats.characterHit(damage);

        }

    }

    public bool isTouching()
    {
        Collider2D[] touching = Physics2D.OverlapCircleAll(nearEnemyTracker.position, nearPlayerRange, character);
        if (touching.Length > 0)
            return true;
        return false;
    }

}
