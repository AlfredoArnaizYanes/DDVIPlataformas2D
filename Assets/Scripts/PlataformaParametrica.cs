using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaParametrica : Plataforma
{
    [SerializeField] private float anguloInicial;
    [SerializeField] private Transform centro;
    [SerializeField] private float radio;
    [SerializeField] private float parametro;
  
    private Rigidbody2D rb;

    //[SerializeField] private Vector2 posInicial;
    protected override void Moverse()
    {
        anguloInicial += velocidadPlataforma * Time.deltaTime;
        transform.position = new Vector3(centro.position.x + radio * Mathf.Cos(anguloInicial * Mathf.Deg2Rad)-Mathf.Cos(5*anguloInicial*Mathf.Deg2Rad), centro.position.y + radio * Mathf.Sin(anguloInicial * Mathf.Deg2Rad)-Mathf.Sin(parametro*anguloInicial*Mathf.Deg2Rad), 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Moverse();
    }
}
