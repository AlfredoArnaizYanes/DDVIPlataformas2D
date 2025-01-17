using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaGiratoria : Plataforma
{
    [SerializeField] private float anguloInicial;
    [SerializeField] private Transform centro;
    [SerializeField] private float radio;
    [SerializeField] private float esperaCaida;
    [SerializeField] private float esperaDestruccion;
    private Rigidbody2D rb;

    //[SerializeField] private Vector2 posInicial;
    protected override void Moverse()
    {
        anguloInicial += velocidadPlataforma * Time.deltaTime;
        transform.position = new Vector3(centro.position.x + radio * Mathf.Cos(anguloInicial*Mathf.Deg2Rad), centro.position.y + radio * Mathf.Sin(anguloInicial * Mathf.Deg2Rad), 0);
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

    

    private IEnumerator caida()
    {
        yield return new WaitForSeconds(esperaCaida);
        rb.isKinematic = false;
        Destroy(this.gameObject, esperaDestruccion);
    }
}
