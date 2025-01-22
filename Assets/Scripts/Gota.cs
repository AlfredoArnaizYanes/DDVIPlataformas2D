using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Gota : Enemigo
{
    private float timer;
    private ObjectPool<Gota> myGotasPool;
    
    public ObjectPool<Gota> MyGotasPool { get => myGotasPool; set => myGotasPool = value; }
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * velocidadMovimiento * Time.deltaTime);
        timer += Time.deltaTime;
        if (timer >= 10)
        {
            timer = 0;
            myGotasPool.Release(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("PlayerHitBox"))
        {
            Player myPlayer = elOtro.gameObject.GetComponent<Player>();
            myPlayer.Vida -= danhoCausado;
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject); 
        }
    }
}
