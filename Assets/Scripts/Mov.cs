using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using UnityEngine;

public class Mov : MonoBehaviour
{


    public Animator animator;
    private Rigidbody2D _rigidbody;



    [SerializeField] public float hspeed = 1f;
    [SerializeField] public float vspeed = .5f;
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

    public int hitCount = 0;
    float lastAttackTime = 0;
    public float maxComboDelay = 0.9f;

    public bool isMoving = false;

    private void Awake()
    {

        _rigidbody = GetComponent<Rigidbody2D>();
    }



    public void Move(float hMove, float vMove, bool jump)
    {

        if (canMove)
        {
            Vector3 targetVelocity = new Vector2(hMove * hspeed, vMove * vspeed);


            _rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, targetVelocity, ref velocity, movementSmooth);// takes in some inpute values and sets veloctiy in a smoothed out movement velocity. 


            //roate if facing the wrong way
            if (hMove > 0 && !facingRight)
            {
                flip();
            }
            else if (hMove < 0 && facingRight)
            {
                flip();
            }

        }

        if (hMove != 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}






   