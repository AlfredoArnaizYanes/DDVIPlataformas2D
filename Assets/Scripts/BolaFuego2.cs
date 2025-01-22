using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaFuego2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float velocidadBF;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.right * velocidadBF * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("PlayerHitBox"))
        {
            elOtro.GetComponent<Player>().Vida -= 10;
        }
        Destroy(this.gameObject);
    }
}
