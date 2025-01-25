using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_Persigue : Estado<Slime_Controller>
{
    private Transform destino;
    [SerializeField] float velocidadPersigue;
    [SerializeField] float distanciaPasoAtaque;
    [SerializeField] float limiteIzquierdo;
    [SerializeField] float limiteDerecho;
    private Rigidbody2D rb;
    private Player myPlayer;

    public override void OnEnterState(Slime_Controller Controller)
    {
        
        Debug.Log("Persigue_Enter");
        base.OnEnterState(Controller);
        myPlayer = FindObjectOfType<Player>();

        destino = myPlayer.transform;
        //destino = FindObjectOfType<Player>().transform;
        rb = GetComponent<Rigidbody2D>();
        if(rb != null)
        {
            Debug.Log("Lo tengo");
        }

    }

    public override void OnUpdateState()
    {
        Debug.Log("Persigue_Update");
        if (myPlayer != null)
        {
            EnfocarDestino();
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(destino.position.x, transform.position.y, destino.position.z), velocidadPersigue * Time.deltaTime);
            if (Vector3.Distance(transform.position, destino.position) <= distanciaPasoAtaque)
            {
                Controller.CambiaEstado(Controller.S_Ataca);
            }
            DelimitadorMovimiento();
        }
    }

    public override void OnExitState()
    {
        Debug.Log("Persigue_Exit");
    }

    private void EnfocarDestino()
    {
        
        if (destino.position.x > transform.position.x)
        {
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
        
    }

    private void DelimitadorMovimiento()
    {
        float restringidaX = Mathf.Clamp(transform.position.x, limiteIzquierdo, limiteDerecho);
        transform.position = new Vector3(restringidaX, transform.position.y, 0);
    }

    private void OnTriggerExit2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("DeteccionPlayer"))
        {
            Debug.Log("TriggerExitPERSIGEConDeteccionPlayer");
            
            Controller.CambiaEstado(Controller.S_Patrulla);
        }
    }
}
