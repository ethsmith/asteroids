using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyViewHandler : MonoBehaviour {

    private void OnBecameInvisible() {
        // destroy object if it goes out of the view port of the player
        Destroy(gameObject);
    }
}
