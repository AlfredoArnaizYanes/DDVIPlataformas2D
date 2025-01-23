using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Mago_Patrulla : Estado<Mago_Controller>
{

    private bool detectado = false;
    public override void OnEnterState(Mago_Controller Controller)
    {
        Debug.Log("Patrulla_Enter");
        base.OnEnterState(Controller);

    }
    public override void OnUpdateState()
    {
        Debug.Log("Patrulla_Update");

    }


    public override void OnExitState()
    {
        Debug.Log("Patrulla_Exit");

    }

    private void OnTriggerEnter2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("DeteccionPlayer") && !detectado)
        {

            Debug.Log("TriggerEnterPATRULLAConDeteccionPlayer");
            Controller.CambiaEstado(Controller.W_Ataca);
            detectado = true;

        }


    }

}