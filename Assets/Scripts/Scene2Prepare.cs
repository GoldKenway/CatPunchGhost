using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2Prepare : MonoBehaviour
{
    GameObject player;
    GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("MainCharacter");
        camera = GameObject.FindWithTag("MainCamera");

        Vector3 newPos = new Vector3(-2.69f, -15.87f, -1f);
        Vector3 newCamPos = new Vector3(13.56f,-13.73f,-2.5f);

        player.transform.position = newPos;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
