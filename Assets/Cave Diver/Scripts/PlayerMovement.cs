using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float diveSpeed = 10f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //transform.position += Vector3.right * playerSpeed * Time.fixedDeltaTime;
        transform.position += Vector3.up * playerSpeed * Time.fixedDeltaTime;

        if (Input.GetButton("Dive"))
        {
            transform.position += Vector3.down * diveSpeed * Time.fixedDeltaTime;
        }

        
       
    }
   
}
