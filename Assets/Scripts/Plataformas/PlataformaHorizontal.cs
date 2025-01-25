using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaHorizontal : Plataforma
{
    [SerializeField] private float posInicial;
    [SerializeField] private float posFinal;
    protected override void Moverse ()
    {
        transform.Translate(Vector2.left * velocidadPlataforma * Time.deltaTime);
        if (transform.position.x <= posInicial || transform.position.x >= posFinal) 
        {
            velocidadPlataforma *= -1;   
        }   
    }

    private void DelimitadorMovimiento()
    {
        float restringidaX = Mathf.Clamp(transform.position.x, posInicial, posFinal);
        transform.position = new Vector3(restringidaX, transform.position.y, 0);
    }


   

    // Update is called once per frame
    void Update()
    {
        Moverse();
        DelimitadorMovimiento();
    }

}
