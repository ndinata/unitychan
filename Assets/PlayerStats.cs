using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public Text healthText;
    public Text timeText;
    private int health;
    private bool invulnerable;
    private float damageTakenTime;

	// Use this for initialization
	void Start () {
		health = 5;
        invulnerable = false;

        SetHealthText();
        setTimeText();
	}
	
	// Update is called once per frame
	void Update () {
		SetHealthText();
        setTimeText();

        if (Time.time - damageTakenTime >= 2f) {
            invulnerable = false;
        }
	}

    void SetHealthText() {
        healthText.text = "Health: " + health.ToString();
    }

    void setTimeText() {
        timeText.text = "Time: " + Time.time.ToString();
    }

    public void takeDamage() {
        if (!invulnerable) {
            health = health - 1;
            invulnerable = true;
            damageTakenTime = Time.time;
        }
    }
}
