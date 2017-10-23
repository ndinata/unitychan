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
 */
public class FPView : MonoBehaviour
{
    public float speed = 10.0f;         // controls player movement speed
    public float sensitivity = 5.0f;    // controls view/camera rotation sensitivity

    CharacterController player;

    public GameObject eyes;             // handles view of the player (camera)

    public GameObject text;             // the initial "start" text

    // view rotation direction
    float yaw;
    float pitch;

    // player movement direction (left, right, forward, backward)
    float moveVertical;
    float moveHorizontal;

    //Character ready to move or not
    bool ready = false;

    void Start()
    {
        // uses CharacterController to handle collision
        player = GetComponent<CharacterController>();

        // initialises the position of the camera/view
        eyes.transform.localPosition = new Vector3(0, 5.5f, -8);
        eyes.transform.localRotation = Quaternion.Euler(25.0f, 0, 0);

        // locks and hides the mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        // move the camera to become the "eyes" of the player
        if (Input.GetKeyDown("space"))
        {
            eyes.transform.localPosition = new Vector3(0, 0.5f, 0.2f);
            eyes.transform.localRotation = Quaternion.identity;
            text.SetActive(false);
            ready = true;
        }

        if (ready == true)
        {
            // player movement
            moveHorizontal = Input.GetAxis("Horizontal") * speed;
            moveVertical = Input.GetAxis("Vertical") * speed;
            Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

            // view rotation
            yaw += Input.GetAxis("Mouse X") * sensitivity;
            pitch -= Input.GetAxis("Mouse Y") * sensitivity;

            // clamps the angle of vision of the player
            transform.eulerAngles = new Vector3(Mathf.Clamp(pitch, -40f, 40f), yaw, 0f);

            // move player relative to current orientation
            movement = transform.rotation * movement;
            player.Move(movement * Time.deltaTime);

            // prevent the player from "flying"
            Vector3 temp = transform.position;
            temp.y = Mathf.Clamp(transform.position.y, 5.5f, 5.5f);
            transform.position = temp;

            // unlocks and unhides the mouse cursor
            if (Input.GetKeyDown(KeyCode.Escape))
                { Cursor.lockState = CursorLockMode.None; }

        }
    }
}