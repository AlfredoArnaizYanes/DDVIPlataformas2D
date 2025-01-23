using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : Personaje
{
    [Header("Sistema de movimiento")]
    [SerializeField] private float fuerzaSalto;
    [SerializeField] private Transform piesPlayer;
    [SerializeField] private float distanciaDeteccionSuelo;
    [SerializeField] private LayerMask loQueEsSaltable;

    [Header("Daño por caida")]
    [SerializeField] private float velocidadMaxCaida;
    [SerializeField] private float danhoPorCaida;

    [Header("Sistema de ataque")]
    [SerializeField] private Transform puntoAtaque;
    [SerializeField] private float radioAtaque;
    [SerializeField] private LayerMask loQueEsDanhable;

    [Header("Barra de Vida")]
    [SerializeField] private Image barraVida;
    [SerializeField] private Image barraVidaColor;

    private Rigidbody2D rb;
    private float inputH;
    private Animator anim;
    private float velocidadAntesSuelo;
    private float vidaMaxima;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        vidaMaxima = vida;
        barraVida.gameObject.SetActive(true);
        Debug.Log("VidaMaxima es:" + vidaMaxima);
    }

    // Update is called once per frame
    void Update()
    {
        Salto();

        Movimiento();

        LanzarAtaque();

        DanhoCaida();

        EstoyMuerto();

        ActualizarBarraVida();        

        
        //barraVidaColor.fillAmount = vida / vidaMaxima;
    }
    
    private void ActualizarBarraVida()
    {
        barraVidaColor.fillAmount = vida / vidaMaxima;
        barraVidaColor.color = new Color((1 - (vida / vidaMaxima)), vida / vidaMaxima, 0, 1);
    }

    private void DanhoCaida()
    {
        if (!EstoyEnSuelo())
        {
            velocidadAntesSuelo = rb.velocity.y;
        }
        else
        {
            if (velocidadAntesSuelo < velocidadMaxCaida)
            {
                vida -= danhoPorCaida;
            }
            velocidadAntesSuelo = 0;
        }
    }

    private bool EstoyEnSuelo()
    {
        Debug.DrawRay(piesPlayer.position, Vector3.down, Color.yellow, 0.1f);
        return Physics2D.Raycast(piesPlayer.position, Vector3.down, distanciaDeteccionSuelo, loQueEsSaltable);
    }



    //Me pego a las plataformas cuando estoy sobre ellas
    private void OnCollisionEnter2D(Collision2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("Plataforma"))
        {
            transform.parent = elOtro.gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D elOtro)
    {
        transform.SetParent(null);
    }
    //FIN de Me pego a las plataformas cuando estoy sobre ellas


    //El player ataca
    private void LanzarAtaque()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("attack");
        }
    }
            //Se ejecuta desde evento de animacion
    private void Ataque()
    {
        Collider2D[] collidersTocados = Physics2D.OverlapCircleAll(puntoAtaque.position, radioAtaque, loQueEsDanhable);
        foreach(Collider2D item in collidersTocados)
        {
            Enemigo myEnemigo = item.gameObject.GetComponent<Enemigo>();
            if (myEnemigo != null)
            {
                myEnemigo.Vida -= danhoCausado;
            }
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(puntoAtaque.position, radioAtaque);
    }
    //FIN del player ataca
    private void Movimiento()
    {
        inputH = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector3(inputH * velocidadMovimiento, rb.velocity.y);
        if (inputH != 0)
        {
            anim.SetBool("running", true);
            if (inputH > 0)
            {
                transform.eulerAngles = Vector3.zero;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
        else
        {
            anim.SetBool("running", false);
        }
    }
    private void Salto()
    {

        if (Input.GetKeyDown(KeyCode.Space) && EstoyEnSuelo())
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            anim.SetTrigger("jumping");
        }
    }

}

