using UnityEngine;

public class TargetFactory : MonoBehaviour, ITargetFactory
{
    public GameObject targetPrefab;
    public float spawnRadius = 10f;

    public void SpawnTarget()
    {
        Vector3 spawnPosition = GetRandomPosition();
        Instantiate(targetPrefab, spawnPosition, Quaternion.identity);
    }

    private Vector3 GetRandomPosition()
    {
        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
        return new Vector3(randomCircle.x, 0.5f, randomCircle.y); // Adjust Y height as needed
    }
}
