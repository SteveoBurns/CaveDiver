using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("OnHit");
        explosion.Play();
    }    
}
