using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murcielago : EnemigoMovil
{
    [SerializeField] private Transform[] puntosPatrulla;
    private Vector3 destinoActual;
    private int indiceActual = 1;
    //private float alturaPasillo = 3.52f;



    // Start is called before the first frame update
    void Start()
    {
        destinoActual = puntosPatrulla[indiceActual].position;
        patrullando();
    }

    // Update is called once per frame
    void Update()
    {
        EstoyMuerto();
    }

    //LÓGICA DE PATRULLA DEL MURCIELAGO
    protected override void patrullando()
    {
        StartCoroutine(Patrulla());
    }
    IEnumerator Patrulla()
    {
        while (true)
        {
            

            while (transform.position != destinoActual)
            {
                transform.position = Vector3.MoveTowards(transform.position, destinoActual, velocidadMovimiento * Time.deltaTime);
                yield return null;
            }
            DefinirNuevoDestino();
            EnfocarDestino();
        }

    }

    private void DefinirNuevoDestino()
    {
        indiceActual++;
        if (indiceActual >= puntosPatrulla.Length)
        {
            indiceActual = 0;
        }
        destinoActual = puntosPatrulla[indiceActual].position;
    }

    private void EnfocarDestino()
    {
        if (transform.localEulerAngles.z == 0)
        {
            if (destinoActual.x > transform.position.x)
            {
                transform.localScale = Vector3.one;
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            if (destinoActual.x < transform.position.x)
            {
                transform.localScale = Vector3.one;
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }
    // FIN LÓGICA DE PATRULLA DEL MURCIELAGO

    private void OnTriggerEnter2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("DeteccionPlayer"))
        {
            Debug.Log("He detectado al player");
        }
        else if (elOtro.gameObject.CompareTag("PlayerHitBox"))
        {
            Player myPlayer = elOtro.gameObject.GetComponent<Player>();
            myPlayer.Vida -= danhoCausado;
        }
    }
    
}
