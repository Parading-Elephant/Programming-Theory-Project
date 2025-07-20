using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // ENCAPSULATION
    [SerializeField] private List<Ball> prefabSpawns;
    [SerializeField] private float spawnInterval;

    [SerializeField] private float xRange;
    [SerializeField] private float zRange;
    [SerializeField] private float spawnHeight;
    void Start()
    {
        InvokeRepeating("Spawn", 0f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        Ball ball = GetRandomBall();
        Instantiate(ball, GetRandomSpawnPos(), ball.transform.rotation);
    }

    // ABSTRACTION
    private Vector3 GetRandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), 20f, Random.Range(-zRange, zRange));
    }

    private Ball GetRandomBall()
    {
        int index = Random.Range(0, prefabSpawns.Capacity);
        return prefabSpawns[index];
    }
}