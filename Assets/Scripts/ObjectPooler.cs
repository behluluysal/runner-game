using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
	public PoolObjects tag;
	public GameObject prefab;
	public int size;
}


public class ObjectPooler : MonoBehaviour
{

    public static ObjectPooler Instance;
    private void Awake()
    {
        Instance = this;
    }


    public List<Pool> pools;
	public Dictionary<PoolObjects, Queue<GameObject>> poolDictionary;

    void Start()
    {
		poolDictionary = new Dictionary<PoolObjects, Queue<GameObject>>();

        foreach (var pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(PoolObjects tag, Vector3 position, Quaternion rotation)
    {
        if(!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning($"Pool with tag {tag} doesnt exists");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        IPooledObjects pooledObject = objectToSpawn.GetComponent<IPooledObjects>();
        if(pooledObject != null)
        {
            pooledObject.OnObjectSpawn();
        }
        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}