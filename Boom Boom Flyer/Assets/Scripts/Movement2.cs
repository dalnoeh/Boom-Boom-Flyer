using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour {


    public float forceUp = 4;
    public float maxFuel = 2.5f;
    private float fuel = 1.5f;
    private bool depleteFuel = false;
    public float burnrate = 0.1f;
    private bool playing;
    private float forceStrafe = 2;


    public float maxSpeed = 4f;
    private string playerName;
    private string upIn;
    private string leftIn;
    private string rightIn;
    private string[] joystickNameArr = new string[4];
    private GameObject player1;
    private GameObject player2;
    private GameObject player3;
    private GameObject player4;

    // Use this for initialization
    private void Awake()
    {
        playing = true;
    }
    void Start () {
        StartCoroutine("Fuel");
	}
    private void OnEnable()
    {
        playerName = gameObject.name;
        
       // joystickNameArr = Input.GetJoystickNames();
        if (playerName == "Penis1")
        {
            player1 = gameObject;
            upIn = "X1";
            leftIn = "Left1";
            rightIn = "Right1";
           
        }
        if (playerName == "Penis2")
        {
            player2 = gameObject;
            upIn = "X2";
            leftIn = "Left2";
            rightIn = "Right2";

        }
        if (playerName == "Penis3")
        {
            player3 = gameObject;
            upIn = "X3";
            leftIn = "Left3";
            rightIn = "Right3";
        }
        if (playerName == "Penis4")
        {
            player4 = gameObject;
            upIn = "X4";
            leftIn = "Left4";
            rightIn = "Right4";
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (/*Input.GetKey(KeyCode.W) || */Input.GetButton(upIn))
        {
            MoveVertically(upIn);
            depleteFuel = true;
        }
        else { depleteFuel = false; }
        if (Input.GetButtonUp(upIn))
        {
            if(upIn == "X1")
            {
                player1.GetComponent<Animator>().SetBool("FlyingBool", false);
            }
            if (upIn == "X2")
            {
                player2.GetComponent<Animator>().SetBool("Flying2", false);
            }
            if (upIn == "X3")
            {
                player3.GetComponent<Animator>().SetBool("Flying3", false);
            }
            if (upIn == "X4")
            {
                player4.GetComponent<Animator>().SetBool("Flying4", false);
            }

        }

            if (Input.GetButton(leftIn))
        {
            MoveHorrizontally(leftIn);
        }

        if (Input.GetButton(rightIn))
        {
            MoveHorrizontally(rightIn);
        }
        if (Input.GetKey(KeyCode.O))
        {
           // playing = false;
        }
	}

private void MoveVertically(string x)
    {
        x = upIn;
        if(x == "X1")
        {
            if (fuel > 0)
                player1.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * forceUp);
                player1.GetComponent<Animator>().SetBool("FlyingBool", true);
        }
        if(x == "X2")
        {
            if (fuel > 0)
                player2.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * forceUp);
                player2.GetComponent<Animator>().SetBool("Flying2", true);
        }
        if (x == "X3")
        {
            if (fuel > 0)
                player3.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * forceUp);
                player3.GetComponent<Animator>().SetBool("Flying3", true);
        }
        if (x == "X4")
        {
            if (fuel > 0)
                player4.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * forceUp);
                player4.GetComponent<Animator>().SetBool("Flying4", true);
        }

    }

    private void MoveHorrizontally(string x)
    {
        
        if (x == "Left1")
        {
                if(player1.GetComponent<Rigidbody2D>().velocity.x < maxSpeed && player1.GetComponent<Rigidbody2D>().velocity.x > -maxSpeed)
                player1.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right * -forceStrafe);
        }
        if (x == "Right1")
        {
            if (player1.GetComponent<Rigidbody2D>().velocity.x < maxSpeed && player1.GetComponent<Rigidbody2D>().velocity.x > -maxSpeed)
                player1.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right * forceStrafe);
        }
        if (x == "Left2")
        {
            if (player2.GetComponent<Rigidbody2D>().velocity.x < maxSpeed && player2.GetComponent<Rigidbody2D>().velocity.x > -maxSpeed)
                player2.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right * -forceStrafe);
        }
        if (x == "Right2")
        {
            if (player2.GetComponent<Rigidbody2D>().velocity.x < maxSpeed && player2.GetComponent<Rigidbody2D>().velocity.x > -maxSpeed)
                player2.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right * forceStrafe);
        }
        if (x == "Left3")
        {
            if (player3.GetComponent<Rigidbody2D>().velocity.x < maxSpeed && player3.GetComponent<Rigidbody2D>().velocity.x > -maxSpeed)
                player3.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right * -forceStrafe);
        }
        if (x == "Right3")
        {
            if (player3.GetComponent<Rigidbody2D>().velocity.x < maxSpeed && player3.GetComponent<Rigidbody2D>().velocity.x > -maxSpeed)
                player3.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right * forceStrafe);
        }
        if (x == "Left4")
        {
            if (player4.GetComponent<Rigidbody2D>().velocity.x < maxSpeed && player4.GetComponent<Rigidbody2D>().velocity.x > -maxSpeed)
                player4.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right * -forceStrafe);
        }
        if (x == "Right4")
        {
            if (player4.GetComponent<Rigidbody2D>().velocity.x < maxSpeed && player4.GetComponent<Rigidbody2D>().velocity.x > -maxSpeed)
                player4.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right * forceStrafe);
        }

    }


    private IEnumerator Fuel()
    {
        while (playing)
        {
            while (depleteFuel)
            {
                if ((fuel - burnrate) >= 0f)
                { fuel -= burnrate; }
                else
                {
                    fuel = 0;
                }
                yield return new WaitForSeconds(0.1f);
            }
            while (!depleteFuel)
            {
                if ((fuel + burnrate) <= maxFuel)
                { fuel += burnrate; }
                else
                {
                    fuel = maxFuel;
                }
                yield return new WaitForSeconds(0.1f);
            }
        }

        
    }
}
