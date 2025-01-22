using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    [SerializeField] protected float velocidadMovimiento;
    [SerializeField] protected float danhoCausado;
    [SerializeField] protected float vida;

    public float Vida { get => vida; set => vida = value; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    

    protected void EstoyMuerto()
    {
        if (vida <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    

}