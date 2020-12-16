using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3Prepare : MonoBehaviour
{
    GameObject player;
    GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("MainCharacter");
        camera = GameObject.FindWithTag("MainCamera");

        Vector3 newPos = new Vector3(-5.2f, -30.9f, -1f);
        Vector3 newCamPos = new Vector3(12.18f, -27.01f, -2.5f);

        player.transform.position = newPos;
        camera.transform.position = newCamPos;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
