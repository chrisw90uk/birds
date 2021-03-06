﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCtrl : MonoBehaviour {

    private float speed;
    private bool facingRight;
    public Rigidbody2D body;
    public bool isGrounded;
    public float distToGround;
    


	// Use this for initialization
	void Start () {
        speed = 5f;
        transform.position = new Vector2(0, 0);
        body = GetComponent<Rigidbody2D>();
        facingRight = true;
        isGrounded = true;
	}

    //ground check

    private void OnCollisionEnter2D(Collision2D collided)
    {
        if(collided.gameObject.tag == "floor")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collided)
    {
        if (collided.gameObject.tag == "floor")
        {
            isGrounded = false;
        }
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
                body.AddForce(Vector2.up * 50f);
            }

            transform.position += transform.right * Time.deltaTime * speed;
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
                body.AddForce(Vector2.up * 50f);
            }
            transform.position += transform.right * Time.deltaTime * speed;
        }

    }
}
