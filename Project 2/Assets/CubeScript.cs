﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour {

    public Shader shader;

	// Use this for initialization
	void Start () {
        GetComponent<MeshRenderer>().material.shader = shader;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
