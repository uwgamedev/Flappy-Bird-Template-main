using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    public float scrollSpeed = 2f; // Speed at which the background scrolls
    private float backgroundWidth;  // Width of the background

    private float screenLeftEdge;

    // References to the two background objects
    public GameObject otherBackground; // Set this in the Inspector for each background

    void Start()
    {
        // Calculate the width of the background sprite
        backgroundWidth = GetComponent<SpriteRenderer>().bounds.size.x;

        // Determine the left edge of the screen in world coordinates
        screenLeftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
    }

    void Update()
    {
        // Move the background to the left at the specified speed
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // Check if this background has moved completely off the screen to the left
        if (transform.position.x < screenLeftEdge - backgroundWidth / 2f)
        {
            // Move this background to the right of the other background to create the infinite loop effect
            float otherX = otherBackground.transform.position.x;
            transform.position = new Vector3(otherX + backgroundWidth, transform.position.y, transform.position.z);
        }
    }
}
