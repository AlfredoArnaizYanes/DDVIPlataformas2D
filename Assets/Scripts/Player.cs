using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Personaje
{
    [SerializeField] private float fuerzaSalto;
    [SerializeField] private float velocidadMaxCaida;
    [SerializeField] private float danhoPorCaida;
    private Rigidbody2D rb;
    private float inputH;
    private Animator anim;
    private SistemaVidas sistemaVidasPlayer;
    private float velocidadAntesSuelo;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sistemaVidasPlayer = GetComponent<SistemaVidas>();
    }

    // Update is called once per frame
    void Update()
    {
        Salto();

        Movimiento();

        LanzarAtaque();

        DanhoCaida();
    }

    private void DanhoCaida()
    {
        if (!EstoyEnSuelo())
        {
            velocidadAntesSuelo = rb.velocity.y;
        }
        else
        {
            if(velocidadAntesSuelo < velocidadMaxCaida)
            {
                sistemaVidasPlayer.RecibirDanho(danhoPorCaida);
            }
            velocidadAntesSuelo = 0;
        }
    }

    private bool EstoyEnSuelo()
    {
        return true;
        //Debug.DrawRay(piesPlayer.position, Vector3.down, Color.blue, 0.4f);
        //return Physics2D.Raycast(piesPlayer.position, Vector3.down, distanciaDeteccionSuelo, loQueEsSaltable);
    }


    //Me pego a las plataformas cuando estoy sobre ellas
    private void OnCollisionEnter2D(Collision2D elOtro)
    {
        if (elOtro.gameObject.CompareTag("Plataforma"))
        {
            transform.parent = elOtro.gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D elOtro)
    {
        transform.SetParent(null);
    }
    //FIN de Me pego a las plataformas cuando estoy sobre ellas

    private void LanzarAtaque()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("attack");
        }
    }
    private void Movimiento()
    {
        inputH = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector3(inputH * velocidadMovimiento, rb.velocity.y);
        if (inputH != 0)
        {
            anim.SetBool("running", true);
            if (inputH > 0)
            {
                transform.eulerAngles = Vector3.zero;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
        else
        {
            anim.SetBool("running", false);
        }
    }
    private void Salto()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            anim.SetTrigger("jumping");
        }
    }

}
