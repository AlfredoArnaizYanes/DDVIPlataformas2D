using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorEscenas : MonoBehaviour
{
    [SerializeField] private float duracionTransicion;
    private Animator animTransicion;

    // Start is called before the first frame update
    void Start()
    {
        animTransicion = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CargaProximaEscena() 
    {
        int proximaEscena = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(CargaEscena(proximaEscena));
    }

    IEnumerator CargaEscena(int indice) 
    {
        animTransicion.SetTrigger("Transitar");
        yield return new WaitForSeconds(duracionTransicion);
        SceneManager.LoadScene(indice);

    }
}

