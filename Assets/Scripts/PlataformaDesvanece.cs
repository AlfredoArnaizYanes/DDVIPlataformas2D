using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaDesvanece : MonoBehaviour
{
    [SerializeField] private float tiempoCaida;
    [SerializeField] private float tiempoDesaparecer;
    [SerializeField] private float tiempoReaparecer;
    private Rigidbody2D rb;
    private Vector3 antiguaPosicion;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        antiguaPosicion = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D elOtro)
    {
        
        if (elOtro.gameObject.CompareTag("PlayerHitBox"))
        {
            StartCoroutine("Caida");
        }
    }

    private IEnumerator Caida()
    {
        yield return new WaitForSeconds(tiempoCaida);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.isKinematic = false;
        yield return new WaitForSeconds(tiempoDesaparecer);
        this.gameObject.SetActive(false);
        Invoke("Reaparecer", tiempoReaparecer);
    }

    private void Reaparecer() 
    { 
        this.gameObject.SetActive(true);
        transform.position = antiguaPosicion;
        transform.rotation = Quaternion.identity;   
        rb.isKinematic = true;
    }
}
