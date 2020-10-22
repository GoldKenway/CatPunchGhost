using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using UnityEngine;

public class Mov : MonoBehaviour
{

    //public Animator animator;
    private Rigidbody2D _rigidbody;


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


    private void Awake()
    {

        rb2D = GetComponent<Rigidbody2D>();
    }


    public void Move(float hMove, float vMove, bool jump)
    {

        if (canMove)
        {
            Vector3 targetVelocity = new Vector2(hMove * hspeed, vMove * vspeed);
        }

        rb2D.velocity = Vector3.SmoothDamp(rb2d.velocity, targetVelocity, ref velocity, movementSmooth);// takes in some inpute values and sets veloctiy in a smoothed out movement velocity. 

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

    private void flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}


   