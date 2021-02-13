using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnManager : MonoBehaviour
{
    [SerializeField] private float _spawnInterval = 1;
    [SerializeField] private Obstacle _obstaclePref;
    [SerializeField] private Vector3 _spawnPos = new Vector3(0,0,100);

    private int _poolCapacity = 20;
    private float _timer;
    private static Queue _obstacles;
    private bool _firstObstacle = true;


    private void Awake()
    {
        _obstacles = new Queue();
        for (int i = 0; i < _poolCapacity; i++)
        {
            Obstacle obj = Instantiate(_obstaclePref, _spawnPos, Quaternion.identity);

            obj.gameObject.SetActive(false);

            _obstacles.Enqueue(obj);
        }
    }

    private void Update()
    {
        if (GameManager.IsPlaying)
        {
            if (_firstObstacle)
            {
                SendFirstObstacle();
            }
            _timer += Time.deltaTime;
            if (_timer > _spawnInterval)
            {
                //  reset the timer
                _timer = _spawnInterval - _timer;

                PullObstacleFromPool();
            }
        }
        
    }

    private void PullObstacleFromPool()
    {
        Obstacle obj = (Obstacle)_obstacles.Dequeue();
        obj.gameObject.SetActive(true);
        obj.StartMoving();
    }

    private void SendFirstObstacle()
    {
        PullObstacleFromPool();
        _firstObstacle = false;
    }

    public static void PushObstacleToPool(Obstacle obstacle)
    {
        obstacle.gameObject.transform.position = new Vector3(0,0,100);
        obstacle.gameObject.SetActive(false);
        _obstacles.Enqueue(obstacle);
        
    }

}
