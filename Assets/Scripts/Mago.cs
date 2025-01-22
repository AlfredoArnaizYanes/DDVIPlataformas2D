using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Mago : Enemigo
{
    [SerializeField] private BolaFuego bolaFuegoPrefab;
    [SerializeField] private Transform puntoSpawn;
    [SerializeField] private float tiempoAtaques;
    private Animator anim;
    private ObjectPool<BolaFuego> bolasFuegoPool;


    private void Awake()
    {
        bolasFuegoPool = new ObjectPool<BolaFuego>(CreateBolaFuego, GetBolaFuego, ReleaseBolaFuego, DestroyBolaFuego);
    }

    private BolaFuego CreateBolaFuego()
    {
        BolaFuego copiaBolaFuego = Instantiate(bolaFuegoPrefab, transform.position, transform.rotation);
        copiaBolaFuego.MyBolasFuegoPool = bolasFuegoPool;
        return copiaBolaFuego;
    }

    private void GetBolaFuego(BolaFuego bolaFuego)
    {
        bolaFuego.transform.position = puntoSpawn.position;
        bolaFuego.gameObject.SetActive(true);
    }

    private void ReleaseBolaFuego(BolaFuego bolaFuego)
    {
        bolaFuego.gameObject.SetActive(false);
    }

    private void DestroyBolaFuego(BolaFuego bolaFuego)
    {
        Destroy(bolaFuego.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(RutinaAtaque());
    }

    // Update is called once per frame
    void Update()
    {
        EstoyMuerto();
    }

    IEnumerator RutinaAtaque()
    {
        while (true)
        {
            anim.SetTrigger("atacar");
            yield return new WaitForSeconds(tiempoAtaques);
        }
    }

    private void LanzarBola()
    {
        bolasFuegoPool.Get();
        //Instantiate(bolaFuegoPrefab, puntoSpawn.position, transform.rotation);
        Debug.Log("Lanzo");
    }
}
