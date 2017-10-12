using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 0.4f;
    CharacterController player;

    float movefb;

    int cooldownA = 0;
    int cooldownD = 0;

    //Setting the Initial Rotation for Initial Perspective
    float rotationy=0;

    // Use this for initialization
    void Start () {
        player = GetComponent<CharacterController>();
        
    }
	
	// Update is called once per frame
	void Update () {

        if (cooldownA > 0)
        {
            cooldownA -= 1;
        }
        if (cooldownD > 0)
        {
            cooldownD -= 1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            movefb = 5000 * Time.deltaTime;
            Vector3 movement = new Vector3(0, 0, movefb);
            movement = transform.rotation * movement;
           // print(movement);
           // print(Time.deltaTime);
            player.Move(movement * Time.deltaTime);

        }

        //checking the input from key board to do roll for the camera
        if (Input.GetKey(KeyCode.A) && cooldownA==0)
        {
            rotationy += -45.0f;
            transform.eulerAngles = new Vector3(0, rotationy, 0);
            cooldownA = 10;
        }

        if (Input.GetKey(KeyCode.D) && cooldownD==0)
        {
            rotationy += 45.0f;
            transform.eulerAngles = new Vector3(0, rotationy, 0);
            cooldownD = 10;
        }

        

        //make the camera can move to all direction
        

        //make the player can move to front back left right
        

	}
}
