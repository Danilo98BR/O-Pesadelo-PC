using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LanternaOn : NetworkBehaviour
{
    public Light luz;
    public AudioSource liga;
    public Slider bateria;
    public Text pilha;

    public float tempopilha;
    public int pilhas;

    public bool ligou;
    public bool local;
    public bool lobby;

    void Start()
    {
        pilhas = 5;
        luz = GetComponent<Light>();
        liga = GetComponent<AudioSource>();
        luz.enabled = false;

        if(local)
        {
            pilha = GameObject.FindGameObjectWithTag("pilha").GetComponent<Text>();
            bateria = GameObject.FindGameObjectWithTag("bateria").GetComponent<Slider>();
            pilha.text = pilhas + " / 5";
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) & Menu.pausar == false & lobby == false & local)
        {
            liga.pitch = 1.2f;
            liga.Play();

            if (pilhas > 0 & ligou == false)
            {
                ligou = true;
            }
            else if (pilhas > 0 & ligou)
            {
                ligou = false;
            }
        }
        if (ligou & local)
        {
            luz.enabled = true;
            tempopilha += Time.deltaTime;
            bateria.value = 59 - (int)tempopilha;
        }
        else if (ligou == false & local)
        {
            luz.enabled = false;
        }
        if (tempopilha >= 60 & pilhas > 0)
        {
            pilhas--;
            tempopilha = 0;
            bateria.value = 60;
            pilha.text = pilhas + " / 5";
        }
        if (pilhas == 0 & local)
        {
            ligou = false;
            bateria.value = 0;
        }
    }
    public void Ligar()
    {
        luz.enabled = true;
    }
    public void Desligar()
    {
        luz.enabled = false;
    }
}


