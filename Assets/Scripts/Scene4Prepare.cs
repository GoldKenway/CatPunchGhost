using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene4Prepare : MonoBehaviour
{
    GameObject player;
    GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("MainCharacter");
        camera = GameObject.FindWithTag("MainCamera");

        Vector3 newPos = new Vector3(-4.07f, -45.34f, -1f);
        Vector3 newCamPos = new Vector3(6.94f, -41.03f, -2.5f);

        player.transform.position = newPos;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
