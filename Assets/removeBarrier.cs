using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeBarrier : MonoBehaviour {

    public GameObject barrier;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        barrier.SetActive(false);
    }
}
