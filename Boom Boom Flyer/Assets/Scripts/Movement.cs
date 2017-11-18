using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float hSpeed;
    public float vSpeed;

    public float hMoveModifier;
    public float vMoveModifier;


    public Vector2 moveVector;

	// Use this for initialization
	void Start () {
        hSpeed = 0;

        hMoveModifier = 0.1f;
        vMoveModifier = 0.1f;

        moveVector = gameObject.transform.position;

    }

	
	// Update is called once per frame
	void Update () {

        //Move stuff
        if (Input.GetKey(KeyCode.D))
        {
           hSpeed += hMoveModifier;
        }

        if (Input.GetKey(KeyCode.A))
        {
            hSpeed += -hMoveModifier;
        }

        if (Input.GetKey(KeyCode.W))
        {
            vSpeed += vMoveModifier;
        }

        if (Input.GetKey(KeyCode.S))
        {
           vSpeed += -vMoveModifier;
        }


        //Stop moving stuff
        if (Input.GetKeyUp(KeyCode.D))
        {
            hSpeed = 0;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            hSpeed = 0;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            vSpeed = 0;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            vSpeed = 0;
        }


        if (hSpeed > hMoveModifier)
        {
            hSpeed = hMoveModifier;
        }
        else if (hSpeed < -hMoveModifier)
        {
            hSpeed = -hMoveModifier;
        }

        if (vSpeed > hMoveModifier)
        {
            vSpeed = hMoveModifier;
        }
        else if (vSpeed < -hMoveModifier)
        {
            vSpeed = -hMoveModifier;
        }

        Move();

	}


    public void Move()
    {
        //  gameObject.GetComponent<Rigidbody2D>().AddForce(moveVector);

        gameObject.transform.position = new Vector2(moveVector.x + hSpeed, moveVector.y + vSpeed);

        moveVector = gameObject.transform.position;
    }
}
