using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    List<GameObject> prefabList = new List<GameObject>();
    public GameObject enemy1;                // The enemy prefab.
    public GameObject enemy2;                // The enemy prefab.
    public GameObject enemy3;                // The enemy prefab.
    public GameObject enemy4;                // The enemy prefab.
    public GameObject enemy5;                // The enemy prefab.
    public GameObject enemy6;                // The enemy prefab.

    public float spawnTime = 5f;            // Time duration between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.


    void Start()
    {
        prefabList.Add(enemy1);
        prefabList.Add(enemy2);
        prefabList.Add(enemy3);
        prefabList.Add(enemy4);
        prefabList.Add(enemy5);
        prefabList.Add(enemy6);

        // spawntime delays the "Spawn" with 3sec and repeats.
        InvokeRepeating("Spawn", 2f, spawnTime);
    }


    void Spawn()
    {
        // Randomize order of the selected spawnpoints spawns.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        int prefabIndex = Random.Range(0, 6);

        // Creates an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(prefabList[prefabIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

    }
}
