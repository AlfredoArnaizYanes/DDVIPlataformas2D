using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BolaFuego : Enemigo
{
    [SerializeField] private float impulsoDisparo;
    private Rigidbody2D rb;

    private ObjectPool<BolaFuego> myBolasFuegoPool;

    public ObjectPool<BolaFuego> MyBolasFuegoPool { get => myBolasFuegoPool; set => myBolasFuegoPool = value; }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * impulsoDisparo, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 6f);
        EstoyMuerto();
    }

    private void OnTriggerEnter2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("PlayerHitBox"))
        {
            Player myPlayer = elOtro.gameObject.GetComponent<Player>();
            myPlayer.Vida -= danhoCausado;
            Destroy(this.gameObject);
        }
    }


}
