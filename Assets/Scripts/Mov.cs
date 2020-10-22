using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using UnityEngine;

public class Mov : MonoBehaviour
{

    public Animator animator;
    private Rigidbody2D _rigidbody;
    public Transform PunchAttackPoint;

    [SerializeField] private float hspeed = 10f;
    [SerializeField] private float vspeed = 6f;
    [SerializeField] private bool canMove;

    private bool facingRight = true;

    [Range(0, 1.0f)]
    [SerializeField] float movementSmooth = 0.5f;
    private Vector3 velocity = Vector3.zero;

    public float movementSpeed = 3;
    public float attackRange = 0.5f;
    public float attackRate = 2f;
    
    public LayerMask enemyLayers;
    public int hit = 1;
    float nextAttackTime = 0f;


    private void Awake() {

        rb2D = GetComponent<Rigidbody2D>();
    }


    public void Move(float hMove, float vMove, bool jump) {

        if (canMove)
        {
            Vector3 targetVelocity = new Vector2(hMove * hspeed, vMove * vspeed);
        }

        rb2D.velocity = Vector3.SmoothDamp(rb2d.velocity,targetVelocity,ref velocity, movementSmooth);// takes in some inpute values and sets veloctiy in a smoothed out movement velocity. 

        //roate if facing the wrong way
        if (hMove > 0 && !facingRight)
        {
            flip();
        }
        else if( hMove < 0 && facingRight)
        {
            flip();
        }


    }

    private void flip() {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

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
