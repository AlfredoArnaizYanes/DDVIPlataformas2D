using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Plataforma : MonoBehaviour
{
    [SerializeField] protected float velocidadPlataforma;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    protected abstract void Moverse();
}
