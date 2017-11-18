using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomScript : MonoBehaviour {

    public GameObject boom;

    public Vector3 flyerPos;

    public Transform BoomPrefab;

	// Use this for initialization
	void Start () {

        flyerPos = transform.position;

    }
	
	// Update is called once per frame
	void Update () {

        flyerPos = transform.position;

        BoomBoom();

	}

    public void BoomBoom()
    {

        Vector3 boomSpawnPos = new Vector3(flyerPos.x + 0.37f, flyerPos.y - 0.15f, flyerPos.z);

        if (Input.GetKey("f"))
        {
            Instantiate(boom, boomSpawnPos,transform.rotation);
        }


    }

}
