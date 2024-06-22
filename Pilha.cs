using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilha : MonoBehaviour
{
    public GameObject bateria;
    bool instancia;
    public int quantidade;

    void Start()
    {
        Instantiate(bateria, transform.position, transform.rotation);
    }
    void Update()
    {
        quantidade = GameObject.FindGameObjectsWithTag("pilha").Length - 1;

        if (quantidade == 0 & instancia)
        {
            Instantiate(bateria, transform.position, transform.rotation);
            instancia = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            instancia = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            instancia = true;
        }
    }
}
