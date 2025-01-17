using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaVidas : MonoBehaviour
{
    [SerializeField] private float vida;

    public void RecibirDanho(float danhoRecibido)
    {
        vida -= danhoRecibido;
        if (vida <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
