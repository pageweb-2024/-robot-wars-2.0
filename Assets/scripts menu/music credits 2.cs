using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMusicController : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "CreditsScene") // Cambia "CreditsScene" por el nombre de tu escena
        {
            // Configura música para los créditos
            PlayCreditsMusic();
        }
        else
        {
            // Detén música o cambia a otra música según la escena
            StopCreditsMusic();
        }
    }

    private void PlayCreditsMusic()
    {
        // Lógica para iniciar la música de créditos
    }

    private void StopCreditsMusic()
    {
        // Lógica para detener la música de créditos
    }
}
