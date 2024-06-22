using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class IA : MonoBehaviour
{
    Animator a;
    AudioSource som;
    NavMeshAgent agent;

    public AudioSource voz;
    public AudioSource ataca;
    public AudioClip [] sons;

    public Slider volume;

    public GameObject player;
    public GameObject marreta;
    GameObject[] pontos;

    public int valor;
    public int qtd;

    public float distancia;
    public float distanciaplayer;
    public float tempo;
    public float time;

    bool parado;
    bool tocar;
    bool colide;
    bool viu;

    void Start()
    {
        a = GetComponent<Animator>();
        som = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();

        pontos = GameObject.FindGameObjectsWithTag("ponto");
        qtd = pontos.Length;
        valor = Random.Range(0, qtd);

        som.clip = sons[0];
        som.mute = true;
        som.loop = true;
        som.Play();

        voz.clip = sons[1];
        voz.mute = true;
        voz.loop = true;
        voz.Play();

        if (Gerenciador.online)
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        som.volume = volume.value;
        voz.volume = volume.value;
        ataca.volume = volume.value;

        distanciaplayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanciaplayer <= 13.3f & PlayerOff.mover == false)
        {
            if (Menu.pausar | PlayerOff.pausar)
            {
                som.Pause();
                voz.Pause();
                ataca.Pause();
            }
            else
            {
                som.UnPause();
                voz.UnPause();
                ataca.Pause();

                voz.mute = false;

                if (parado == false)
                {
                    som.mute = false;
                }
                else
                {
                    som.mute = true;
                }
            }
            if(distanciaplayer < 8)
            {
                som.volume = 0.4f;
            }
            else if(distanciaplayer <= 7)
            {
                som.volume = 0.7f;
            }
            else if (distanciaplayer <= 4)
            {
                som.volume = 1;
            }
        }
        else
        {
            voz.mute = true;
            som.volume = 0.2f;

            if (distanciaplayer > 12 | parado)
            {
                som.mute = true;
            }
        }
        if (distanciaplayer <= 9.105f & viu == false)
        {
            viu = true;          
        }
        else if(viu)
        {
            voz.pitch = 1.1f;
            som.pitch = 2.4f;
            agent.speed = 5.3f;
            a.SetBool("Parado", false);
            a.SetBool("Correr", true);
            GetComponent<Collider>().enabled = true;

            if (distanciaplayer > 9.5f & tempo >= 2)
            {
                tempo = 0;
                viu = false;
            }
            else if (tempo <= 2)
            {
                tempo += Time.deltaTime;
            }
            if (colide)
            {
                parado = true;
                voz.mute = true;
                agent.speed = 0;
                a.SetBool("Parado", false);
                a.SetBool("Correr", false);
                a.SetBool("Atacar", true);
                agent.SetDestination(transform.position);
                transform.LookAt(player.transform.position);
                marreta.GetComponent<Collider>().enabled = true;

                if (PlayerOff.pausar == false)
                {
                    time += Time.deltaTime;

                    if (tocar == false & time >= 1.2f)
                    {
                        tocar = true;

                        if(!ataca.isPlaying)
                        {
                            ataca.Play();
                        }
                    }
                    else if (time >= 4.05f)
                    {
                        time = 0;
                        tocar = false;
                    }
                }
            }
            else
            {
                time = 0;
                tocar = false;
                a.SetBool("Atacar", false);

                if (distancia > 4)
                {
                    voz.mute = false;
                }
                if (a.GetCurrentAnimatorStateInfo(0).IsName("Correr"))
                {
                    parado = false;
                    agent.SetDestination(player.transform.position);
                }
            }
        }
        else
        {
            voz.pitch = 0.9f;
            som.pitch = 1.1f;
            agent.speed = 1.84f;
            a.SetBool("Atacar", false);
            a.SetBool("Correr", false);
            GetComponent<Collider>().enabled = false;
            marreta.GetComponent<Collider>().enabled = false;
            agent.SetDestination(pontos[valor].transform.position);
            distancia = Vector3.Distance(transform.position, pontos[valor].transform.position);

            if (distancia <= 0.5 & !a.GetCurrentAnimatorStateInfo(0).IsName("Parado"))
            {
                parado = true;
                a.SetBool("Parado", true);

                if (a.GetCurrentAnimatorStateInfo(0).IsName("Estado"))
                {
                    parado = false;
                    valor = Random.Range(0, qtd);
                    a.SetBool("Parado", false);
                }
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            colide = true;
        }
    }
}
