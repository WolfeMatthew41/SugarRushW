using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner1 : MonoBehaviour
{

    public string spawnPointTag = "FruitSpawnPoint";
    public bool freeSpawn = true;

    [SerializeField]
    public float spawnTimer = 5.0f;

    [SerializeField]
    public List<GameObject> fruitSelection;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag(spawnPointTag);
        foreach(GameObject spawnPoint in spawnPoints)
        {
            int randomSpawnPoint = Random.Range(0, fruitSelection.Count);

            int spawnOrNot = Random.Range(0, 2);
            //if(spawnOrNot==0)

            GameObject pts = Instantiate(fruitSelection[randomSpawnPoint]);
            pts.transform.position = spawnPoint.transform.position;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
