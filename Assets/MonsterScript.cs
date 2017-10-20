using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour {
    private bool reverse = false;


	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (reverse == false)
        { 
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1);
        }
        if (reverse == true)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 1);
        }
        if (this.transform.position.z>=355)
        {
            this.transform.eulerAngles = new Vector3(0, 180, 0);
            reverse = true;
        }
        if (this.transform.position.z<=141)
        {
            this.transform.eulerAngles = new Vector3(0, 0, 0);
            reverse = false;
        }
	}
}
