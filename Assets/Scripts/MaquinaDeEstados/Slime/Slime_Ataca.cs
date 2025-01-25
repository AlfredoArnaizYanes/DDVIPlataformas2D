using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_Ataca : Estado<Slime_Controller>
{
    [SerializeField] float distanciaAtaque;
    [SerializeField] float tiempoEntreAtaques;
    [SerializeField] float velocidadAtaque;
    [SerializeField] float danhoCausado;

   

    private float timer;
    private Transform objetivoAtaque;
    private Vector3 posicionInicial;
    private bool ataqueRetirada;
    private bool ataqueFinalizado;
    private Animator anim;
    private Player myPlayer;

    public override void OnEnterState(Slime_Controller m_Controller)
    {
        //Debug.Log("AtacarSlime_Enter");
        base.OnEnterState(m_Controller);
        timer = tiempoEntreAtaques;

        myPlayer = FindObjectOfType<Player>();
        objetivoAtaque = myPlayer.transform;
        posicionInicial = this.gameObject.transform.position;
        ataqueFinalizado = false;
        anim = GetComponent<Animator>();
        anim.SetBool("atacando", true);

    }


    public override void OnUpdateState()
    {
        //Debug.Log("AtacarSlime_Update");

        timer += Time.deltaTime;

        if (timer >= tiempoEntreAtaques)
        {


            if (!ataqueFinalizado)
            {
                transform.position = Vector3.MoveTowards(transform.position, objetivoAtaque.position, velocidadAtaque * Time.deltaTime);
            }
            else
            {

                transform.position = Vector3.MoveTowards(transform.position, posicionInicial, velocidadAtaque * Time.deltaTime);

            }
            if (ataqueFinalizado && transform.position == posicionInicial)
            {
                timer = 0;
                ataqueFinalizado = false;
            }


        }

        if (Vector3.Distance(transform.position, objetivoAtaque.position) >= distanciaAtaque)
        {
                Controller.CambiaEstado(Controller.S_Persigue);   
        }


    }
    public override void OnExitState()
    {
        //Debug.Log("AtacarSlime_Exit");
    }

    

    private void OnTriggerEnter2D(Collider2D elOtro)
    {

        if (elOtro.gameObject.CompareTag("PlayerHitBox"))
        {
            //Debug.Log("TriggerEnterATAQUE ConPlayerHitBox");
            myPlayer.sonidoDanho();
            myPlayer.Vida -= danhoCausado;
            ataqueFinalizado = true;

        }

    }

}
