using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaParametrica1 : Plataforma
{
    //ESTAS SON LAS PLATAFORMAS QUE SE MUEVEN EN FORMA DE CORAZÓN

    [SerializeField] private float anguloInicial;
    [SerializeField] private Transform centro;
    
  
    

   
    protected override void Moverse()
    {
        anguloInicial += velocidadPlataforma * Time.deltaTime;
        float t = anguloInicial* Mathf.Deg2Rad;
        transform.position = new Vector3(centro.position.x + 6 * Mathf.Sin(t)-2*Mathf.Sin(3*t), 
            centro.position.y + (6.5f * Mathf.Cos(t)- 2.5f * Mathf.Cos(2*t)- Mathf.Cos(3* t)-0.5f*Mathf.Cos(4*t)), 0);
    }

    

    // Update is called once per frame
    void Update()
    {
        Moverse();
    }
}
