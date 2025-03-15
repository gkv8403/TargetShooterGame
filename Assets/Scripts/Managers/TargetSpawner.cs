using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public float spawnInterval = 2f;
    private float timer;

    private ITargetFactory targetFactory;

    private void Awake()
    {
        targetFactory = GetComponent<TargetFactory>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            targetFactory.SpawnTarget();
            timer = 0f;
        }
    }
}
