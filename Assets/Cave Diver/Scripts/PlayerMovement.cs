using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [Header ("Speed")]
    [SerializeField] private float playerSpeed = 5f;
    private float diveSpeed;
    private float normalPlayerSpeed = 5f;

    [Header("Flippers")]
    [SerializeField] private float flipperSpeed = 7f;
    [SerializeField] private float flipperDiveSpeed = 10.5f;
    public static bool flippersOn = false;
    public static float flipperBoostTimer = 4;

    [Header("Player Animator")]
    [SerializeField] private Animator animator;

      


    // Start is called before the first frame update
    void Start()
    {
        flippersOn = false;
        diveSpeed = playerSpeed * 1.5f;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position += Vector3.right * playerSpeed * Time.fixedDeltaTime;
        transform.position += Vector3.up * playerSpeed * Time.fixedDeltaTime;

        if (Input.GetButton("Dive"))
        {
            transform.position += Vector3.down * diveSpeed * Time.fixedDeltaTime;
        }

        if (flippersOn)
        {
            FlippersOn();
        }
        
       
    }

    /// <summary>
    /// Controls movement values when the player picks up Flippers
    /// </summary>
    private void FlippersOn()
    {
        
        if (flipperBoostTimer > 0)
        {
            animator.SetBool("FlippersOn", true);
            flipperBoostTimer -= Time.deltaTime;
            playerSpeed = flipperSpeed;
            diveSpeed = flipperDiveSpeed;
        }
        else if(flipperBoostTimer <= 0)
        {
            animator.SetBool("FlippersOn", false);
            playerSpeed = normalPlayerSpeed;
            diveSpeed = normalPlayerSpeed * 2;
            flippersOn = false;
        }
        Debug.Log(flipperBoostTimer);
    }
   
}
