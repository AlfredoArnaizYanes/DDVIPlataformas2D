using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Carta2 : MonoBehaviour
{
    [SerializeField] private float duracionTransicion;
    private Animator animTransicion;

    void Start()
    {
        animTransicion = GetComponentInChildren<Animator>();
    }
    public void Play()
    {
        StartCoroutine(CargaEscena(3));
    }

    IEnumerator CargaEscena(int indice)
    {
        animTransicion.SetTrigger("Transitar");
        yield return new WaitForSeconds(duracionTransicion);
        SceneManager.LoadScene(indice);
    }
}
