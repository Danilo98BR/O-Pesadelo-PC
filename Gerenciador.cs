using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Gerenciador : NetworkBehaviour
{
    public Image [] huds;
    public GameObject nivel;
    public GameObject luz;
    public Canvas placar;

    public Text pontuacao;
    public Text pilha;
    public Text tempo;
    public Text aviso;

    public static string nome;

    [SyncVar] public int pontos;
    [SyncVar] public int ponto1;
    [SyncVar] public int ponto2;
    [SyncVar] public int ponto3;
    [SyncVar] public int ponto4;
    [SyncVar] public int ponto5;
    [SyncVar] public int ponto6;

    public int pilhas;
    int sub = 59;
    [SyncVar]int min = 9;
    [SyncVar]int seg;

    public float conta;
    float contador;
    float temporiza;

    public static bool host;
    public static bool cliente;
    public static bool online;
    public static bool portugues;
    public static bool troca;
    public static bool palhaco;

    public bool avisa;
    public static bool para;
    public static bool parar;

    public static bool azul;
    public static bool verde;
    public static bool vermelho;
    public static bool amarelo;
    public static bool laranja;
    public static bool branco;
    public static bool preto;
    public static bool ciano;
    public static bool rosa;

    void Start()
    {
        pilhas = 5;
        pilha.text = pilhas + " / 5";
        placar.enabled = false;
        tempo.color = Color.green;
    }
    void Update()
    {
        if (online)
        {
            pontuacao.text = pontos + " / 25";

            if (palhaco)
            {
                luz.SetActive(true);
                nivel.SetActive(false);
                pilha.enabled = false;
                huds[0].enabled = false;
                huds[1].enabled = false;
                huds[2].enabled = false;
            }
            if (online)
            {
                if(parar == false)
                {
                    contador += Time.deltaTime;
                    seg = sub - (int)contador;

                    if (seg < 10)
                    {
                        tempo.text = min + ":0" + seg;
                    }
                    else
                    {
                        tempo.text = min + ":" + seg;
                    }
                    if (contador >= 60)
                    {
                        contador = 0;
                        min -= 1;
                    }
                }              
                if (pontos == 25 | min == 0 & seg == 0)
                {
                    Acabou();
                    parar = true;
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().SomGanha();
                }
            }
            if (parar)
            {
                if (para == false)
                {
                    temporiza += Time.deltaTime;

                    if (temporiza >= 23)
                    {
                        para = true;
                        temporiza = 0;
                        GameObject.FindGameObjectWithTag("lobby").GetComponent<NetworkManager>().onlineScene = "Lobby";
                    }
                }
                else if(host)
                {
                    Application.Quit();
                }
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
    }
    public void Acabou()
    {
        parar = true;
        placar.enabled = true;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().pontos[0].text = "" + ponto1;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().pontos[1].text = "" + ponto2;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().pontos[2].text = "" + ponto3;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().pontos[3].text = "" + ponto4;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().pontos[4].text = "" + ponto5;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().pontos[5].text = "" + ponto6;
    }
}
