using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BolaFuego2 : Enemigo
{
    // Start is called before the first frame update
    [SerializeField] private float velocidadBF;
    
    private float timer;

    private ObjectPool<BolaFuego2> myBolasFuegoPool2;

    public ObjectPool<BolaFuego2> MyBolasFuegoPool2 { get => myBolasFuegoPool2; set => myBolasFuegoPool2 = value; }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EstoyMuerto();
        transform.Translate(new Vector3(1, 0, 0) * velocidadBF * Time.deltaTime);
        timer += Time.deltaTime;
        if (timer >= 6)
        {
            timer = 0;
            myBolasFuegoPool2.Release(this);
        }
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
