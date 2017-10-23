using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAnimation : MonoBehaviour {
    public GameObject player;
    //public GameObject wall;
    public GameObject laser;
    public GameObject lever;
    private float distance;
    private int CLOSE_THRESHOLD = 20;
    private bool closeby = false;
    private bool switched = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float distance = calculateDistance(player);
        if (distance < CLOSE_THRESHOLD)
        {
            closeby = true;
            //NEED TO CHANGE THE PRINT TO UI ACTION
        }
        else
        {
            closeby = false;
        }

        if (closeby == true)
        {
            if(Input.GetKey(KeyCode.E))
            {
                switched = true;
            }
        }

        if (switched == true)
        {
            lever.transform.localPosition = new Vector3(0, 0.20f, 1.65f);

            laser.SetActive(false); 

        }
    }

    private float calculateDistance(GameObject player)
    {
        float myDistance = Mathf.Sqrt((player.transform.position.x - this.transform.position.x) * (player.transform.position.x - this.transform.position.x) +
            (player.transform.position.y - this.transform.position.y) * (player.transform.position.y - this.transform.position.y) + (player.transform.position.z - this.transform.position.z) * (player.transform.position.z - this.transform.position.z));

        return myDistance;
    }
}

