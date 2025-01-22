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
    private void OnCollisionEnter2D(Collision2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("PlayerHitBox"))
        {
            Debug.Log("Entre");
            Player myPlayer = elOtro.gameObject.GetComponent<Player>();
            StartCoroutine("meQuemo",myPlayer);
        }
    }

    IEnumerator meQuemo(Player jugador)
    {
        while (true)
        {
            jugador.Vida -= danhoCausado;
            yield return new WaitForSeconds(1);
        }
    }



    private void OnCollisionExit2D(Collision2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("PlayerHitBox"))
        {
        StopCoroutine("meQuemo");
        }
    }
    //FIN DAÑO POR SEGUNDO DE LA LAVA
}