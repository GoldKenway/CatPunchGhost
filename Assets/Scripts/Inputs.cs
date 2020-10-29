using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    [SerializeField] private Mov Mov;
    float HorizontalMovement; 
    float VerticalMovement;
    
    // Start is called before the first frame update
   public void Awake()
    {
        Mov = GetComponent<Mov>();
    }
    // Update is called once per frame
    void Update()
    {
        HorizontalMovement = Input.GetAxis("Horizontal");
        VerticalMovement = Input.GetAxis("Vertical");

    }

    private void FixedUpdate()
    {
        Mov.Move(HorizontalMovement, VerticalMovement, false);
    }
}
