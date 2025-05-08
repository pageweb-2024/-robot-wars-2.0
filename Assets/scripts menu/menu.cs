using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void EscenaMenu2()
    {
        SceneManager.LoadScene("menu2");
    }

    public void CREDITS()
    {
        SceneManager.LoadScene("creditos");
    }
}
