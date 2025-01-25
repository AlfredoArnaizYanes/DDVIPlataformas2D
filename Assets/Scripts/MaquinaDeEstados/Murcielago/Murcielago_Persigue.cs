using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murcielago_Persigue : Estado<Murcielago_Controller>
{
    private Transform destino;
    [SerializeField] float velocidadPersigue;
    [SerializeField] float distanciaPasoAtaque;
    private Animator anim;

    public override void OnEnterState(Murcielago_Controller Controller)
    {
        //Debug.Log("Persigue_Enter");
        base.OnEnterState(Controller);
        destino = FindObjectOfType<Player>().transform;
        anim = GetComponent<Animator>();
        anim.SetBool("perseguir", true);

    }

    public override void OnUpdateState()
    {
        
        //Debug.Log("Persigue_Update");
        transform.position = Vector3.MoveTowards(transform.position, destino.position, velocidadPersigue * Time.deltaTime);
        if (Vector3.Distance(transform.position, destino.position) <= distanciaPasoAtaque)
        {
            Controller.CambiaEstado(Controller.M_Ataca);
        }
        
    }

    public override void OnExitState()
    {
        //Debug.Log("Persigue_Exit");
    }



    private void OnTriggerExit2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("DeteccionPlayer"))
        {
            //Debug.Log("TriggerExitPERSIGEConDeteccionPlayer");
            Controller.CambiaEstado(Controller.M_Patrulla);
        }
    }
}
