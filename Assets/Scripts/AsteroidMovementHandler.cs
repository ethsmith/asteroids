using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovementHandler : MonoBehaviour {

    // Create a speed variable for editing
    public float speed = 20.0f;

    // Create the tranform variable
    private Transform tf;

    // Create a settable target object
    private Vector3 target;

    // Use this for initialization
    void Start () {

        // Set the transform variable
        tf = GetComponent<Transform>();

        // Set the target variable
        target = GameManager.instance.getPlayerPos();
    }
	
	// Update is called once per frame
	void Update () {

        // The step size of the asteroid
        float step = speed * Time.deltaTime;

        // Move our position a step closer to the target
        tf.position = Vector3.MoveTowards(this.gameObject.transform.position, target, step);
	}
}
