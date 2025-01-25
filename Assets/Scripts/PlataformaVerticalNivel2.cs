using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaVerticalNivel2 : Plataforma
{
    [SerializeField] private float posInicial;
    [SerializeField] private float posFinal;
    private Player myPlayer;
    

    
    // Start is called before the first frame update
    void Start()
    {
        myPlayer = FindAnyObjectByType<Player>();
        if (myPlayer == null)
        {
            Debug.Log("No Encuentro al player");
        }
        else
        {
            Debug.Log("SiEncuentroPlayer");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (myPlayer.PisePlataformaNivel2 == true)
        {
            Debug.Log("LaPlataformaSeMueve");
            Moverse();
            DelimitadorMovimiento();
        }
          
    }

    protected override void Moverse()
    {
        transform.Translate(Vector2.up * velocidadPlataforma * Time.deltaTime);
        if (transform.position.y < posInicial || transform.position.y > posFinal)
        {
            velocidadPlataforma *= -1;
        }
    }

    private void DelimitadorMovimiento()
    {
        float restrinigidaY = Mathf.Clamp(transform.position.y, posInicial, posFinal);
        transform.position = new Vector3(transform.position.x, restrinigidaY, 0);
    }
}
