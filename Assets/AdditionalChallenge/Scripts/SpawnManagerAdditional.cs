using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerAdditional : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2f;
    private float repeatDelay = 2f;
    private PlayerControllerAdditional playerControllerScript;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnRandomObstacle), startDelay, repeatDelay);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerAdditional>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnRandomObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            int prefabIndex = Random.Range(0, obstaclePrefab.Length);
            Instantiate(obstaclePrefab[prefabIndex], spawnPos, obstaclePrefab[prefabIndex].transform.rotation);

        }

    }
}
