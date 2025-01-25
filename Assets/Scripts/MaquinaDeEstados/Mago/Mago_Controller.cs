using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mago_Controller : Enemigo
{
    //ESTADOS DE LA MAQUINA DE ESTADOS

    private Mago_Patrulla w_Patrulla;
    private Mago_Ataca w_Ataca;
    private Mago_Persigue w_Persigue;

    private Estado<Mago_Controller> estadoActual;

    public Mago_Patrulla W_Patrulla { get => w_Patrulla; }
    public Mago_Ataca W_Ataca { get => w_Ataca; }
    public Mago_Persigue W_Persigue { get => w_Persigue; }

    // Start is called before the first frame update
    void Start()
    {
        w_Patrulla = GetComponent<Mago_Patrulla>();
        w_Ataca = GetComponent<Mago_Ataca>();
        w_Persigue = GetComponent<Mago_Persigue>();

        CambiaEstado(w_Patrulla);
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

    public void CambiaEstado(Estado<Mago_Controller> nuevoEstado)
    {
        if (estadoActual)
        {
            estadoActual.OnExitState();
        }
        estadoActual = nuevoEstado;
        estadoActual.OnEnterState(this);
        
    }

    private void OnTriggerEnter2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("PlayerHitBox"))
        {
            Player myPlayer = elOtro.gameObject.GetComponent<Player>();
            myPlayer.Vida -= danhoCausado;
        }
    }


}

