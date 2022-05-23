using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLenght = 36;
    public float spawnCount = 2;
    public Transform playerTranform;

    
    void Start()
    {
        SpawnTile(Random.Range(0, tilePrefabs.Length));

    }

    void Update()
    {
        if (playerTranform.position.z >= (zSpawn - 40))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
        }
    }



    public void SpawnTile(int tileIndex)
    {
        Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        zSpawn += tileLenght;
        PlayerController.velocity++;
    }
}
