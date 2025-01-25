using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BolaFuego1 : Enemigo
{
    [SerializeField] private float impulsoDisparo;
    
    private Rigidbody2D rb;
    private float timer;

    private ObjectPool<BolaFuego1> myBolasFuegoPool1;

    public ObjectPool<BolaFuego1> MyBolasFuegoPool1 { get => myBolasFuegoPool1; set => myBolasFuegoPool1 = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EstoyMuerto();
        timer += Time.deltaTime;
        if (timer >= 6)
        {
            timer = 0;
            myBolasFuegoPool1.Release(this);
        }
        //Destroy(this.gameObject, 6f);
    }

    public void impulsa(BolaFuego1 bola1)
    {
        rb = bola1.GetComponent<Rigidbody2D>();

        rb.AddForce(transform.right * impulsoDisparo, ForceMode2D.Impulse);
    }



    private void OnTriggerEnter2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("PlayerHitBox"))
        {
            
            Player myPlayer = elOtro.gameObject.GetComponent<Player>();
            myPlayer.sonidoDanho();
            myPlayer.Vida -= danhoCausado;
            Destroy(this.gameObject);
        }
    }
}
