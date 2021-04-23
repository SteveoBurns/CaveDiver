using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [Header("Fade Animator")]
    [SerializeField] private Animator fadeAnimator;

    
    // Update is called once per frame
    void Update()
    {
        if(PlayerStats.oxygenLevel <= 0 || PlayerStats.health <= 0)
        {
            
            fadeAnimator.SetTrigger("fadeOut");

        }
        
    }


}
