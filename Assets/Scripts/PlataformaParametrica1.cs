using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaParametrica1 : Plataforma
{
    [SerializeField] private float anguloInicial;
    [SerializeField] private Transform centro;
    [SerializeField] private float radio;
    [SerializeField] private float parametro;
  
    private Rigidbody2D rb1;

    //[SerializeField] private Vector2 posInicial;
    protected override void Moverse()
    {
        anguloInicial += velocidadPlataforma * Time.deltaTime;
        float t = anguloInicial* Mathf.Deg2Rad;
        transform.position = new Vector3(centro.position.x + 6 * Mathf.Sin(t)-2*Mathf.Sin(3*t), 
            centro.position.y + (6.5f * Mathf.Cos(t)- 2.5f * Mathf.Cos(2*t)- Mathf.Cos(3* t)-0.5f*Mathf.Cos(4*t)), 0);
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
