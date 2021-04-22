using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [Header("Fade Animator")]
    [SerializeField] private Animator fadeAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerStats.oxygenLevel <= 0 || PlayerStats.health <= 0)
        {
            //play animation
            fadeAnimator.SetTrigger("fadeOut");

        }
        
    }


}
