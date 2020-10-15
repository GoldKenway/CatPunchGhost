using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov : MonoBehaviour
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
        transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * Time.deltaTime * movementSpeed;
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                print("F has been pressed");
                animator.Play("Punch Animation", -1, 0f);
                PunchAttack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }


    

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
