using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeAnimation : MonoBehaviour {
    public Animation anim;
    int i = 0;

	// Use this for initialization
	void Start () {
        
        
	}
	
	// Update is called once per frame
	void Update () {
        i = 0;
        foreach (AnimationState state in anim)
        {
            if (i==3) {
                state.speed = 0.1f;
            }
            print(i);
            i++;
        }
    }
}
