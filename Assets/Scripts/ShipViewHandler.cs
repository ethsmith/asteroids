using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipViewHandler : MonoBehaviour {

    // Access renderer of the ship
    private Renderer shipRenderer;

    void Start() {
        // set the ship renderer
        shipRenderer = GetComponent<Renderer>();
    }

    void OnBecameInvisible() {

        if (!GameManager.instance.isDead) {
            // kill, remove life, and respawn player
            Debug.Log("Got here.");
            shipRenderer.enabled = false;
            GameManager.instance.respawn(gameObject);

            GameManager.instance.setLives(GameManager.instance.getLives() - 1);
            Debug.Log("Lives left: " + GameManager.instance.getLives());

            if (GameManager.instance.getLives() < 1) {
                Application.Quit();
            }

            foreach (GameObject enemy in GameManager.instance.enemiesList) {
                Destroy(enemy);
            }
        }
    }
}
