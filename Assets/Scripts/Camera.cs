using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<UnityEngine.Camera>().main.transform.position.y = 0.62f;
        float x = this.transform.position.x;
        float z = this.transform.position.z;
        float y = 0;
        Vector3 newpostion = new Vector3(x, y, z); 
        this.transform.position = newpostion;
    }
}
