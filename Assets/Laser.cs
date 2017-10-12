using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    public Transform start;
    public Transform end;
    LineRenderer laserLine;


	// Use this for initialization
	void Start () {
        laserLine = GetComponent<LineRenderer>();
        laserLine.startWidth = 1f;
        laserLine.endWidth = 1f;
	}
	
	// Update is called once per frame
	void Update () {
        laserLine.SetPosition(0,start.position);
        laserLine.SetPosition(1,end.position);
	}
}
