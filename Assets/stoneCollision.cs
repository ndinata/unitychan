using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame

    void OnTriggerEnter(Collider other)
    {

        other.GetComponent<Collider>().SendMessage("takeDamage");
        Debug.Log("test");
    }
}
