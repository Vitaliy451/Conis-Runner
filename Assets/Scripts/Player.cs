using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    public CharacterController2D controller;

    public Animator animator;

    public Joystick joystick;

    public float runSpeed = 60f;
     
    float horizontalMove = 0f;
    //bool jump = false;
    [SerializeField]
    public AudioSource pickupSound;

    void Start()
    {
        pickupSound = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();

    }

    
    void Update()
    {
        if(joystick.Horizontal >= .2f)
        {
            horizontalMove = runSpeed;
            animator.SetFloat("Speed",Mathf.Abs(horizontalMove));
        }
        else if (joystick.Horizontal <= -.2f)
        {
            horizontalMove = -runSpeed;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }
        else
        {
            horizontalMove = 0;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }

        float verticalMove = joystick.Vertical;

        if(verticalMove >= .5f)
        {
            //jump = true;
        }
        

    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin") 
            && MusicCheck.instance.sfxCheck.isOn)
        {
            pickupSound.Play();
        }
    }
}
