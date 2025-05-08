using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicaPersistente : MonoBehaviour
{
    private static MusicaPersistente instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Evita que el objeto se destruya al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Si ya existe una instancia, destruye la nueva
        }
    }

    void Update()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        // Destruye el objeto si estás en la escena "juego" o "creditos"
        if (sceneName == "juego" || sceneName == "creditos")
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop(); // Detiene la música
            }
            Destroy(gameObject); // Destruye el objeto
        }
    }
}

