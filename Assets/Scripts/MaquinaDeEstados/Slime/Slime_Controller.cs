using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_Controller : Enemigo
{
    //ESTADOS DE LA MAQUINA DE ESTADOS

    private Slime_Patrulla s_Patrulla;
    private Slime_Ataca s_Ataca;
    private Slime_Persigue s_Persigue;

    private Estado<Slime_Controller> estadoActual;



    public Slime_Patrulla S_Patrulla { get => s_Patrulla; }
    public Slime_Ataca S_Ataca { get => s_Ataca; }
    public Slime_Persigue S_Persigue { get => s_Persigue; }

    // Start is called before the first frame update
    void Start()
    {
        s_Patrulla = GetComponent<Slime_Patrulla>();
        s_Ataca = GetComponent<Slime_Ataca>();
        s_Persigue = GetComponent<Slime_Persigue>();

        CambiaEstado(s_Patrulla);


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

    public void CambiaEstado(Estado<Slime_Controller> nuevoEstado)
    {
        if (estadoActual)
        {
            estadoActual.OnExitState();
        }
        estadoActual = nuevoEstado;
        estadoActual.OnEnterState(this);
    }


}
