using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Carta1 : MonoBehaviour
{
    public void Continue()
    {
        SceneManager.LoadScene("Carta2");
    }

    public void Skip()
    {
        SceneManager.LoadScene("NivelJuego");
    }
}
