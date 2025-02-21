using UnityEngine;

public class PlaySoundOnEnter : MonoBehaviour
{
    
    AudioSource source;
    Collider2D soundTrigger;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        source = GetComponent<AudioSource>();
        soundTrigger = GetComponent<Collider2D>();
        source.playOnAwake = false; // Pastikan suara tidak otomatis menyala
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        source.Play();
    }
}

//problem: soundnya nyala pas play