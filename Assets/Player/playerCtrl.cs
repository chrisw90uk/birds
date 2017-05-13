﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerCtrl : MonoBehaviour {

    private float speed;
    private bool facingRight;
    public Rigidbody2D body;
    public bool isGrounded;
    public float distToGround;

    //XP
    public static int currentXP;
    public static int requiredXP;
    public static int playerLevel; //static makes it belong to a class rather than object
    public GameObject levelUpObj;
    public Text levelUpMsg;

    //BG

    public GameObject bg;
    public GameObject bgLayer1;
    public GameObject bgLayer2;



    // Use this for initialization
    void Start () {
        speed = 5f;
        transform.position = new Vector2(0, 0);
        body = GetComponent<Rigidbody2D>();
        facingRight = true;
        isGrounded = true;

        //XP
        currentXP = 0;
        requiredXP = 100;
        playerLevel = 1;
        levelUpMsg = levelUpObj.GetComponent<Text>();
    }

    //ground check

    private void OnCollisionEnter2D(Collision2D collided)
    {
        if(collided.gameObject.tag == "floor")
        {
            isGrounded = true;
        }

        //collect pick up and increase XP

        if (collided.gameObject.tag == "pickup")
        {
            Destroy(collided.gameObject);
            currentXP += 20;
            if (currentXP > requiredXP || currentXP == requiredXP)
            {
                levelUp();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collided)
    {
        if (collided.gameObject.tag == "floor")
        {
            isGrounded = false;
        }
    }


    //level up message for coroutine

    IEnumerator displayNewLevel()
    {
        levelUpMsg.text = "Congratulations! You reached Level " + playerLevel + "!";
        levelUpObj.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        levelUpObj.SetActive(false);
    }

    //level up function

    private void levelUp()
    {
        playerLevel += 1;
        StartCoroutine(displayNewLevel()); //a coroutine isn't synchronised to the framerate

        if (currentXP > requiredXP)
        {
            currentXP = 0 + (currentXP - requiredXP);
        }
        else
        {
            currentXP = 0;
        }
        requiredXP += 50;
    }


    // Update is called once per frame
    void Update () {

        Debug.Log(isGrounded);

        //jump

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            body.AddForce(Vector2.up * 200f);
            isGrounded = false;
        }

        //add xp with up button

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentXP += 10;

            if (currentXP > requiredXP || currentXP == requiredXP)
            {
                levelUp();
            }
        }

        //add more xp with down button

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentXP += 20;

            if (currentXP > requiredXP || currentXP == requiredXP)
            {
                levelUp();
            }
        }

        //right

        if (Input.GetKey(KeyCode.D))
        {
            if (facingRight!=true)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                facingRight = true;
            }
            if (isGrounded)
            {
                //body.AddForce(Vector2.up * 50f);

            }

            transform.position += transform.right * Time.deltaTime * speed;
            bgLayer1.transform.position += transform.right * Time.deltaTime * (speed / 4);
            bgLayer2.transform.position += transform.right * Time.deltaTime * (speed / 8);
        }  

        //left

        if (Input.GetKey(KeyCode.A))
        {
            if (facingRight == true)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                facingRight = false;
            }
            if (isGrounded)
            {
                //body.AddForce(Vector2.up * 50f);
            }
            transform.position += transform.right * Time.deltaTime * speed;
            bgLayer1.transform.position += transform.right * Time.deltaTime * (speed / 4);
            bgLayer2.transform.position += transform.right * Time.deltaTime * (speed / 8);
        }
    }

}
