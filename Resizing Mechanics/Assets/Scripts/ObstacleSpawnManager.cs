using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnManager : MonoBehaviour
{
    [SerializeField] private float _spawnInterval = 1;
    [SerializeField] private Obstacle _obstaclePref;
    [SerializeField] private Vector3 _spawnPos;

    private int _poolCapacity = 20;
    private float _timer;
    private static Queue _obstacles;



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
        _timer += Time.deltaTime;
        if (_timer > _spawnInterval)
        {
            //  reset the timer
            _timer = _spawnInterval - _timer;

            PullObstacleFromPool();
        }
    }

    private void PullObstacleFromPool()
    {
        Obstacle obj = (Obstacle)_obstacles.Dequeue();
        obj.gameObject.SetActive(true);
    }



    public static void PushObstacleToPool(Obstacle obstacle)
    {
        _obstacles.Enqueue(obstacle);
        obstacle.gameObject.SetActive(false);
    }

}
