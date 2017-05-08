using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCtrl : MonoBehaviour {

    private float speed;
    private bool facingRight;
    public Rigidbody2D body;


	// Use this for initialization
	void Start () {
        speed = 5f;
        transform.position = new Vector2(0, 0);
        body = GetComponent<Rigidbody2D>();
        facingRight = true;
	}
	
	// Update is called once per frame
	void Update () {

        //jump

        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(Vector2.up * 200f);
        }

        //right

        if (Input.GetKey(KeyCode.D))
        {
            if (facingRight!=true)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                facingRight = true;
            }
            transform.position += transform.right  * Time.deltaTime * speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (facingRight == true)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                facingRight = false;
            }
            transform.position += transform.right * Time.deltaTime * speed;
        }

    }
}
