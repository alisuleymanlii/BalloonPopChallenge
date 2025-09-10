using UnityEngine;

public class spawner : MonoBehaviour
{
    [Header("Spawn olunacaq prefablar")]
    public GameObject[] prefabs; // birdən çox prefab

    [Header("Spawn nöqtələri")]
    public Transform[] spawnPoints;

    [Header("Spawn vaxtı")]
    public float spawnInterval = 0.6f; // başlanğıc interval
    public float minInterval = 0f; // minimum interval

    [Header("Intervalın azalma parametrləri")]
    public int decreaseStep = 3;      // neçə spawn sonra azalsın
    public float decreaseAmount = 0.2f; // nə qədər azalsın

    private float timer;
    private int spawnCount = 0;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }
    }

    void SpawnObject()
    {
        if (spawnPoints.Length == 0 || prefabs.Length == 0) return;

        // Random spawn nöqtəsi
        int randomPoint = Random.Range(0, spawnPoints.Length);

        // Random prefab seç
        int randomPrefab = Random.Range(0, prefabs.Length);

        Instantiate(prefabs[randomPrefab], spawnPoints[randomPoint].position, Quaternion.identity);

        spawnCount++;

        // müəyyən qədərdən bir intervalı azaldırıq
        if (spawnCount % decreaseStep == 0)
        {
            spawnInterval = Mathf.Clamp(spawnInterval - decreaseAmount, minInterval, 10f);
        }
    }
}
