using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murcielago_Ataca : Estado<Murcielago_Controller>
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
    private Player myPlayer;

    public override void OnEnterState(Murcielago_Controller m_Controller)
    {
        Debug.Log("Atacar_Enter");
        base.OnEnterState(m_Controller);
        timer = tiempoEntreAtaques;

        myPlayer = FindObjectOfType<Player>();
      
        objetivoAtaque = myPlayer.transform;
        posicionInicial = this.gameObject.transform.position;
        ataqueFinalizado = false;

    }


    public override void OnUpdateState()
    {
        //Debug.Log("Atacar_Update");
        
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
            Controller.CambiaEstado(Controller.M_Persigue);
        }


    }
    public override void OnExitState()
    {
        //Debug.Log("Atacar_Exit");
    }

    private void OnTriggerEnter2D(Collider2D elOtro)
    {

        if (elOtro.gameObject.CompareTag("PlayerHitBox"))
        {
            //Debug.Log("TriggerEnterATAQUE ConPlayerHitBox");
            if(myPlayer != null)
            {
                myPlayer.sonidoDanho();
               
                myPlayer.Vida -= danhoCausado;
             
                ataqueFinalizado = true;
            }
            
            
        }

    }

}
