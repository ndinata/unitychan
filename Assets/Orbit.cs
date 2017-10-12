using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

    public GameObject terrain;

    private float radius; //The Radius of the Orbit 
    public float rotationSpeed; //The Rotation Speed of the Object
    private int phase = 1; //The Orbiting Direction of the Object
    private float currentAngle = 90.0f; //The Current Angle of the object to

    //Calculate the radius of the sun
    void Start()
    {
        //DiamondSquareTerrain terrainScript = terrain.GetComponent<DiamondSquareTerrain>();
        radius = 200;//Math.Max(terrainScript.maxHeight,terrainScript.mSize/2)*1.5f;
    }

	void Update () {
        //Decide Initial Position and Rotation
        this.transform.localPosition = new Vector3(250, radius, 250); 
        this.transform.localRotation = Quaternion.identity;

        //The position of the pivot in the World Space
        //Vector3 pivotPointInWorldSpace =
        //  this.transform.TransformPoint(Vector3.down * this.phase * radius) + new Vector3(0,(this.transform.localScale.x-1)*radius,0);

        //The axis in which the object rotate
        //Vector3 axisInWorldSpace = this.transform.InverseTransformDirection(Vector3.back);

        //Execute rotation movement
        //this.transform.RotateAround(pivotPointInWorldSpace, axisInWorldSpace, this.currentAngle * phase);

        //Change angle for next update
        currentAngle += 3*Time.deltaTime;
        this.transform.eulerAngles = new Vector3(currentAngle,0,0);
        
	}
}
