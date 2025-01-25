using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : Enemigo
{
    // Start is called before the first frame update

    private float timer;
    private bool ardiendo = false;
    private Player myPlayer;
    

    void Start()
    {
        myPlayer = FindAnyObjectByType<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (myPlayer.PisePlataformaNivel2 == true)
        {
            Ascenso();
        }

    }

    //DAÑO POR SEGUNDO DE LA LAVA
   

    private void OnTriggerEnter2D(Collider2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("PlayerHitBox") && !ardiendo)
        {
           
            Player myPlayer = elOtro.gameObject.GetComponent<Player>();
            ardiendo = true;
            StartCoroutine("meQuemo", myPlayer);

        }
    }

    IEnumerator meQuemo(Player jugador)
    {
        
        while (true)
        {
            //componenteAudio.PlayOneShot(meGolpean);
            jugador.sonidoDanho();
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

    private void Ascenso()
    {
        transform.Translate(Vector3.up * velocidadMovimiento * Time.deltaTime);
    }
}