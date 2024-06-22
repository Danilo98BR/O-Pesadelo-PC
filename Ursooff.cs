using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ursooff : MonoBehaviour
{
    void Start()
    {
        if (Gerenciador.online)
        {
            Destroy(gameObject);
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
