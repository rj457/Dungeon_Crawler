﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float moveSpeed;
    public GameObject helo; 
    public Rigidbody2D rb;
    public Animator anim;
    public bool IsDown = false;
    public bool IsUp = false;
    public bool IsRight = false;
    public bool IsLeft = false;
    Vector2 movement;
    //userdata
    public recordplayer recordPlayer;
    //grab player health
    public HealthBar playerhealth;
    public InventoryObject infectionrecord;
    public GameObject StartIntro; 
    

    void Start()
    {
        if (infectionrecord.Isbattle)
        {
            infectionrecord.Isbattle = false;
            StartCoroutine(Waittime(2));
            transform.position = infectionrecord.initialvalue;
        }
        if (moveSpeed == 0)
        {
            moveSpeed = 15; 
        }
        if (anim == false)
        {
            anim.enabled = true;
        }
        if (infectionrecord.IsStartIntroopened == false)
        {
            introstart();
        }
        playerhealth.SetHealth(infectionrecord.playerhealth); 
        
    }
    void introstart()
    {
        StartIntro.SetActive(true);
        moveSpeed = 0;
        infectionrecord.IsStartIntroopened = true; 
    }

    IEnumerator Waittime(int time)
    {
        yield return new WaitForSeconds(time);
    } 

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("speed",movement.sqrMagnitude);
        // Change Direction signal 
        if (movement.y < 0)
        {
            IsDown = true;
            IsUp = false;
            IsRight = false;
            IsLeft = false; 
        }
        if (movement.y > 0)
        {
            IsUp = true;
            IsDown = false;
            IsRight = false;
            IsLeft = false; 
        }
        if (movement.x > 0)
        {
            IsRight = true;
            IsLeft = false;
            IsUp = false;
            IsDown = false; 
        }
        if (movement.x < 0)
        {
            IsLeft = true;
            IsRight = false;
            IsUp = false;
            IsDown = false; 
        }
        // change direction in side of the animator 
        if (IsDown == true){ anim.SetBool("IsDown",true); }
        else { anim.SetBool("IsDown", false); }

        if (IsUp == true) { anim.SetBool("IsUp", true); }
        else { anim.SetBool("IsUp", false); }

        if (IsRight == true) { anim.SetBool("IsRight", true); }
        else { anim.SetBool("IsRight", false); }

        if (IsLeft == true) { anim.SetBool("IsLeft", true); }
        else { anim.SetBool("IsLeft", false); }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        
    }


}
