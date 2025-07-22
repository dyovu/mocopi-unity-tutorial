
// using System.Numerics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject obstacleBar;
    [SerializeField] private float spawnRate = 2f;
    private float timer = 0;

    void Update()
    {
        if (Time.timeScale == 0) return; // ゲームが停止していたら何もしない

        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnObstacleBar();
            timer = 0;
        }
    }

    void SpawnObstacleBar()
    {
        float[] spawnHeights = { 1.6f, 0.6f }; // 上段と下段
        float randomHeight = spawnHeights[Random.Range(0, spawnHeights.Length)];
        Vector3 spawnPos = new Vector3(0, randomHeight, 15f);
        Quaternion spawnRotation = Quaternion.Euler(0, 0, 90);
        Instantiate(obstacleBar, spawnPos, spawnRotation);
    }
}