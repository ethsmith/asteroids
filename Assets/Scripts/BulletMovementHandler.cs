using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovementHandler : MonoBehaviour {

    // Create a speed variable for editing
    public float speed = 10.0f;
    // Create a lifespan (in seconds) for the bullet
    public int lifespan = 5;

    // Create the tranform variable
    private Transform tf;

    // Use this for initialization
    void Start () {

        // Set the transform variable
        tf = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {

        // Move the bullet by the specified speed
        tf.Translate(GameManager.instance.player.transform.up * speed);
    }
}
