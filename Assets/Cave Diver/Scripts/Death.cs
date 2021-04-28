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
        //Using Boolean Algebra to check if one or both of the conditions are true for the death fade animation to play.
        if(PlayerStats.oxygenLevel <= 0 || PlayerStats.health <= 0)
        {
            
            fadeAnimator.SetTrigger("fadeOut");

        }
        
    }


}
