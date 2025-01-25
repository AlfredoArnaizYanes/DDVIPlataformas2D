using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaParametrica2 : Plataforma
{
    [SerializeField] private float anguloInicial;
    [SerializeField] private Transform centro;
    [SerializeField] private float radio;
    //[SerializeField] private float radioP;  
    //[SerializeField] private float parametro;

    private Rigidbody2D rb1;

    //[SerializeField] private Vector2 posInicial;
    protected override void Moverse()
    {
        anguloInicial += velocidadPlataforma * Time.deltaTime;
        float t = anguloInicial * Mathf.Deg2Rad;
        //float resta = radioG - radioP;
        //float cociente = radioG / radioP;
        transform.position = new Vector3(centro.position.x + radio*Mathf.Sin(2*t),
            centro.position.y + radio*Mathf.Sin(3*t), 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb1 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Moverse();
    }
}
