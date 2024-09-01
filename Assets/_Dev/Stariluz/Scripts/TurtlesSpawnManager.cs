using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TurtlesSpawnManager : MonoBehaviour
{
    [SerializeField] protected GameObject prefab;
    [SerializeField] protected Transform container;
    [SerializeField] protected TurtlesSpawner spawnerLeft;
    [SerializeField] protected TurtlesSpawner spawnerRight;

    [SerializeField] protected float minWaitTime = 0.5f;
    [SerializeField] protected float maxWaitTime = 2f;
    protected float waitTime = 0;
    protected bool allowSpawn = true;

    void Start()
    {
    }
    void Update()
    {
        if (allowSpawn)
        {
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                TurtlesSpawner origin = GetRandomSpawner();
                Vector3 position = GetRandomSpawnPosition(origin.transform.position);
                GameObject turtle = Instantiate(
                    prefab,
                    position,
                    origin.transform.rotation,
                    container
                );
                turtle.GetComponent<Turtle>().isMovementToRight = origin.isMovementToRight;

                waitTime = GetRandomWaitTime();
                // Debug.Log(("Dev | Wait time : ", waitTime));
            }
        }
    }
    float GetRandomWaitTime()
    {
        // Return a random wait time between minWaitTime and maxWaitTime
        return Random.Range(minWaitTime, maxWaitTime);
    }
    TurtlesSpawner GetRandomSpawner()
    {
        // Randomly return spawnerLeft or spawnerRight
        return Random.value < 0.5f ? spawnerLeft : spawnerRight;
    }
    Vector3 GetRandomSpawnPosition(Vector3 origin)
    {
        // Get the camera height (orthographicSize if using an orthographic camera)
        float cameraHeight = Camera.main.orthographicSize * 2f;

        // Calculate the range for y based on the top half of the screen
        float minY = origin.y;
        float maxY = origin.y + cameraHeight / 2f + 1;

        // Generate a random y value between minY and maxY
        float randomY = Random.Range(minY, maxY);

        // Return the random position with the same x and z, but with the randomized y
        return new Vector3(origin.x, randomY, 0);
    }

    public void Stop()
    {
        allowSpawn = false;
    }
}
