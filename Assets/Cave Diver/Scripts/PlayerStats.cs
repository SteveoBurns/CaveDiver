using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static PlayerMovement;


public class PlayerStats : MonoBehaviour
{

    public static float oxygenLevel;

    [Header("Oxygen")]
    [SerializeField] private float oxygenDiveUse = 2;
    [SerializeField] private float oxygenSwimUse = 0.5f;
    [SerializeField] private float oxygenMaxLevel = 40;
    [SerializeField] private Slider oxygenGuage;

    public static float health = 50;

    [Header("Health")]
    [SerializeField] private float healthMax = 50;
    [SerializeField] private Slider healthSlider;


    [SerializeField] private GameObject winPanel;
    


    // Start is called just before any of the Update methods is called the first time
    private void Start()
    {
        health = healthMax;
        oxygenLevel = oxygenMaxLevel;
        oxygenGuage.maxValue = oxygenMaxLevel;
        healthSlider.maxValue = healthMax;
    }


    // Update is called once per frame
    void Update()
    {
        OxygenUse();
        oxygenGuage.value = oxygenLevel;
        healthSlider.value = health;
    }

    /// <summary>
    /// Controls the oxygen use when swimming and diving
    /// </summary>
    private void OxygenUse()
    {
        oxygenLevel -= oxygenSwimUse * Time.deltaTime;

        if (Input.GetButton("Dive"))
        {
            oxygenLevel -= oxygenDiveUse * Time.deltaTime;
        }
        //Debug.Log(oxygenLevel);
    }

    /// <summary>
    /// Handles the collisions with Power Ups and Mines
    /// </summary>
    /// <param name="collider">The collider of the object being hit</param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "AirBubble")
        {
            if (oxygenLevel <= 30)
            {
                oxygenLevel += 10;
            }
            else
            {
                oxygenLevel = oxygenMaxLevel;
            }
            Destroy(collider.gameObject);
            
        }
        if (collider.tag == "Flippers")
        {
            
            PlayerMovement.flipperBoostTimer += 3;
            PlayerMovement.flippersOn = true;
            Destroy(collider.gameObject);
            
        }
        if (collider.tag == "Mine")
        {
            
            health -= 10;           
            
        }
        if(collider.tag == "Health")
        {
            if(health <= 40)
            {
                health += 10;
            }
            else
            {
                health = healthMax;
            }
            Destroy(collider.gameObject);
        }
        if (collider.tag == "EndLevel")
        {
            Time.timeScale = 0;
            winPanel.SetActive(true);
        }
    }

    
}
