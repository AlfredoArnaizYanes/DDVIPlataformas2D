using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Plataforma : MonoBehaviour
{
    [SerializeField] protected float velocidadPlataforma;
   
    

    protected abstract void Moverse();

   
}
