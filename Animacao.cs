using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacao : MonoBehaviour
{
    Animator a;

    void Start()
    {
        a = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.D))
        {
            a.SetBool("Andar", true);
        }
        else
        {
            a.SetBool("Andar", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            a.SetBool("Atrás", true);
        }
        else
        {
            a.SetBool("Atrás", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            a.SetBool("Pular", true);
        }
        else
        {
            a.SetBool("Pular", false);
        }
        if (Input.GetKey(KeyCode.W) & Input.GetKey(KeyCode.LeftShift))
        {
            a.SetBool("Correr", true);
        }
        else
        {
            a.SetBool("Correr", false);
        }
        if(a.GetCurrentAnimatorStateInfo(0).IsName("Morto"))
        {
            a.SetBool("Morrer", false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "palhaço")
        {
            a.SetBool("Morrer", true);
        }
    }
}
