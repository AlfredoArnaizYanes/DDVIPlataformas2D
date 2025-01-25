using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controles : MonoBehaviour
{
    [SerializeField] private float duracionTransicion;
    private Animator animTransicion;


    public void Start()
    {
        animTransicion = GetComponentInChildren<Animator>();
    }
    public void back()
    {
        StartCoroutine(CargaEscena(0));
    }
    

    IEnumerator CargaEscena(int indice)
    {
        animTransicion.SetTrigger("Transitar");
        yield return new WaitForSeconds(duracionTransicion);
        SceneManager.LoadScene(indice);
    }
}
