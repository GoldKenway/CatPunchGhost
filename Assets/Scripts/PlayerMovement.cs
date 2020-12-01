using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;

    private GameObject Ghost;
    private Rigidbody2D Gphysics; 

    public Animator animator;
    private Rigidbody2D _rigidbody;
    public Transform PunchAttackPoint;

    public float movementSpeed = 3;
    public float attackRange = 0.5f;
    public float attackRate = 2f;
    
    public LayerMask enemyLayers;
    public int hit = 1;
    float nextAttackTime = 0f;

    public int hitCount = 0;
    float lastAttackTime = 0;
    public float maxComboDelay = 0.9f;




    public Mov movement;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("isPunching", false);
        _rigidbody = GetComponent<Rigidbody2D>();
        movement = GetComponent<Mov>();
    }

    // Update is called once per frame
    void Update()
    {


        if(Time.time - lastAttackTime > maxComboDelay)
        {
            hitCount = 0;
        }


        transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * Time.deltaTime * movementSpeed;

        if (Input.GetKeyDown(KeyCode.F))
        {
            //player.GetComponent<Mov>().hspeed = 0;
            //player.GetComponent<Mov>().vspeed = 0;
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            movement.canMove = false;

            lastAttackTime = Time.time;
            hitCount++;

            print("hitCount = " + hitCount);
            movement.isMoving = false;
            animator.SetBool("isMoving", false);
            animator.SetBool("Punch 1", true);

            PunchAttack();

            hitCount = Mathf.Clamp(hitCount, 0, 3);



        }
        else
        {
            player.GetComponent<Mov>().hspeed = 2;
            player.GetComponent<Mov>().vspeed = 1;

        }
    


    

    }

    public void return1()
    {
        Debug.Log("Return 1");

        if (hitCount >= 2)
        {
            //animator.Play("Punch 2", -1, 0f);
            animator.SetBool("Punch 2", true);

            PunchAttack();
            animator.SetBool("Punch 1", false);

        }
        else
        {
            animator.SetBool("Punch 1", false);
            hitCount = 0;
            movement.canMove = true;

        }

    }

    public void return2()
    {
        Debug.Log("Return 2");

        if (hitCount % 3 == 0 && hitCount >=1)
        {
            //animator.Play("Punch 3", -1, 0f);
            animator.SetBool("Punch 3", true);

            UpperCut();
        }
        else
        {
            animator.SetBool("Punch 1", false);
            animator.SetBool("Punch 2", false);
            hitCount = 0;
            movement.canMove = true;

        }

    }

    public void return3()
    {
        Debug.Log("Return 3");

        animator.SetBool("Punch 1", false);
        animator.SetBool("Punch 2", false);
        animator.SetBool("Punch 3", false);

        hitCount = 0;
        movement.canMove = true;

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
            //FindObjectOfType<HitFeel>().TimeStop(0.17f);




            enemy.GetComponent<EnemyGhost>().TakeDamage(hit);

        }

    }

    void UpperCut()
    {

        Ghost = GameObject.FindWithTag("Enemy");
        Gphysics = Ghost.GetComponent<Rigidbody2D>();

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(PunchAttackPoint.position, attackRange, enemyLayers);

        

        //damage enemies
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("UpperCut!");

            Vector3 arc = new Vector3(500,300, 0);

            Gphysics.AddForce(arc,ForceMode2D.Impulse);
            //Enemy.AddForce(xdirectoin)

            StartCoroutine(TempGravity(.7f, Gphysics));

        }

    }

    IEnumerator TempGravity(float seconds, Rigidbody2D enemy)
    {
        enemy.gravityScale = 1f;

        yield return new WaitForSecondsRealtime(seconds);

        enemy.gravityScale = 0f;

    }


    //shows punch attack point on screen when editing
    void OnDrawGizmosSelected()
    {
        if (PunchAttackPoint == null)
            return;
        Gizmos.DrawWireSphere(PunchAttackPoint.position, attackRange);
    }
}