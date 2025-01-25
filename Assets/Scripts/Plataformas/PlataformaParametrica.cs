using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaParametrica : Plataforma
{
    [SerializeField] private float anguloInicial;
    [SerializeField] private Transform centro;
    [SerializeField] private float radio;
    [SerializeField] private float parametro;
  
    
    private float t;

    //[SerializeField] private Vector2 posInicial;
    protected override void Moverse()
    {
        anguloInicial += velocidadPlataforma * Time.deltaTime;
        t = anguloInicial*Mathf.Deg2Rad;
        transform.position = new Vector3(centro.position.x + radio * Mathf.Cos(t)-Mathf.Cos(5*t), 
            centro.position.y + radio * Mathf.Sin(t)-Mathf.Sin(parametro*t), 0);
    }

    

    // Update is called once per frame
    void Update()
    {
        Moverse();
    }
}
