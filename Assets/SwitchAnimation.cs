using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAnimation : MonoBehaviour {
    public GameObject player;
    public GameObject wall;
    public GameObject laser;
    private float distance;
    private int CLOSE_THRESHOLD = 15;
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
            print(closeby);
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
            if (this.transform.position.y < 40)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
            } else
            {
                wall.transform.position = new Vector3(wall.transform.position.x, wall.transform.position.y + 200, wall.transform.position.z);
                laser.SetActive(false);
            } 

        }
    }

    private float calculateDistance(GameObject player)
    {
        float myDistance = Mathf.Sqrt((player.transform.position.x - this.transform.position.x) * (player.transform.position.x - this.transform.position.x) +
            (player.transform.position.y - this.transform.position.y) * (player.transform.position.y - this.transform.position.y) + (player.transform.position.z - this.transform.position.z) * (player.transform.position.z - this.transform.position.z));

        return myDistance;
    }
}

