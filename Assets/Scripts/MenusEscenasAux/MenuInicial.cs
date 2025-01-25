using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    [SerializeField] private float duracionTransicion;
    private Animator animTransicion;
    

    void Start()
    {
        animTransicion = GetComponent<Animator>();
        
    }
    
    public void play()
    {
        StartCoroutine(CargaEscena(1));
        
    }
    public void exit()
    {
        Application.Quit();
    }

    public void controles()
    {
        StartCoroutine(CargaEscena(8));

    }



    IEnumerator CargaEscena(int indice)
    {
        animTransicion.SetTrigger("Transitar");
        Debug.Log("Ahora");
        yield return new WaitForSeconds(duracionTransicion);
        Debug.Log("Despues");
        SceneManager.LoadScene(indice);
    }
}
