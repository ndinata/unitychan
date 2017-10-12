/**
 * Project 2 - Graphics and Interaction
 * Author: Nico Dinata (770318)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Handles the first-person view of the player
 *
 * @TODO handle rotation such that the entire player body rotates, instead of just the eyes
 * @TODO clamp pitch to not allow "backflips"
 * @TODO handle gravity
 *
 */
public class FPView : MonoBehaviour {
    public float speed = 10.0f;         // controls player movement speed
    public float sensitivity = 5.0f;    // controls view/camera rotation sensitivity

    CharacterController player;

    public GameObject eyes;             // handles view of the player (camera)

    // view rotation direction
    float yaw;
    float pitch;

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

        // view rotation
        yaw   = Input.GetAxis("Mouse X") * sensitivity;
        pitch = Input.GetAxis("Mouse Y") * sensitivity;
        
        transform.Rotate(0, yaw, 0);
        eyes.transform.Rotate(-pitch, 0, 0);

        // move player relative to current orientation
        movement = transform.rotation * movement;
        player.Move(movement * Time.deltaTime);

        // unlocks and unhides the mouse cursor
        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;
	}
}