using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    // -------------Variables ---------------
    // Stores the rigidbody and audiosource components that we will use
    private Rigidbody2D rb;
    private AudioSource audioSource;

    private float screenBottom;

    // Set or change these variables in the editor!
    public float jumpAmount;
    public AudioClip flapSound;
    public AudioClip pipeCrashSound;
    // --------------------------------------


    void Start()
    {
        // Accesses the components from the player gameobject
        // Note: we don't have to access the public variables because we set them
        // in the editor
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        screenBottom = Camera.main.ViewportToWorldPoint(Vector3.zero).y;
    }

    void Update()
    {
        // If the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Jump
            rb.velocity = new Vector2(0, jumpAmount);

            // Uncomment this to play your sound!
            // audioSource.clip = flapSound;
            // audioSource.Play();
        }

        // If player is below the screen
        if (transform.position.y <= screenBottom - 1f)
        {
            // Restart game
            RestartGame();
        }
    }

    // Checks if the player collider overlaps with another collider
    void OnTriggerEnter2D(Collider2D collision)
    {
        // We entered this method, there is overlap
        // Check if it's overlapping with the pipe collider via the tag we set in the editor
        if (collision.gameObject.tag == "PipeObject")
        {
            // Uncomment this to play your sound!
            // audioSource.clip = flapSound;
            // audioSource.Play();

            // We hit a pipe. Restart game
            RestartGame();
        }
    }

    private void RestartGame()
    {
        // Restarts our current game scene (resets the game)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
