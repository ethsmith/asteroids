using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControlHandler : MonoBehaviour {

    // Create speed variables for movement and rotation
    public float shipMoveSpeed = 2.0f;
    public float rotateSpeed = 1.0f;

    // Create Transform variable
    private Transform tf;

    // Use this for initialization
    void Start () {
        // Set tranform variable
        tf = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        /*
        *  Shoot On Space
        */
        if (Input.GetButtonDown("space")) {
            if (!GameManager.instance.isDead) {
                GameManager.instance.createBullet();
            }
        }

        /*
         *  Move On Arrow Keys
         */
        if (Input.GetButton("up")) {
            tf.transform.Translate(0, Time.deltaTime * shipMoveSpeed, 0);
        } else if (Input.GetButton("left")) {
            tf.Rotate(Vector3.forward, rotateSpeed);
        } else if (Input.GetButton("right")) {
            tf.Rotate(Vector3.forward, -rotateSpeed);
        }
    }
}
