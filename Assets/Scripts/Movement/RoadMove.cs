using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMove : MonoBehaviour
{

    [SerializeField] private float Speed = 5;
    [SerializeField] private float _objectDistance = -10f;
    [SerializeField] private float _despawnDistance = -20f;

    private bool _canSpawnGround = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoveRoad();
    }
    private void MoveRoad()
    {
        if(GameManager.Instance.State != GameManager.GameState.PlayerTurn)
        {
            return;
        }

        transform.position += -Vector3.forward * Time.deltaTime * Speed;
        if(transform.position.z <= _objectDistance && _canSpawnGround)
        {
            RoadSpawner.Instance.SpawnGround();
            _canSpawnGround = false;
        }
        
        if(transform.position.z <= _despawnDistance)
        {
            _canSpawnGround = true;
            ObstacleSpawner.Instance.SetObstaclesFalse(transform.gameObject);
            GemSpawner.Instance.SetGemsFalse(transform.gameObject);
            gameObject.SetActive(false);
        }
    }
}
