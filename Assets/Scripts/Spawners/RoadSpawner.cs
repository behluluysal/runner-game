using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    private ObjectPooler _objectPooler;
    [SerializeField] private float groundSpawnDistance = 10f;

    private int _emptyRoadCount = 0;
    private int _roadCount = 0;
    private bool _hasFinishLineGenerated = false;

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
        GameObject Road;

        if (_roadCount >= LevelManager.Instance.RoadLenght)
        {
            if (_emptyRoadCount > LevelManager.Instance.EmptyRoadLength && !_hasFinishLineGenerated)
            {
                Road = _objectPooler.SpawnFromPool(PoolObjects.RoadWithFinishLine, new Vector3(0, 0, groundSpawnDistance), Quaternion.identity);
                _hasFinishLineGenerated = true;
                return;
            }
            _emptyRoadCount++;
            Road = _objectPooler.SpawnFromPool(PoolObjects.RoadEmpty, new Vector3(0, 0, groundSpawnDistance), Quaternion.identity);
            return;
        }
        _roadCount++;
        Road = _objectPooler.SpawnFromPool(PoolObjects.Road, new Vector3(0, 0, groundSpawnDistance), Quaternion.identity);
        int type = Random.Range(1, 3);
        ObstacleSpawner.Instance.SpawnObstacle(Road, type);
        GemSpawner.Instance.SpawnGem(Road, type);
    }
}
