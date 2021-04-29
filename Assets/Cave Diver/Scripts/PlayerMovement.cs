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
        //Movement
        transform.position += Vector3.right * playerSpeed * Time.fixedDeltaTime;
        transform.position += Vector3.up * playerSpeed * Time.fixedDeltaTime;

        //Diving when pressing space bar
        if (Input.GetButton("Dive"))
        {
            transform.position += Vector3.down * diveSpeed * Time.fixedDeltaTime;
        }
        //Movement changes when flipppers are on
        if (flippersOn)
        {
            FlippersOn();
        }
        //Test when player dies.
        if (PlayerStats.oxygenLevel <= 0 || PlayerStats.health <= 0)
        {
            playerSpeed = 0;
            animator.SetTrigger("OnDeath");

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
            diveSpeed = normalPlayerSpeed * 1.5f;
            flippersOn = false;
        }
        Debug.Log(flipperBoostTimer);
    }
   
}
