using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : Enemigo
{
    // Start is called before the first frame update

    private float timer;
    private bool ardiendo = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ascenso();
    }

    //DAÑO POR SEGUNDO DE LA LAVA
   

    private void OnTriggerEnter2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("PlayerHitBox") && !ardiendo)
        {
            Debug.Log("Entre");
            Player myPlayer = elOtro.gameObject.GetComponent<Player>();
            ardiendo = true;
            StartCoroutine("meQuemo", myPlayer);

        }
    }

    IEnumerator meQuemo(Player jugador)
    {
        Debug.Log("Mellamaron");
        while (true)
        {
            jugador.Vida -= danhoCausado;
            yield return new WaitForSeconds(1);
        }
    }


    private void OnTriggerExit2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("PlayerHitBox"))
        {
            StopCoroutine("meQuemo");
            ardiendo=false;
        }
    }

    //FIN DAÑO POR SEGUNDO DE LA LAVA

    private void ascenso()
    {
        transform.Translate(Vector3.up * velocidadMovimiento * Time.deltaTime);
    }
}