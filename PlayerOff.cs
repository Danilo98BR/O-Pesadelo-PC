using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOff : MonoBehaviour
{
    Animator a;
    AudioSource som;

    GameObject cam;
    public GameObject corpo;
    public GameObject visão;
    public GameObject luz;
    public GameObject lanterna;
    public GameObject palhaco;
    public GameObject menina;
    public GameObject spot;

    public Slider volume;

    public Canvas perdeu;
    public Canvas venceu;
    public Canvas placar;

    public Text pontuacao;
    public Text aviso;

    public float sensibilidade;
    public float eixoy;
    public float valor;
    public float conta;
    public float time;
    public float x;
    public float y;

    public int pontos;

    public static bool pausar;
    public static bool mover;
    public bool andar;
    public bool avisa;
    bool pega;

    void Start()
    {
        mover = false;
        pausar = false;
        Time.timeScale = 1;
        Cursor.visible = false;
        perdeu.enabled = false;
        venceu.enabled = false;
        placar.enabled = false;
        pontuacao.text = pontos + " / 10";

        a = GetComponent<Animator>();
        som = GetComponent<AudioSource>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        cam.GetComponent<Collider>().enabled = false;

        if (Gerenciador.online)
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        lanterna.GetComponent<MeshRenderer>().materials[0].color = Color.green;

        if (Menu.pausar == false & mover == false)
        {
            som.volume = volume.value;
            cam.transform.position = new Vector3(visão.transform.position.x, visão.transform.position.y, visão.transform.position.z);

            y += Input.GetAxisRaw("Mouse X");
            x += Input.GetAxisRaw("Mouse Y");

            valor = 45 / sensibilidade;

            if (x <= valor & x >= -valor)
            {
                eixoy = x;
            }
            else if (x > 0)
            {
                x = valor;
            }
            else if (x < 0)
            {
                x = -valor;
            }
            transform.rotation = Quaternion.Euler(0, y * sensibilidade, 0);
            cam.transform.eulerAngles = new Vector3(-eixoy * sensibilidade, y * sensibilidade, 0);

            if (Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.S))
            {
                if (andar == false)
                {
                    andar = true;
                    som.loop = true;
                    som.Play();
                }
                if (Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.D))
                {
                    a.SetBool("Andar", true);
                }
            }
            else
            {
                som.Stop();
                andar = false;
                a.SetBool("Andar", false);
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(0, 0, 1.5f * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-1.5f * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(1.5f * Time.deltaTime, 0, 0);
            }
            //////////----------ATRÁS----------\\\\\\\\\\
            if (Input.GetKey(KeyCode.S))
            {
                a.SetBool("Atrás", true);
                transform.Translate(0, 0, -1.5f * Time.deltaTime);
            }
            else
            {
                a.SetBool("Atrás", false);
            }
            //////////----------PULAR----------\\\\\\\\\\
            if (Input.GetKeyDown(KeyCode.Space))
            {
                time = 0;
                a.SetBool("Pular", true);
            }
            else if (a.GetCurrentAnimatorStateInfo(0).IsName("Pular"))
            {
                time += Time.deltaTime;

                if (time >= 0.3 & time < 0.9)
                {
                    som.mute = true;
                }
                else if (time >= 0.9)
                {
                    som.mute = false;
                }
            }
            else
            {
                som.mute = false;
                a.SetBool("Pular", false);
            }
            //////////----------CORRER----------\\\\\\\\\\
            if (Input.GetKey(KeyCode.W) & Input.GetKey(KeyCode.LeftShift))
            {
                som.pitch = 2;
                a.SetBool("Correr", true);
                transform.Translate(0, 0, 5 * Time.deltaTime);
            }
            else
            {
                som.pitch = 1;
                a.SetBool("Correr", false);
            }
        }
        else
        {
            som.Stop();
            a.SetBool("Andar", false);
            a.SetBool("Atrás", false);
            a.SetBool("Correr", false);
            a.SetBool("Pular", false);

            if (pausar == false & a.GetCurrentAnimatorStateInfo(0).IsName("Morto"))
            {
                pausar = true;
                perdeu.enabled = true;
                spot.SetActive(false);
                cam.GetComponent<Menu>().Pausa();
            }
        }
        if (avisa)
        {
            aviso.enabled = true;
            aviso.text = Menu.aviso;
            conta += Time.deltaTime;

            if (conta >= 2.5)
            {
                conta = 0;
                avisa = false;
                aviso.enabled = false;
            }
        }
        if (pega)
        {
            pega = false;
            luz.GetComponent<LanternaOff>().pilhas += 2;
            luz.GetComponent<LanternaOff>().pilha.text = luz.GetComponent<LanternaOff>().pilhas + " / 5";
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "urso")
        {
            pontos++;
            pontuacao.text = pontos + " / 10";
            cam.GetComponent<Menu>().PegaUrso();

            if (pontos == 10)
            {
                mover = true;
                pausar = true;
                venceu.enabled = true;
                aviso.enabled = false;
                luz.SetActive(false);
                corpo.SetActive(false);
                menina.SetActive(false);
                lanterna.SetActive(false);
                cam.GetComponent<Menu>().Pausa();
                cam.GetComponent<Menu>().SomGanha();
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "pilha")
        {
            if (luz.GetComponent<LanternaOff>().pilhas < 5)
            {
                pega = true;
                cam.GetComponent<Menu>().PegaUrso();
                luz.GetComponent<LanternaOff>().tempopilha = 60;
                Destroy(other.gameObject);
            }
            else
            {
                avisa = true;
            }
        }
        if (other.gameObject.tag == "palhaço")
        {
            mover = true;
            spot.SetActive(true);
            luz.SetActive(false);
            menina.SetActive(false);
            a.SetBool("Morrer", true);
            cam.GetComponent<Menu>().SomPerde();
            cam.transform.LookAt(palhaco.transform.position);
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().detectCollisions = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}
