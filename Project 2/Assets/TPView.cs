/**
 * Project 2 - Graphics and Interaction
 * Author: Nico Dinata (770318)
 * 
 * Handles the third-person view of the player
 *
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPView : MonoBehaviour {
    public float speed = 10.0f;         // player movement speed

    CharacterController player;

    // player movement direction (left, right, forward, backward)
    float moveVertical;
    float moveHorizontal;

	void Start () {
        // uses CharacterController to handle collision
        player = GetComponent<CharacterController> ();

        // locks and hides the mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	void Update () {
        
        // player movement
        moveHorizontal = Input.GetAxis("Horizontal") * speed;
        moveVertical   = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        player.Move(movement * Time.deltaTime);

        // unlocks and unhides the mouse cursor
        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;
	}
}