using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaParametrica2 : Plataforma
{
    //ESTAS SON LAS PLATAFORMAS QIE REMATAN EL NIVEL 2 DEL JUEGO

    [SerializeField] private float anguloInicial;
    [SerializeField] private Transform centro;
    [SerializeField] private float radio;
    

    protected override void Moverse()
    {
        anguloInicial += velocidadPlataforma * Time.deltaTime;
        float t = anguloInicial * Mathf.Deg2Rad;
        //float resta = radioG - radioP;
        //float cociente = radioG / radioP;
        transform.position = new Vector3(centro.position.x + radio*Mathf.Sin(2*t),
            centro.position.y + radio*Mathf.Sin(3*t), 0);
    }

    // Update is called once per frame
    void Update()
    {
        Moverse();
    }
}
