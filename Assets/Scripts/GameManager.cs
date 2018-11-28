using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    // Instance variable
    public static GameManager instance;

    // Enemy spawn point list
    public List<GameObject> spawnPointList;

    // Current enemies list
    public List<GameObject> enemiesList;

    // prefabs
    public GameObject bullet;
    public GameObject asteroid;
    public GameObject enemyShip;

    // player
    public GameObject player;

    // number of lives
    public int lives;

    // max number of enemies at one time
    public int maxEnemies;

    // score of the player
    public int score = 0;

    // create boolean for if the player is dead
    public bool isDead = false;

    // Set the instance to this
    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }


    // Use this for initialization
    void Start () {
        
        // Set enemies list to a new List
        enemiesList = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
        if (enemiesList.Count < 3 && !isDead) {
            spawnEnemy();
        }
    }

    // Spawn an enemy (either an asteroid or a ship)
    void spawnEnemy() {
        // setup the random chance for either an asteroid or an enemy ship to spawn
        int typeOfEnemy = Random.Range(0, 4);

        // 75% chance for an asteroid
        if (typeOfEnemy < 3) {
            if (asteroid != null) {
                // random index of the spawn list
                int spawnPointId = Random.Range(0, spawnPointList.Count);
                // the spawn point as a game object
                GameObject spawnPoint = spawnPointList[spawnPointId];
                // the instantiation of the asteroid prefab
                GameObject asteroidObj = Instantiate(asteroid, spawnPoint.transform.position, Quaternion.identity) as GameObject;
                // add the asteroid object to the list
                enemiesList.Add(asteroidObj);
            }
        // 25% chance for an enemy ship
        } else {
            if (enemyShip != null) {
                // random index of the spawn list
                int spawnPointId = Random.Range(0, spawnPointList.Count);
                // the spawn point as a game object
                GameObject spawnPoint = spawnPointList[spawnPointId];
                // the instantiation of the enemy ship prefab
                GameObject enemyShipObj = Instantiate(enemyShip, spawnPoint.transform.position, Quaternion.identity) as GameObject;
                // add the enemy ship object to the list
                enemiesList.Add(enemyShipObj);
            }
        }
    }

    // Create a bullet that shoots in a straight line for the lifespan of the object
    public void createBullet() {
        // the instantiation of the bullet object
        GameObject bulletObj = Instantiate(bullet, GetComponent<Transform>().position, Quaternion.identity) as GameObject;

        // if the bulletObj isn't null, retrieve the bullets lifespan variable
        if (bulletObj != null) {
            BulletMovementHandler bulletHandler = bulletObj.GetComponent<BulletMovementHandler>();
            if (bulletHandler != null) {
                Destroy(bulletObj, bulletHandler.lifespan);
            }
        }
    }

    // Return the player position as a vector
    public Vector3 getPlayerPos() {
        return player.transform.position;
    }

    // Return the player rotation as a Quaternion
    public Quaternion getPlayerRotation() {
        return player.transform.rotation;
    }

    // Return the lives left
    public int getLives() {
        return lives;
    }

    // Set the lives left of the player
    public void setLives(int lives) {
        this.lives = lives;
    }

    // Start the respawn process
    public void respawn(GameObject player) {
        StartCoroutine(respawnPlayer(player));
    }

    // Respawn process
    public IEnumerator respawnPlayer(GameObject player) {
        yield return new WaitForSeconds(5);
        player.transform.position = new Vector3(0, 0, 0);
        player.GetComponent<Renderer>().enabled = true;
        isDead = false;
        Debug.Log("Respawned!");
    }
}
