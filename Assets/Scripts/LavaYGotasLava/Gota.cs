using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Gota : Enemigo
{

    //LAS GOTAS DE LAVA CAEN HACIA ABAJO Y SI CAEN SOBRE EL PLAYER LO DAÑAN, SI TROPIEZAN CON OTRA COSA SE DESTRUYEN
    
    private float timer;
    private ObjectPool<Gota> myGotasPool;
    
    public ObjectPool<Gota> MyGotasPool { get => myGotasPool; set => myGotasPool = value; }
    
    
    
    // Start is called before the first frame update
    //void Start()
    //{
              
    //}

   

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
            myPlayer.sonidoDanho();
            myPlayer.Vida -= danhoCausado;
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject); 
        }
    }
}
