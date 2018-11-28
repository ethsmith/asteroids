using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour {

    // Handle collision of the bullet with other objects
    void OnCollisionEnter2D(Collision2D otherObject) {
        // if the object is an asteroid or an enemy ship, destroy it
        if (otherObject.gameObject.name == "Asteroid(Clone)") {
            destroyObjects(otherObject);
        } else if (otherObject.gameObject.name == "EnemyShip(Clone)") {
            destroyObjects(otherObject);
        }
    }

    // destroy function to reduce boilerplate code
    void destroyObjects(Collision2D otherObject) {
        Destroy(otherObject.gameObject);
        Destroy(gameObject);
        GameManager.instance.enemiesList.Remove(otherObject.gameObject);
        GameManager.instance.score += 1;
        Debug.Log("Score: " + GameManager.instance.score);
    }
}
