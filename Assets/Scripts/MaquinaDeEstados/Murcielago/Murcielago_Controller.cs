using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murcielago_Controller : Enemigo
{
    
    //ESTADOS DE LA MAQUINA DE ESTADOS

    private Murcielago_Patrulla m_Patrulla;
    private Murcielago_Ataca m_Ataca;
    private Murcielago_Persigue m_Persigue;

    private Estado<Murcielago_Controller> estadoActual;
    //private Animator anim;



    public Murcielago_Patrulla M_Patrulla { get => m_Patrulla; }
    public Murcielago_Ataca M_Ataca { get => m_Ataca; }
    public Murcielago_Persigue M_Persigue { get => m_Persigue; }

    // Start is called before the first frame update
    void Start()
    {
        m_Patrulla = GetComponent<Murcielago_Patrulla>();
        m_Ataca = GetComponent<Murcielago_Ataca>();
        m_Persigue = GetComponent<Murcielago_Persigue>();
        

        CambiaEstado(m_Patrulla);

       
    }

    // Update is called once per frame
    void Update()
    {

        if (estadoActual)
        {
            estadoActual.OnUpdateState();
        }
        EstoyMuerto();
    }

    public void CambiaEstado(Estado<Murcielago_Controller> nuevoEstado)
    {
        if (estadoActual)
        {
            estadoActual.OnExitState();
        }
        estadoActual = nuevoEstado;
        estadoActual.OnEnterState(this);
        if (estadoActual == M_Persigue)
        {
            Debug.Log("Empiezo a perseguir");
            //anim.SetTrigger("atacar");
            //Animator anim = elOtro.gameObject.GetComponent<Animator>();
        }
    }

    //EN MUY ESCASAS OCASIONES ATACAMOS CON TANTA RAPIDEZ QUE A NUESTRO MURCIELAGO NO LE DA TIEMPO DE PASAR AL ESTADO DE ATAQUE, QUE
    //ES DONDE GESTIONABA LA COLISIÓN CON EL PLAYER, Y ME DABA ALGÚN PROBLEMA DE Null Reference QUE SE HA SOLUCIONADO GESTIONANDO TAMBIÉN
    //LA COLISION DESDE EL CONTROLLER
    private void OnTriggerEnter2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("PlayerHitBox"))
        {
            Player myPlayer = elOtro.gameObject.GetComponent<Player>();
            myPlayer.sonidoDanho();
            myPlayer.Vida -= danhoCausado;
        }
    }

}
