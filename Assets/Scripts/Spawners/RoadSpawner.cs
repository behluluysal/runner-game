using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    private ObjectPooler _objectPooler;
    [SerializeField] private float groundSpawnDistance = 10f;

    public static RoadSpawner Instance;
    private void Awake()
    {
       
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        _objectPooler = ObjectPooler.Instance;
        _objectPooler.SpawnFromPool(PoolObjects.Road, new Vector3(0, 0, 0), Quaternion.identity);
        _objectPooler.SpawnFromPool(PoolObjects.Road, new Vector3(0, 0, 7.62f), Quaternion.identity);
        _objectPooler.SpawnFromPool(PoolObjects.Road, new Vector3(0, 0, 15.24f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnGround()
    {
        GameObject Road = _objectPooler.SpawnFromPool(PoolObjects.Road, new Vector3(0, 0, groundSpawnDistance), Quaternion.identity);
        int type = Random.Range(1, 3);
        ObstacleSpawner.Instance.SpawnObstacle(Road, type);
        GemSpawner.Instance.SpawnGem(Road, type);
    }
}
