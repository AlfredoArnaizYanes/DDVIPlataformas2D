using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaVertical : Plataforma
{
    [SerializeField] private float posInicial;
    [SerializeField] private float posFinal;
    
    protected override void Moverse()
    {
        transform.Translate(Vector2.up * velocidadPlataforma * Time.deltaTime);
        if (transform.position.y < posInicial || transform.position.y > posFinal)
        {
            velocidadPlataforma *= -1;
        }
    }

    private void DelimitadorMovimiento()
    {
        float restrinigidaY = Mathf.Clamp(transform.position.y, posInicial, posFinal);
        transform.position = new Vector3(transform.position.x, restrinigidaY, 0);
    }

    private void OnTriggerEnter2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("DeteccionPlayer"))
        {
            velocidadPlataforma *= -1;
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        Moverse();
        DelimitadorMovimiento();
    }

}
