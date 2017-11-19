using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour {
    [SerializeField]
    private float bombCoolDownTime = 0.5f;
    public float forceUp = 4;
    public float maxFuel = 2.5f;
    private float fuel = 1.5f;
    private bool depleteFuel = false;
    public float burnrate = 0.1f;
    private bool playing;
    private float forceStrafe = 2;
    [SerializeField]
    private GameObject bomb;
    public float maxSpeed = 4f;
    private string playerName;
    private string upIn;
    private string leftIn;
    private string rightIn;
    private string downIn;
    private string[] joystickNameArr = new string[4];
    private GameObject player1;
    private GameObject player2;
    private GameObject player3;
    private GameObject player4;
    private bool firstframe = true;
    private float callTime;
    public bool dead = false;


    // Use this for initialization
    private void Awake()
    {

        playing = true;
        callTime = Time.time;
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
            downIn = "Bomb1";
            

        }
        if (playerName == "Penis2")
        {
            player2 = gameObject;
            upIn = "X2";
            leftIn = "Left2";
            rightIn = "Right2";
            downIn = "Bomb2";

        }
        if (playerName == "Penis3")
        {
            player3 = gameObject;
            upIn = "X3";
            leftIn = "Left3";
            rightIn = "Right3";
            downIn = "Bomb3";


        }
        if (playerName == "Penis4")
        {
            player4 = gameObject;
            upIn = "X4";
            leftIn = "Left4";
            rightIn = "Right4";
            downIn = "Bomb4";


        }











    }

    void Start()
    {
        StartCoroutine("Fuel");
      

    }
    // Update is called once per frame
    void Update()
    {
        if (firstframe)
        {

           /* if (gameObject == player1)
            {

                Physics2D.IgnoreCollision(player1.GetComponent<Collider2D>(), player2.GetComponent<Collider2D>(), true);
                Physics2D.IgnoreCollision(player1.GetComponent<Collider2D>(), player3.GetComponent<Collider2D>(), true);
                Physics2D.IgnoreCollision(player1.GetComponent<Collider2D>(), player4.GetComponent<Collider2D>(), true);
            }
            if (gameObject == player2)
            {
                Physics2D.IgnoreCollision(player2.GetComponent<Collider2D>(), player1.GetComponent<Collider2D>(), true);
                Physics2D.IgnoreCollision(player2.GetComponent<Collider2D>(), player3.GetComponent<Collider2D>(), true);
                Physics2D.IgnoreCollision(player2.GetComponent<Collider2D>(), player4.GetComponent<Collider2D>(), true);
            }

            if (gameObject == player3)
            {
                Physics2D.IgnoreCollision(player3.GetComponent<Collider2D>(), player1.GetComponent<Collider2D>(), true);
                Physics2D.IgnoreCollision(player3.GetComponent<Collider2D>(), player2.GetComponent<Collider2D>(), true);
                Physics2D.IgnoreCollision(player3.GetComponent<Collider2D>(), player4.GetComponent<Collider2D>(), true);
            }

            if (gameObject == player4)
            {
                Physics2D.IgnoreCollision(player4.GetComponent<Collider2D>(), player3.GetComponent<Collider2D>(), true);
                Physics2D.IgnoreCollision(player4.GetComponent<Collider2D>(), player2.GetComponent<Collider2D>(), true);
                Physics2D.IgnoreCollision(player4.GetComponent<Collider2D>(), player4.GetComponent<Collider2D>(), true);
            }*/
            firstframe = false;
        }



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

        if (Input.GetButtonDown(downIn) && !dead)
        {
            if (Time.time - callTime > bombCoolDownTime)
            {
                callTime = Time.time;
                DropBomb(downIn);
            }
        }
        else
        {
            Debug.Log("bomb is on cooldown");
        
        }



        if (Input.GetKey(KeyCode.O))
        {
           // playing = false;
        }
	}

private void MoveVertically(string x)
    {
        x = upIn;
        if(x == "X1" && !dead)
        {
            if (fuel > 0)
                player1.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * forceUp);
                player1.GetComponent<Animator>().SetBool("FlyingBool", true);
        }
        if(x == "X2" && !dead)
        {
            if (fuel > 0)
                player2.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * forceUp);
                player2.GetComponent<Animator>().SetBool("Flying2", true);

        }
        if (x == "X3" && !dead)
        {
            if (fuel > 0)
                player3.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * forceUp);
                player3.GetComponent<Animator>().SetBool("Flying3", true);
        }
        if (x == "X4" && !dead)
        {
            if (fuel > 0)
                player4.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * forceUp);
                player4.GetComponent<Animator>().SetBool("Flying4", true);
        }

    }

    private void MoveHorrizontally(string x)
    {
        
        if (x == "Left1" && !dead)
        {
                if(player1.GetComponent<Rigidbody2D>().velocity.x < maxSpeed && player1.GetComponent<Rigidbody2D>().velocity.x > -maxSpeed)
                player1.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right * -forceStrafe);
        }
        if (x == "Right1" && !dead)
        {
            if (player1.GetComponent<Rigidbody2D>().velocity.x < maxSpeed && player1.GetComponent<Rigidbody2D>().velocity.x > -maxSpeed)
                player1.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right * forceStrafe);
        }
        if (x == "Left2" && !dead)
        {
            if (player2.GetComponent<Rigidbody2D>().velocity.x < maxSpeed && player2.GetComponent<Rigidbody2D>().velocity.x > -maxSpeed)
                player2.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right * -forceStrafe);
        }
        if (x == "Right2" && !dead)
        {
            if (player2.GetComponent<Rigidbody2D>().velocity.x < maxSpeed && player2.GetComponent<Rigidbody2D>().velocity.x > -maxSpeed)
                player2.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right * forceStrafe);
        }
        if (x == "Left3" && !dead)
        {
            if (player3.GetComponent<Rigidbody2D>().velocity.x < maxSpeed && player3.GetComponent<Rigidbody2D>().velocity.x > -maxSpeed)
                player3.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right * -forceStrafe);
        }
        if (x == "Right3" && !dead)
        {
            if (player3.GetComponent<Rigidbody2D>().velocity.x < maxSpeed && player3.GetComponent<Rigidbody2D>().velocity.x > -maxSpeed)
                player3.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right * forceStrafe);
        }
        if (x == "Left4" && !dead)
        {
            if (player4.GetComponent<Rigidbody2D>().velocity.x < maxSpeed && player4.GetComponent<Rigidbody2D>().velocity.x > -maxSpeed)
                player4.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.right * -forceStrafe);
        }
        if (x == "Right4" && !dead)
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



    private void DropBomb(string x)
    {
        //Debug.Log(Time.time - callTime);



        switch (x)

        {
            case "Bomb1":
                {
                    Instantiate(bomb, player1.transform.position - new Vector3(0, 1), Quaternion.identity);
                    break;
                }

            case "Bomb2":
                {
                    Instantiate(bomb, player2.transform.position - new Vector3(0, 1), Quaternion.identity);

                    break;
                }
            case "Bomb3":
                {
                    Instantiate(bomb, player3.transform.position - new Vector3(0, 1), Quaternion.identity);

                    break;
                }
            case "Bomb4":
                {
                    Instantiate(bomb, player4.transform.position - new Vector3(0, 1), Quaternion.identity);

                    break;
                }

            default: break;

        }
    
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
        }



    }

   

}
