/**
 * Project 2 - Graphics and Interaction
 * Author: Nico Dinata (770318)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Handles player collision with traps that cause damage to the player.
 */
public class TrapCollision : MonoBehaviour
{
    void Start() {

    }

    void OnTriggerEnter (Collider other) {
        other.GetComponent<Collider>().SendMessage("takeDamage");
    }
}

/*

private float fire_start_time;

void Update()
{
    if(Input.GetButtonDown("Fire1"))
    {
        fire_start_time = Time.time;
    }
}

void OnTriggerEnter(Collider other)
{
    Debug.Log("elapsed time: " + (Time.time - fire_start_time));
}

*/