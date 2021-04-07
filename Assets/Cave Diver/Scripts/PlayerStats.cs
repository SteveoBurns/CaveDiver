using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    
    public static float oxygenLevel = 20;
    [Header("Oxygen")]
    [SerializeField] private float oxygenDiveUse = 2;
    [SerializeField] private float oxygenSwimUse = 0.5f;
    [SerializeField] private float oxygenMaxLevel = 20;

    [SerializeField] private Slider oxygenGuage;


    // Start is called just before any of the Update methods is called the first time
    private void Start()
    {
        oxygenLevel = oxygenMaxLevel;
        oxygenGuage.maxValue = oxygenMaxLevel;
    }


    // Update is called once per frame
    void Update()
    {
        OxygenUse();
        oxygenGuage.value = oxygenLevel;
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
        Debug.Log(oxygenLevel);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "AirBubble")
        {
            oxygenLevel = oxygenMaxLevel;
            Destroy(collider.gameObject);
            Debug.Log("colision");
        }
    }
}
