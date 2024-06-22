using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Ursoon : NetworkBehaviour
{
    [SyncVar]public int valor;

    void Start()
    {
        if(Gerenciador.host)
        {
            valor = Random.Range(0, 9);
        }
        if (valor == 1)
        {
            GetComponent<MeshRenderer>().materials[0].color = Color.white;
        }
        else if (valor == 2)
        {
            GetComponent<MeshRenderer>().materials[0].color = Color.blue;
        }
        else if (valor == 3)
        {
            GetComponent<MeshRenderer>().materials[0].color = Color.green;
        }
        else if (valor == 4)
        {
            GetComponent<MeshRenderer>().materials[0].color = Color.red;
        }
        else if (valor == 5)
        {
            GetComponent<MeshRenderer>().materials[0].color = Color.yellow;
        }
        else if (valor == 6)
        {
            GetComponent<MeshRenderer>().materials[0].color = Color.magenta;
        }
        else if (valor == 7)
        {
            GetComponent<MeshRenderer>().materials[0].color = Color.cyan;
        }
        else if (valor == 8)
        {
            GetComponent<MeshRenderer>().materials[0].color = Color.black;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
