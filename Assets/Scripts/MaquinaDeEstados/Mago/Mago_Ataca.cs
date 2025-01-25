using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Mago_Ataca : Estado<Mago_Controller>
{
    [SerializeField] private BolaFuego1 bolaFuegoPrefab1;
    [SerializeField] private BolaFuego2 bolaFuegoPrefab2;
    [SerializeField] private Transform puntoSpawn;
    [SerializeField] private float tiempoAtaques;
    [SerializeField] private float tiempoTeletransporte;
    [SerializeField] private float probBolaTipo1;
    [SerializeField] private Transform puntosTeletransporte;
    [SerializeField] private int numeroPuntosTeletransporte;
    private Animator anim;
    private ObjectPool<BolaFuego1> bolasFuegoPool1;
    private ObjectPool<BolaFuego2> bolasFuegoPool2;
    private Transform objetivo;
    private List<Vector3> listadoPuntosT = new List<Vector3>();
    private int indicePosicion;
    private int indiceActual=0;

    private void Awake()
    {
        bolasFuegoPool1 = new ObjectPool<BolaFuego1>(CreateBolaFuego1, GetBolaFuego1, ReleaseBolaFuego1, DestroyBolaFuego1);
        bolasFuegoPool2 = new ObjectPool<BolaFuego2>(CreateBolaFuego2, GetBolaFuego2, ReleaseBolaFuego2, DestroyBolaFuego2);
    }

    private BolaFuego1 CreateBolaFuego1()
    {

        BolaFuego1 copiaBolaFuego = Instantiate(bolaFuegoPrefab1, transform.position, transform.rotation);
        copiaBolaFuego.MyBolasFuegoPool1 = bolasFuegoPool1;
        return copiaBolaFuego;
    }

    private BolaFuego2 CreateBolaFuego2()
    {

        BolaFuego2 copiaBolaFuego = Instantiate(bolaFuegoPrefab2, transform.position, transform.rotation);
        copiaBolaFuego.MyBolasFuegoPool2 = bolasFuegoPool2;
        return copiaBolaFuego;
    }

    private void GetBolaFuego1(BolaFuego1 bolaFuego1)
    {
        bolaFuego1.transform.position = puntoSpawn.position;
        bolaFuego1.gameObject.SetActive(true);
        bolaFuego1.transform.rotation = puntoSpawn.rotation;
        bolaFuego1.impulsa(bolaFuego1);
        

    }

    private void GetBolaFuego2(BolaFuego2 bolaFuego2)
    {
        bolaFuego2.transform.position = puntoSpawn.position;
        bolaFuego2.gameObject.SetActive(true);
        bolaFuego2.transform.rotation = puntoSpawn.rotation;
    }

    private void ReleaseBolaFuego1(BolaFuego1 bolaFuego1)
    {
        bolaFuego1.gameObject.SetActive(false);

    }

    private void ReleaseBolaFuego2(BolaFuego2 bolaFuego2)
    {
        bolaFuego2.gameObject.SetActive(false);

    }
    private void DestroyBolaFuego1(BolaFuego1 bolaFuego1)
    {
        Destroy(bolaFuego1.gameObject);
    }

    private void DestroyBolaFuego2(BolaFuego2 bolaFuego2)
    {
        Destroy(bolaFuego2.gameObject);
    }
    public override void OnEnterState(Mago_Controller Controller)
    {
        Debug.Log("Ataque_Enter");
        base.OnEnterState(Controller);
        foreach (Transform t in puntosTeletransporte)
        {
            listadoPuntosT.Add(t.position);
        }
        transform.position = listadoPuntosT[indiceActual];
        anim = GetComponent<Animator>();
        objetivo = FindObjectOfType<Player>().transform;

        StartCoroutine(RutinaAtaque());
        StartCoroutine(RutinaTeletransporte());
       
        

    }
    IEnumerator RutinaAtaque()
    {
        while (true)
        {
            anim.SetTrigger("atacar");
            yield return new WaitForSeconds(tiempoAtaques);
        }
    }

    IEnumerator RutinaTeletransporte()
    {
        
        while (true)
        {
            yield return new WaitForSeconds(tiempoTeletransporte);
            indicePosicion = Random.Range(0, 3);
            while (indicePosicion == indiceActual)
            {
                indicePosicion = Random.Range(0, numeroPuntosTeletransporte);
            }
            indiceActual = indicePosicion;
            transform.position = listadoPuntosT[indiceActual];            
        }
    }

    private void LanzarBola()
    {
        if (Random.Range(0f, 1f) <= probBolaTipo1)
        {
            bolasFuegoPool1.Get();
        }
        else
        {
            bolasFuegoPool2.Get();
        }
    }

    public override void OnUpdateState()
    {
        Debug.Log("Ataque_Update");
        EnfocarObjetivo();

    }

    private void EnfocarObjetivo()
    {
        if (objetivo.position.x > transform.position.x)
        {
            transform.localEulerAngles = Vector3.zero;
        }
        else
        {
            transform.localEulerAngles = new Vector3(0, 180,0);
        }
    }

    public override void OnExitState()
    {
        Debug.Log("Ataque_Exit");

    }
}