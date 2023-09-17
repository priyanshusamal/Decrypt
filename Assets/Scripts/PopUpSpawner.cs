using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpSpawner : MonoBehaviour
{
    public GameObject[] objectPrefabs; // Array of game objects to spawn
    public int numberOfObjectsToSpawn = 10; // Number of objects to spawn
    public Vector2 spawnRangeX = new Vector2(-5f, 5f); // X-axis range
    public Vector2 spawnRangeY = new Vector2(-5f, 5f); // Y-axis range
    public float fixedZPosition = 0f; // Fixed Z-axis position

    void Start()
    {
        // Spawn the specified number of random objects
        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            // Randomly select a game object from the list
            GameObject selectedObject = objectPrefabs[Random.Range(0, objectPrefabs.Length)];

            // Randomly determine the spawn position within the specified range
            Vector3 spawnPosition = new Vector3(fixedZPosition
                ,
                Random.Range(spawnRangeY.x, spawnRangeY.y),
                Random.Range(spawnRangeX.x, spawnRangeX.y)
            );

            // Instantiate the selected object at the spawn position
            Instantiate(selectedObject, spawnPosition, Quaternion.Euler(0,-90,0));
        }
    }
}
