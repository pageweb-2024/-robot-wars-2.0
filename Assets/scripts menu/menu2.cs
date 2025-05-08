using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menu2 : MonoBehaviour
{
    public void juego1()
    {
        SceneManager.LoadScene("juego");
    }

    public void MENU()
    {
        SceneManager.LoadScene("MENU");
    }

}
