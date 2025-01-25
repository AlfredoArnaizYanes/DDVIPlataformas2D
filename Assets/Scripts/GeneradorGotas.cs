//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class GeneradorGotas : MonoBehaviour
{
    [SerializeField] private Gota gotaPrefab;
    private ObjectPool<Gota> gotasPool;
    private Vector3 posicionSalida;

    private void Awake()
    {
        gotasPool = new ObjectPool<Gota>(CreateGota, GetGota, ReleaseGota, DestroyGota);
    }

    private Gota CreateGota()
    {
        Gota copiaGota = Instantiate(gotaPrefab, transform.position, Quaternion.identity);
        copiaGota.MyGotasPool = gotasPool;
        return copiaGota;
    }

    private void GetGota(Gota gota)
    {
        gota.transform.position = posicionSalida;
        gota.gameObject.SetActive(true);
        
    }

    private void ReleaseGota(Gota gota)
    {
        gota.gameObject.SetActive(false);
    }

    private void DestroyGota(Gota gota)
    {
        Destroy(gota.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerarGotas());
    }

    IEnumerator GenerarGotas()
    {
        while (true)
        {
            posicionSalida = new Vector3(Random.Range(24f,30f), transform.position.y, 0);
            gotasPool.Get();
            yield return new WaitForSeconds(1f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
