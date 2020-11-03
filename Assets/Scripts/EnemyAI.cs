using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform player;
    public GameObject playerObj;
    private float moveSpeed = .6f;
    private Vector2 movement;

    //helps with flipping ghosts
    private bool facingLeft = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        playerObj = GameObject.FindWithTag("MainCharacter");
        player = playerObj.GetComponent<Transform>();
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
        moveCharacter(movement);

    }

    protected virtual void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));

        if (direction.x >= 0 && !facingLeft)
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
}
