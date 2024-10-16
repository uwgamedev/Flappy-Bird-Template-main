using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    // This value is set in the "Pipe" gameobject in the editor
    public float moveSpeed;

    // Sets "randYSpawn" to a float value of 2.5 (put simply, floats are numbers with decimals)
    private float randYSpawn = 2.5f; // You want to put an 'f' after typing a float value

    private float screenRightEdge;
    private float screenLeftEdge;

    // Start is called once when the game is run
    void Start()
    {
        // Get right and left edge of screen in world coordinates
        // Viewport coordinates go from 0 to 1 in all axes, so (0,0) is bottom left and (1,1) is top right
        // We convert from viewport to world coordinates (which is the "game's" coordinate system)
        screenRightEdge = Camera.main.ViewportToWorldPoint(Vector3.right).x;
        screenLeftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero).x;

        // Set "yPos" to a random number between -2.5 and 2.5
        float yPos = Random.Range(-randYSpawn, randYSpawn);

        // Set position of object in x,y,z coordinates
        transform.position = new Vector3(screenRightEdge, yPos, transform.position.z); // Vector3 is an (x,y,z) coordinate
    }

    // Update is called once per frame
    void Update()
    {
        // Move the pipe to the left
        // Make sure to multiply by Time.deltaTime for "normalized" movement!
        transform.position -= new Vector3(moveSpeed, 0, 0) * Time.deltaTime;

        // Check if reaching the left edge of the screen
        if (transform.position.x < screenLeftEdge)
        {
            // Destroy itself after 1 second (for some leeway)
            Destroy(gameObject, 1f);
        }
    }
}
