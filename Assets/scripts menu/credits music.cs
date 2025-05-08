using UnityEngine;

public class CreditMusicManager : MonoBehaviour
{
    private void Awake()
    {
        // Asegura que solo haya una música para esta escena
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}


