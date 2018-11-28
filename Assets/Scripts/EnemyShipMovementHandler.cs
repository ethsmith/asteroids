using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipMovementHandler : MonoBehaviour {

    // Create a speed variable for editing
    public float moveSpeed = 5.0f;
    public float rotateSpeed = 10.0f;

    // Create the tranform variable
    private Transform tf;

    private Quaternion rotation;

    // Create a variable for facing other object
    private bool facing = false;

    // Use this for initialization
    void Start() {

        // Set the transform variable
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() {

        if (!facing) {
            Vector3 directionToLook = GameManager.instance.getPlayerPos() + tf.position; // Find the vector from us to the target
            tf.up = directionToLook;                            // Set our local right to be the look vector
            facing = true;
        } else {
            // The step size of the asteroid
            float step = moveSpeed * Time.deltaTime;

            // Move our position a step closer to the target
            tf.position = Vector3.MoveTowards(this.gameObject.transform.position, GameManager.instance.getPlayerPos(), step);
        }
    }
}