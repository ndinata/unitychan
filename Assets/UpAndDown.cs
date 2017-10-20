using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDown : MonoBehaviour {

    private int reverse=1;
    public float speed = 0.2f;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < 11) {
            reverse = -1;
        }
        else if (this.transform.position.y>32) {
            reverse = 1;
        }
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - (speed*reverse), this.transform.position.z);
        
    } 
}
