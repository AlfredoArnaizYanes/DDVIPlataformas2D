using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameOver : MonoBehaviour
{

    [SerializeField] private float duracionTransicion;
    private Animator animTransicion;

    public void Start()
    {
        animTransicion = GetComponentInChildren<Animator>();
    }
    public void Reiniciar()
    {
        StartCoroutine(CargaEscena(3));
    }

    public void MenuInicial()
    {
        StartCoroutine(CargaEscena(0));
    }

    public void Salir()
    {
        Application.Quit();
    }
    IEnumerator CargaEscena(int indice)
    {
        animTransicion.SetTrigger("Transitar");
        yield return new WaitForSeconds(duracionTransicion);
        SceneManager.LoadScene(indice);
    }
}
