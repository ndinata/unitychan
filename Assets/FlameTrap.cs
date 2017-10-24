using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTrap : MonoBehaviour {

    bool execute=true;
    float delay = 2f;
    float lastTimeCall;
    public GameObject Flame;
    public float startTimeMod;

	// Use this for initialization
	void Start () {
        lastTimeCall = Time.time+startTimeMod;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Time.time-lastTimeCall>5f) {
            if (execute)
            {
                execute = false;
                lastTimeCall = Time.time-3.2f;
            }
            else {
                execute = true;
                lastTimeCall = Time.time+3f;
            }
            
        }
        
        Flame.SetActive(execute);

        

    }
}
