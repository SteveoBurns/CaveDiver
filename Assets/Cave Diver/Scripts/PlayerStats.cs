using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    
    public static float oxygenLevel = 20;

    // Start is called just before any of the Update methods is called the first time
    private void Start()
    {
        oxygenLevel = 20;
    }




    // Update is called once per frame
    void Update()
    {
        oxygenLevel -= .5f * Time.deltaTime;

        if (Input.GetButton("Dive"))
        {
            oxygenLevel -= 2 * Time.deltaTime;
        }
        Debug.Log(oxygenLevel);
    }
}
