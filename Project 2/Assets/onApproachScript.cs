using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onApproachScript : MonoBehaviour {
    public GameObject player;
    private bool closeby = false;
    private int CLOSE_THRESHOLD = 30;

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
        
	}

    private float calculateDistance(GameObject player)
    {
        float myDistance = Mathf.Sqrt((player.transform.position.x-this.transform.position.x) * (player.transform.position.x - this.transform.position.x) +
            (player.transform.position.y-this.transform.position.y) * (player.transform.position.y-this.transform.position.y) + (player.transform.position.z-this.transform.position.z) * (player.transform.position.z-this.transform.position.z));

        return myDistance;
    }
}
