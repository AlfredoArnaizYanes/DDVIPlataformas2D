using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaGiratoria : Plataforma
{
    [SerializeField] private float anguloInicial;
    [SerializeField] private Transform centro;
    [SerializeField] private float radio;
    
   

    
    protected override void Moverse()
    {
        anguloInicial += velocidadPlataforma * Time.deltaTime;
        transform.position = new Vector3(centro.position.x + radio * Mathf.Cos(anguloInicial*Mathf.Deg2Rad), centro.position.y + radio * Mathf.Sin(anguloInicial * Mathf.Deg2Rad), 0);
    }

   
   

    // Update is called once per frame
    void Update()
    {
        Moverse();
    }
}
