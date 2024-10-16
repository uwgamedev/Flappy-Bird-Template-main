using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Uncomment to play your theme song!
        // audioSource.loop = true;  // Set the audio source to loop
        // audioSource.Play();       // Play the audio
    }
}
