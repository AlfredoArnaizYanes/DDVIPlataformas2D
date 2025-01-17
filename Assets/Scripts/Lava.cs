using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : Enemigo
{
    // Start is called before the first frame update

    private float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //DAÑO POR SEGUNDO DE LA LAVA
    //La lava causa un daño determinado al caer y el mismo daño por segundo si permaneces en ella
    //Al salir se reinicia el contador de tiempo a 0
    private void OnCollisionEnter2D(Collision2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("PlayerHitBox"))
        {

            SistemaVidas sistemaVidasPlayer = elOtro.gameObject.GetComponent<SistemaVidas>();
            sistemaVidasPlayer.RecibirDanho(danhoCausado);
            
        }
    }

    private void OnCollisionStay2D(Collision2D elOtro)
    {
        
        if (elOtro.gameObject.CompareTag("PlayerHitBox"))
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                SistemaVidas sistemaVidasPlayer = elOtro.gameObject.GetComponent<SistemaVidas>();
                sistemaVidasPlayer.RecibirDanho(danhoCausado);
                Debug.Log("He detectado al player");
                timer = 0;
            }
            
        }
    }

    private void OnCollisionExit2D(Collision2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("PlayerHitBox"))
        {
                timer = 0;
        }
    }
    //FIN DAÑO POR SEGUNDO DE LA LAVA
}
