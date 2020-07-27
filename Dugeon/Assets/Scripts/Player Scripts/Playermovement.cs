using System.Collections;
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
    public VectorValue startingpoint;
    public recordplayer recordPlayer;
    //grab player health
    public HealthBar playerhealth;
    public GameObject shield;
    public BattleResult BattleResult;

    

    void Start()
    {
        
        if (startingpoint.Isbattle)
        {
            startingpoint.Isbattle = false;
            StartCoroutine(Waittime(2));
            transform.position = startingpoint.initialvalue;
        }
        if (moveSpeed == 0)
        {
            moveSpeed = 5; 
        }
        if (anim == false)
        {
            anim.enabled = true;
        }
        if (recordPlayer.IsShield == true)
        {
            helo.SetActive(true);
            shield.SetActive(false); 
        }
        else
        {
            helo.SetActive(false);
            shield.SetActive(true);
        }
        checkBattleResult();

        playerhealth.SetHealth(recordplayer.playerhealth); 
        
    }
    

    void checkBattleResult()
    {
        if (BattleResult.IsPlayerWin == true)
        {
            Debug.Log(BattleResult.enemyTag);
            GameObject targetenemy = GameObject.FindGameObjectWithTag(BattleResult.enemyTag);
            targetenemy.SetActive(false); 
        }
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
