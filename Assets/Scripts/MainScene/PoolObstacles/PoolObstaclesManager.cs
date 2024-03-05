using System.Collections.Generic;
using UnityEngine;

public class PoolObstaclesManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstaclePrefabs;

    [SerializeField]
    private List<GameObject> pool;

    [SerializeField]
    private Transform poolParent;

    [SerializeField]
    private float timeReduceFactor;

    public float spawnTime = 1;

    public float Timer { get; set; }

    public void Awake()
    {
        Timer = spawnTime;

        foreach (GameObject prefab in obstaclePrefabs)
        {
            prefab.SetActive(false);
            AddNewPoolObject(prefab);
        }
    }

    void Update()
    {
        Timer -= Time.deltaTime;

        if (Player.IsAlive && Timer <= 0)
        {
            Timer = spawnTime;

            GameObject newObstacle = GetAvailable();
            if (newObstacle == null)
            {
                int randomIndex = Random.Range(0, obstaclePrefabs.Length);
                newObstacle = AddNewPoolObject(obstaclePrefabs[randomIndex]);
            }

            newObstacle.SetActive(true);
        }
    }

    public GameObject GetAvailable()
    {
        List<GameObject> allActiveObjects = pool.FindAll(x => !x.activeSelf);
        int randomIndex = Random.Range(0, allActiveObjects.Count);
        if (allActiveObjects.Count > 0)
        {
            return allActiveObjects[randomIndex];
        }
        else
        {
            AddNewPoolObject(obstaclePrefabs[randomIndex]);
        }

        return null;
    }

    public GameObject AddNewPoolObject(GameObject prefab)
    {
        GameObject newPoolObject = Instantiate(prefab, parent: poolParent);
        pool.Add(newPoolObject);
        return newPoolObject;
    }

    public void ReduceSpawnTimer()
    {
        spawnTime -= timeReduceFactor;
    }
}
