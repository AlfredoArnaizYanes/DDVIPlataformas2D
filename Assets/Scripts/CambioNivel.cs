using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioNivel : MonoBehaviour
{
    [SerializeField] private float duracionTransicion;
    private Animator animTransicion;
    private Player myPlayer;

    void Start()
    {
        animTransicion = GetComponent<Animator>();
        myPlayer = FindAnyObjectByType<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        if (myPlayer.CambioNivel)
        {
            StartCoroutine(CargaEscena(4));
        }
    }
    IEnumerator CargaEscena(int indice)
    {
        animTransicion.SetTrigger("Transitar");
        yield return new WaitForSeconds(duracionTransicion);
        SceneManager.LoadScene(indice);
    }
}
