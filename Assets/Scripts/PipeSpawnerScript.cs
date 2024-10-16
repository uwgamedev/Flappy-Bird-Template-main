using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    // Pipe object (set in the editor)
    public GameObject pipe;

    // Delay between each pipe spawn in seconds (set in the editor)
    public float spawnDelay;

    // Timer variable to keep track of time (in seconds)
    private float timer;

    void Start()
    {
        timer = spawnDelay;
    }

    void Update()
    {
        // Check if timer is greater than or equal to spawn delay
        if (timer >= spawnDelay) {
            // Spawn a pipe gameobject
            Instantiate(pipe);

            // Reset timer
            timer = 0f;
        } else
        {
            // Increase timer by this frame's duration
            // Doing this makes "timer" act like a real-world timer
            timer += Time.deltaTime;
        }
    }
}
