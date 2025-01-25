using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murcielago_Patrulla : Estado<Murcielago_Controller>
{
    [SerializeField] private Transform rutaPatrulla;
    [SerializeField] private float velocidadPatrulla;

    private Vector3 destinoActual;
    private int indiceActual = 0;
    private Animator anim;

    private List<Vector3> listadoPuntos = new List<Vector3>();
    public override void OnEnterState(Murcielago_Controller Controller)
    {
        //Debug.Log("Patrulla_Enter");
        base.OnEnterState(Controller);
        anim = GetComponent<Animator>();
        anim.SetBool("perseguir", false);
        foreach (Transform t in rutaPatrulla)
        {
            listadoPuntos.Add(t.position);
        }
        destinoActual = listadoPuntos[indiceActual];
    }

    public override void OnUpdateState()
    {
        //Debug.Log("Patrulla_Update");
        transform.position = Vector3.MoveTowards(transform.position, destinoActual, velocidadPatrulla * Time.deltaTime);
        if (transform.position == destinoActual)
        {
            DefinirNuevoDestino();
        }
    }

    private void DefinirNuevoDestino()
    {
        indiceActual++;
        if (indiceActual >= listadoPuntos.Count)
        {
            indiceActual = 0;
        }
        destinoActual = listadoPuntos[indiceActual];
        EnfocarDestino();
    }

    private void EnfocarDestino()
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

    public override void OnExitState()
    {
        //Debug.Log("Patrulla_Exit");
        listadoPuntos.Clear();
        indiceActual = 0;
    }

    private void OnTriggerEnter2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("DeteccionPlayer"))
        {

            Debug.Log("TriggerEnterPATRULLAConDeteccionPlayer");
            Controller.CambiaEstado(Controller.M_Persigue);
        

        }
        
        
    }
}
