using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipCollisionHandler : MonoBehaviour {

    // The player object for easier access
    private GameObject starShip;

    // Collision event to handle player deaths
    void OnCollisionEnter2D(Collision2D otherObject) {
        if (otherObject.gameObject.name == "StarShip") {

            // Set the isDead variable to true
            GameManager.instance.isDead = true;

            // Set starShip to the collided object
            starShip = otherObject.gameObject;
            // Get the Renderer component of the player and set it to false
            starShip.GetComponent<Renderer>().enabled = false;

            // Start the respawn process
            GameManager.instance.respawn(starShip);

            // Set the lives of the player
            GameManager.instance.setLives(GameManager.instance.getLives() - 1);
            Debug.Log("Lives left: " + GameManager.instance.getLives());

            // Check if the player lives is less than 1, if so, quit the application
            if (GameManager.instance.getLives() < 1) {
                Application.Quit();
            }

            // Destroy each of the game object in the enemy list
            foreach (GameObject enemy in GameManager.instance.enemiesList) {
                Destroy(enemy);
            }

            // Clear the enemy list
            GameManager.instance.enemiesList.Clear();
        }
    }
}
