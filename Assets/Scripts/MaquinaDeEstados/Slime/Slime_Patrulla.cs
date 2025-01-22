using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_Patrulla : Estado<Slime_Controller>
{
    [SerializeField] private Transform rutaPatrulla;
    [SerializeField] private float velocidadPatrulla;

    private Animator anim;

    private Vector3 destinoActual;
    private int indiceActual = 0;

    private List<Vector3> listadoPuntos = new List<Vector3>();
    public override void OnEnterState(Slime_Controller Controller)
    {
        Debug.Log("Patrulla_Enter");
        base.OnEnterState(Controller);
        foreach (Transform t in rutaPatrulla)
        {
            listadoPuntos.Add(t.position);
        }
        destinoActual = listadoPuntos[indiceActual];
        anim = GetComponent<Animator>();
        anim.SetBool("atacando", false);
    }

    public override void OnUpdateState()
    {
        Debug.Log("Patrulla_Update");
        EnfocarDestino();
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
        //EnfocarDestino();
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
        Debug.Log("Patrulla_Exit");
        listadoPuntos.Clear();
        indiceActual = 0;
    }

    private void OnTriggerEnter2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("DeteccionPlayer"))
        {

            Debug.Log("TriggerEnterPATRULLAConDeteccionPlayer");
            Controller.CambiaEstado(Controller.S_Persigue);
            //Animator anim = elOtro.gameObject.GetComponent<Animator>();

        }

    }






}
