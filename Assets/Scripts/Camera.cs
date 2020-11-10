using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public float speed = 0.7f;
    GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        /*
        player = GameObject.FindWithTag("MainCharacter");

        if (player)
        {
            target = player.transform;

        }
        */
       
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<UnityEngine.Camera>().main.transform.position.y = 0.62f;

        /*
        transform.position =  Vector3.Lerp(transform.position, new Vector3(target.position.x, transform.position.y,
          target.position.z), speed * Time.deltaTime);
        */

    

    }
}
