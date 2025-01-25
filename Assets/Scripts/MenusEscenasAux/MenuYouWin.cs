using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuYouWin : MonoBehaviour
{
    [SerializeField] private float duracionTransicion;
    private Animator animTransicion;

    
    public void Start()
    {
        animTransicion = GetComponentInChildren<Animator>();
    }
    public void credits()
    {
        StartCoroutine(CargaEscena(7));
    }
    public void exit()
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
