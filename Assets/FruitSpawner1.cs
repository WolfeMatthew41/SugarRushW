using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FruitSpawner1 : MonoBehaviour
{

    public string spawnPointTag = "FruitSpawnPoint";
    public bool freeSpawn = true;

    [SerializeField]
    public float spawnTimer = 5.0f;

    private float _timeLeft =30.0f;

    [SerializeField]
    public List<GameObject> fruitSelection;

    public static event Action onDespawn;

    // Start is called before the first frame update
    void Start()
    {
        SpawnFruit();
    }

    // Update is called once per frame
    void Update()
    {
        if (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
        }
        else
        {
            onDespawn?.Invoke();
            SpawnFruit();
        }
    }

    private void SpawnFruit()
    {
        _timeLeft = spawnTimer;

        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag(spawnPointTag);
        foreach (GameObject spawnPoint in spawnPoints)
        {
            int randomSpawnPoint = UnityEngine.Random.Range(0, fruitSelection.Count);

            int spawnOrNot = UnityEngine.Random.Range(0, 2);
            //if(spawnOrNot==0)

            GameObject pts = Instantiate(fruitSelection[randomSpawnPoint]);
            pts.transform.position = spawnPoint.transform.position;
        }
    }

}
