using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanternaOff : MonoBehaviour
{
    Light luz;
    AudioSource liga;

    public GameObject lanterna;
    public Slider bateria;
    public Slider volume;
    public Text pilha;

    public float tempopilha;
    public int pilhas;

    public bool ligou;

    void Start()
    {
        pilhas = 5;
        pilha.text = pilhas + " / 5";
        luz = GetComponent<Light>();
        liga = GetComponent<AudioSource>();
        luz.enabled = false;
    }
    void Update()
    {
        liga.volume = volume.value;
        transform.eulerAngles = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().rotation.eulerAngles.x, GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().rotation.eulerAngles.y, 0);

        if (Gerenciador.online == false & PlayerOff.mover == false)
        {
            transform.position = lanterna.transform.position;
        }
        else if(Gerenciador.online)
        {
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.F) & Menu.pausar == false & PlayerOff.mover == false)
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
        if (ligou)
        {
            luz.enabled = true;
            tempopilha += Time.deltaTime;
            bateria.value = 59 - (int)tempopilha;
        }
        else if (ligou == false)
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
        if (pilhas == 0)
        {
            ligou = false;
            bateria.value = 0;
        }
    }
}


