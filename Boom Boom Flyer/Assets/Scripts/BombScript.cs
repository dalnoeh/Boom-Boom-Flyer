using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BombScript : MonoBehaviour {

    //public static BombScript bombScriptSingleton;

    private float lifetime = 3f;
    private float spawntime;
    private Animation anim;

    // Use this for initialization
    void Awake ()
    {
        //bombScriptSingleton = this;
        spawntime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
		if(Time.time - spawntime > lifetime)
        {

            Destroy(gameObject);
        }
	}


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            StartCoroutine("DeathAnim");
            col.GetComponentInParent<SpriteRenderer>().color = Color.black;
            col.GetComponentInParent<Movement2>().dead = true;


        }
        if (col.CompareTag("Boundaries"))
        {
            Debug.Log("stop");
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        }

        
    }

    IEnumerator DeathAnim()
    {
        gameObject.GetComponent<Animator>().SetBool("Explosion", true);
        anim = gameObject.GetComponent<Animation>();
        yield return new WaitForSeconds(anim.clip.length);
        Destroy(gameObject);
    }
}
