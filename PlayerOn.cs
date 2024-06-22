using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerOn : NetworkBehaviour
{
    Animator a;
    AudioSource som;

    public Material transparente;
    public Material escuro;
    Material[] materiais;

    GameObject[] respawns;
    GameObject cam;

    public AudioSource ataca;
    public AudioClip clip;

    public Collider col1;
    public Collider col2;

    public GameObject player2;
    public GameObject posid;
    public GameObject cabeca;
    public GameObject invisivel;
    public GameObject corpo;
    public GameObject visão;
    public GameObject rotacao;
    public GameObject lanterna;
    public GameObject luz;

    public float sensibilidade;
    public float eixoy;
    public float valor;
    public float valor2;
    public float time;
    public float x;
    public float y;
    public float f;
    public float g;

    public int pontos;
    public int renasce;
    public int id;

    public static bool pausar;
    public bool mudacor;
    public bool escolheu;
    public bool andar;
    public bool lobby;
    public float tempo;
    public bool atacar;
    public bool trava;
    public bool toca;
    public bool menu;
    public bool seta;
    public bool ligou;
    public bool anda;
    public bool corre;
    public bool txtpreto;
    bool pega;
    bool sa;
    bool sd;
    bool ww;
    bool aa;
    bool dd;
    bool ss;

    [SyncVar] public bool palhaco;
    [SyncVar] public bool outro;
    [SyncVar] public bool sanda;
    [SyncVar] public bool scorre;
    [SyncVar] public bool satacou;

    [SyncVar] public bool azul;
    [SyncVar] public bool verde;
    [SyncVar] public bool vermelho;
    [SyncVar] public bool amarelo;
    [SyncVar] public bool laranja;
    [SyncVar] public bool branco;
    [SyncVar] public bool preto;
    [SyncVar] public bool ciano;
    [SyncVar] public bool rosa;

    void Start()
    {
        escolheu = false;
        Time.timeScale = 1;
        MudaCor(Color.white);
        valor = 45 / sensibilidade;
        valor2 = 22 / sensibilidade;

        a = GetComponent<Animator>();
        som = GetComponent<AudioSource>();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        rotacao = GameObject.FindGameObjectWithTag("gira camera");
        respawns = GameObject.FindGameObjectsWithTag("Respawn");

        player2.GetComponent<PlayerOn>().corpo.GetComponent<SkinnedMeshRenderer>().materials[0].color = Color.white;
        player2.GetComponent<PlayerOn>().corpo.GetComponent<SkinnedMeshRenderer>().materials[1].color = Color.white;
        player2.GetComponent<PlayerOn>().corpo.GetComponent<SkinnedMeshRenderer>().materials[2].color = Color.white;
        player2.GetComponent<PlayerOn>().corpo.GetComponent<SkinnedMeshRenderer>().materials[4].color = Color.white;
        player2.GetComponent<PlayerOn>().corpo.GetComponent<SkinnedMeshRenderer>().materials[5].color = Color.white;

        if (cam.GetComponent<Menu>().lobby == false & menu & cam.GetComponent<Menu>().cena)
        {
            Cursor.visible = false;
            id = cam.GetComponent<Menu>().soma;
            cam.GetComponent<Menu>().Nomes(Gerenciador.nome);
            cam.GetComponent<Menu>().nomes[id].color = Color.white;
        }
        if (cam.GetComponent<Menu>().lobby)
        {
            lobby = true;

            if (lobby & palhaco == false)
            {
                transform.Rotate(0, 145, 0);
                luz.GetComponent<LanternaOn>().lobby = true;
                id = cam.GetComponent<Menu>().soma;
                cam.GetComponent<Menu>().Nomes(Gerenciador.nome);
                cam.GetComponent<Menu>().nomes[id].color = Color.white;
            }
        }
        if (isLocalPlayer & menu)
        {
            if (Gerenciador.palhaco)
            {
                outro = true;
                palhaco = true;
            }
            if (lobby == false)
            {
                cabeca.SetActive(false);

                if (palhaco == false)
                {
                    luz.GetComponent<LanternaOn>().local = true;
                    cam.GetComponent<Collider>().enabled = false;
                }
            }
        }
        if (!isLocalPlayer & lobby & menu)
        {
            col1.enabled = false;

            if (palhaco == false)
            {
                corpo.SetActive(false);
                cabeca.SetActive(false);
                lanterna.SetActive(false);
            }
        }
        if (isLocalPlayer & cam.GetComponent<Menu>().cena)
        {
            if (Gerenciador.palhaco == false)
            {
                corpo.SetActive(false);
                lanterna.SetActive(false);
            }
            else
            {
                GameObject.FindGameObjectWithTag("menina").SetActive(false);
            }
        }
    }
    void Update()
    {
        if (menu)
        {
            if (branco)
            {
                txtpreto = false;
                MudaCor(Color.white);
            }
            else if (azul)
            {
                txtpreto = false;
                MudaCor(Color.blue);
            }
            else if (verde)
            {
                txtpreto = false;
                MudaCor(Color.green);
            }
            else if (vermelho)
            {
                txtpreto = false;
                MudaCor(Color.red);
            }
            else if (amarelo)
            {
                txtpreto = false;
                MudaCor(Color.yellow);
            }
            else if (laranja)
            {
                txtpreto = false;
                Color cor = new Color(1, 0.3f, 0);
                MudaCor(cor);
            }
            else if (ciano)
            {
                txtpreto = false;
                MudaCor(Color.cyan);
            }
            else if (preto)
            {
                txtpreto = true;
                Color cor = new Color(0.1f, 0.1f, 0.1f);
                MudaCor(cor);
            }
            else if (rosa)
            {
                txtpreto = false;
                MudaCor(Color.magenta);
            }
        }
        if (!isLocalPlayer & menu & lobby == false)
        {
            if (sanda)
            {
                anda = true;
                player2.GetComponent<PlayerOn>().a.SetBool("Andar", true);
            }
            else if (anda)
            {
                anda = false;
                player2.GetComponent<PlayerOn>().a.SetBool("Andar", false);
            }
            if (scorre)
            {
                som.pitch = 2;
                corre = true;

                if (palhaco)
                {
                    player2.GetComponent<PlayerOn>().a.SetBool("Correr", true);
                }
            }
            else if (corre)
            {
                som.pitch = 1;
                corre = false;

                if (palhaco)
                {
                    player2.GetComponent<PlayerOn>().a.SetBool("Correr", false);
                }
            }
            if (satacou)
            {
                atacar = true;
                tempo += Time.deltaTime;
                player2.GetComponent<PlayerOn>().a.SetBool("Atacar", true);

                if (tempo >= 0.2 & toca == false)
                {
                    toca = true;
                    ataca.Play();
                }
                else if (tempo >= 1)
                {
                    tempo = 0;
                    toca = false;
                }
            }
            else if (atacar)
            {
                atacar = false;
                player2.GetComponent<PlayerOn>().a.SetBool("Atacar", false);
            }
            if (anda & andar == false & atacar == false | corre & andar == false & atacar == false)
            {
                andar = true;
                som.loop = true;
                som.Play();
            }
            else
            {
                som.Stop();
            }
        }
        if (Gerenciador.palhaco & isLocalPlayer & lobby & menu)
        {
            corpo.SetActive(false);
            cabeca.SetActive(false);
            invisivel.SetActive(false);
            lanterna.SetActive(false);
            player2.SetActive(true);
            player2.transform.rotation = Quaternion.Euler(0, 120, 0);
            player2.transform.localScale = new Vector3(0.11f, 0.11f, 0.11f);
        }
        if (Gerenciador.palhaco == false & isLocalPlayer & menu & lobby)
        {
            corpo.SetActive(true);
            cabeca.SetActive(true);
            invisivel.SetActive(true);
            lanterna.SetActive(true);
            player2.SetActive(false);
        }
        else if (palhaco & outro & menu & lobby == false)
        {
            som.clip = clip;
            corpo.SetActive(false);
            cabeca.SetActive(false);
            invisivel.SetActive(false);
            lanterna.SetActive(false);
            luz.SetActive(false);
            player2.SetActive(true);
            col1.enabled = false;
            col2.enabled = true;
        }
        if (palhaco == false)
        {
            luz.transform.position = lanterna.transform.position;
        }
        if (!isLocalPlayer & lobby == false & seta == false & menu)
        {
            cam.GetComponent<Menu>().nomesid[id].transform.LookAt(GameObject.FindGameObjectWithTag("MainCamera").transform.position);

            if (palhaco == false)
            {
                cam.GetComponent<Menu>().nomesid[id].transform.position = new Vector3(posid.transform.position.x, posid.transform.position.y, posid.transform.position.z);
            }
            else
            {
                cam.GetComponent<Menu>().nomesid[id].transform.position = new Vector3(player2.GetComponent<PlayerOn>().posid.transform.position.x, player2.GetComponent<PlayerOn>().posid.transform.position.y, player2.GetComponent<PlayerOn>().posid.transform.position.z);
            }
        }
        else if (isLocalPlayer & menu)
        {           
            if(lobby == false & palhaco == false)
            {
                cam.transform.position = new Vector3(visão.transform.position.x, visão.transform.position.y, visão.transform.position.z);
            }
            if (Gerenciador.host)
            {
                RpcNome(Gerenciador.nome);
            }
            else
            {
                CmdNome(Gerenciador.nome);
            }
            if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().sairlobby)
            {
                escolheu = true;
                cam.GetComponent<Menu>().Desconecta();
            }
            if (escolheu == false)
            {
                if (Gerenciador.branco)
                {
                    Cmdbranco();
                }
                else if (Gerenciador.azul)
                {
                    Cmdazul();
                }
                else if (Gerenciador.verde)
                {
                    Cmdverde();
                }
                else if (Gerenciador.vermelho)
                {
                    Cmdvermelho();
                }
                else if (Gerenciador.amarelo)
                {
                    Cmdamarelo();
                }
                else if (Gerenciador.laranja)
                {
                    Cmdlaranja();
                }
                else if (Gerenciador.ciano)
                {
                    Cmdciano();
                }
                else if (Gerenciador.preto)
                {
                    Cmdpreto();
                }
                else if (Gerenciador.rosa)
                {
                    Cmdrosa();
                }
            }
            if (Menu.pausar == false & pausar == false & lobby == false)
            {
                som.volume = GameObject.FindGameObjectWithTag("volume").GetComponent<Slider>().value;

                y += Input.GetAxisRaw("Mouse X");
                x += Input.GetAxisRaw("Mouse Y");

                if (x <= valor2 & x >= -valor)
                {
                    eixoy = x;
                }
                else if (x > 0)
                {
                    x = valor2;
                }
                else if (x < 0)
                {
                    x = -valor;
                }
                if (palhaco == false)
                {
                    luz.transform.eulerAngles = cam.transform.eulerAngles;
                    transform.rotation = Quaternion.Euler(0, y * sensibilidade, 0);
                    cam.transform.eulerAngles = new Vector3(-eixoy * sensibilidade, y * sensibilidade, 0);
                    luz.GetComponent<LanternaOn>().liga.volume = GameObject.FindGameObjectWithTag("volume").GetComponent<Slider>().value;

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        if (luz.GetComponent<LanternaOn>().pilhas > 0 & ligou == false)
                        {
                            ligou = true;
                            CmdLiga();
                        }
                        else if (luz.GetComponent<LanternaOn>().pilhas > 0 & ligou)
                        {
                            ligou = false;
                            CmdDesliga();
                        }
                    }
                    if(luz.GetComponent<LanternaOn>().pilhas == 0)
                    {
                        ligou = false;
                        CmdDesliga();
                    }
                }
                else 
                {
                    player2.transform.position = transform.position;
                    rotacao.transform.position = transform.position;
                    rotacao.transform.eulerAngles = new Vector3(-eixoy * sensibilidade, y * sensibilidade, 0);

                    if (Gerenciador.cliente)
                    {
                        Cmdpalhaco();
                    }
                }
                if (Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.S))
                {
                    if (andar == false)
                    {
                        andar = true;
                        som.loop = true;
                        som.Play();
                    }
                    if (palhaco & outro)
                    {
                        transform.Translate(0, 0, 1.5f * Time.deltaTime);

                        if (atacar == false)
                        {
                            anda = true;
                            Cmdanda();
                            player2.GetComponent<PlayerOn>().a.SetBool("Andar", true);
                        }
                    }
                    else if (palhaco == false)
                    {
                        a.SetBool("Andar", true);
                    }
                }
                else
                {
                    som.Stop();
                    andar = false;

                    if (palhaco == false)
                    {
                        a.SetBool("Andar", false);
                    }
                    else if (palhaco & outro & anda)
                    {
                        anda = false;
                        Cmdesanda();
                        player2.GetComponent<PlayerOn>().a.SetBool("Andar", false);
                    }
                }
                if (Input.GetKey(KeyCode.W))
                {
                    if (palhaco & outro)
                    {
                        transform.rotation = Quaternion.Euler(0, y * sensibilidade, 0);

                        if (Input.GetKey(KeyCode.A))
                        {
                            transform.rotation = Quaternion.Euler(0, y * sensibilidade - 45, 0);
                        }
                        else if (Input.GetKey(KeyCode.D))
                        {
                            transform.rotation = Quaternion.Euler(0, y * sensibilidade + 45, 0);
                        }
                    }
                    else
                    {
                        transform.Translate(0, 0, 1.5f * Time.deltaTime);
                    }
                }
                if (Input.GetKey(KeyCode.A))
                {
                    if (palhaco & outro)
                    {
                        transform.rotation = Quaternion.Euler(0, y * sensibilidade - 90, 0);

                        if (Input.GetKey(KeyCode.W))
                        {
                            transform.rotation = Quaternion.Euler(0, y * sensibilidade - 45, 0);
                        }
                        else if (Input.GetKey(KeyCode.S))
                        {
                            transform.rotation = Quaternion.Euler(0, y * sensibilidade - 145, 0);
                        }
                    }
                    else
                    {
                        transform.Translate(-1.5f * Time.deltaTime, 0, 0);
                    }
                }
                if (Input.GetKey(KeyCode.D))
                {
                    if (palhaco & outro)
                    {
                        transform.rotation = Quaternion.Euler(0, y * sensibilidade + 90, 0);

                        if (Input.GetKey(KeyCode.W))
                        {
                            transform.rotation = Quaternion.Euler(0, y * sensibilidade + 45, 0);
                        }
                        else if (Input.GetKey(KeyCode.S))
                        {
                            transform.rotation = Quaternion.Euler(0, y * sensibilidade + 145, 0);
                        }
                    }
                    else if (palhaco == false)
                    {
                        transform.Translate(1.5f * Time.deltaTime, 0, 0);
                    }
                }
                //////////----------ATRÁS----------\\\\\\\\\\
                if (Input.GetKey(KeyCode.S))
                {
                    if (palhaco & outro)
                    {
                        player2.GetComponent<PlayerOn>().a.SetBool("Andar", true);
                        transform.rotation = Quaternion.Euler(0, y * sensibilidade - 180, 0);

                        if (Input.GetKey(KeyCode.A))
                        {
                            transform.rotation = Quaternion.Euler(0, y * sensibilidade - 145, 0);
                        }
                        else if (Input.GetKey(KeyCode.D))
                        {
                            transform.rotation = Quaternion.Euler(0, y * sensibilidade + 145, 0);
                        }
                    }
                    else if (palhaco == false)
                    {
                        a.SetBool("Atrás", true);
                        transform.Translate(0, 0, -1.5f * Time.deltaTime);
                    }
                }
                else if (palhaco == false)
                {
                    a.SetBool("Atrás", false);
                }
                //////////----------PULAR----------\\\\\\\\\\
                if (Input.GetKeyDown(KeyCode.Space) & palhaco == false)
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

                    if (palhaco == false)
                    {
                        a.SetBool("Pular", false);
                    }
                }
                //////////----------CORRER----------\\\\\\\\\\
                if (Input.GetKey(KeyCode.W) & Input.GetKey(KeyCode.LeftShift) | Input.GetKey(KeyCode.A) & Input.GetKey(KeyCode.LeftShift) & outro | Input.GetKey(KeyCode.D) & Input.GetKey(KeyCode.LeftShift) & outro | Input.GetKey(KeyCode.S) & Input.GetKey(KeyCode.LeftShift) & outro)
                {
                    som.pitch = 2;
                    Cmdcorre();
                    transform.Translate(0, 0, 5 * Time.deltaTime);

                    if (palhaco == false)
                    {
                        a.speed = 1.5f;
                        a.SetBool("Correr", true);
                    }
                    else if (outro)
                    {
                        corre = true;
                        player2.GetComponent<PlayerOn>().a.SetBool("Correr", true);
                    }
                }
                else
                {
                    som.pitch = 1;

                    if (palhaco == false)
                    {
                        a.speed = 1;
                        a.SetBool("Correr", false);
                    }
                    else if (palhaco & outro & corre)
                    {
                        corre = false;
                        Cmdescorre();
                        player2.GetComponent<PlayerOn>().a.SetBool("Correr", false);
                    }
                }
                //////////----------ATACAR----------\\\\\\\\\\
                if (Input.GetKeyDown(KeyCode.F) & outro & atacar == false)
                {
                    atacar = true;
                    Cmdataca();
                }
                else if (outro & atacar)
                {
                    tempo += Time.deltaTime;
                    player2.GetComponent<PlayerOn>().a.SetBool("Atacar", true);

                    if (tempo >= 0.2 & toca == false)
                    {
                        toca = true;
                        ataca.Play();

                        if (som.isPlaying)
                        {
                            som.Stop();
                        }
                    }
                    else if (tempo >= 1)
                    {
                        tempo = 0;
                        toca = false;
                        atacar = false;
                        Cmdesataca();
                        player2.GetComponent<PlayerOn>().a.SetBool("Atacar", false);

                        if (!som.isPlaying)
                        {
                            som.Play();
                        }
                    }
                }
                if(pega)
                {
                    pega = false;
                    luz.GetComponent<LanternaOn>().pilhas += 2;
                    luz.GetComponent<LanternaOn>().pilha.text = luz.GetComponent<LanternaOn>().pilhas + " / 5";
                }
            }
            else if (palhaco == false & a.GetCurrentAnimatorStateInfo(0).IsName("Morto"))
            {
                pausar = false;
                a.SetBool("Morrer", false);
                transform.position = new Vector3(respawns[renasce].transform.position.x, respawns[renasce].transform.position.y, respawns[renasce].transform.position.z);
            }
            else
            {
                som.Stop();
            }
        }
    }
    void OnApplicationQuit()
    {
        if (isServer)
        {
            NetworkManager.Shutdown();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "urso")
        {
            pontos++;
            cam.GetComponent<Menu>().PegaUrso();
            GameObject.FindGameObjectWithTag("placar").GetComponent<Gerenciador>().pontos++;

            if (id == 0)
            {
                GameObject.FindGameObjectWithTag("placar").GetComponent<Gerenciador>().ponto1 = pontos;
            }
            else if (id == 1)
            {
                GameObject.FindGameObjectWithTag("placar").GetComponent<Gerenciador>().ponto2 = pontos;
            }
            else if (id == 2)
            {
                GameObject.FindGameObjectWithTag("placar").GetComponent<Gerenciador>().ponto3 = pontos;
            }
            else if (id == 3)
            {
                GameObject.FindGameObjectWithTag("placar").GetComponent<Gerenciador>().ponto4 = pontos;
            }
            else if (id == 4)
            {
                GameObject.FindGameObjectWithTag("placar").GetComponent<Gerenciador>().ponto5 = pontos;
            }
            else if (id == 5)
            {
                GameObject.FindGameObjectWithTag("placar").GetComponent<Gerenciador>().ponto6 = pontos;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "palhaço" & palhaco == false)
        {
            a.SetBool("Morrer", true);

            if (isLocalPlayer)
            {
                pausar = true;
                renasce = Random.Range(0, respawns.Length);
            }
        }
        if (other.tag == "pilha" & palhaco == false)
        {
            if (luz.GetComponent<LanternaOn>().pilhas < 5)
            {
                pega = true;
                cam.GetComponent<Menu>().PegaUrso();
                luz.GetComponent<LanternaOn>().tempopilha = 60;
                Destroy(other.gameObject);
            }
            else if (isLocalPlayer)
            {
                GameObject.FindGameObjectWithTag("placar").GetComponent<Gerenciador>().avisa = true;
            }
        }
    }
    public override void OnNetworkDestroy()
    {
        if (menu)
        {
            if (id > 0)
            {
                CmdSair();
            }
            if (id == 1)
            {
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().dois = false;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().nomes[id].color = Color.red;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().nomes[id].text = "Player 2";
            }
            else if (id == 2)
            {
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().tres = false;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().nomes[id].color = Color.red;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().nomes[id].text = "Player 3";
            }
            else if (id == 3)
            {
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().quatro = false;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().nomes[id].color = Color.red;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().nomes[id].text = "Player 4";
            }
            else if (id == 4)
            {
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().cinco = false;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().nomes[id].color = Color.red;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().nomes[id].text = "Player 5";
            }
            else if (id == 5)
            {
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().seies = false;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().nomes[id].color = Color.red;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().nomes[id].text = "Player 6";
            }
        }
    }
    public void MudaCor(Color cor)
    {
        if(txtpreto)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().nomes[id].color = Color.gray;
        }
        else
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().nomes[id].color = cor;
        }
        if (!isLocalPlayer & GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().lobby == false)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().ids[id].GetComponent<Text>().color = cor;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().setas[id].GetComponent<Image>().color = cor;
        }
        if (palhaco == false)
        {
            lanterna.GetComponent<MeshRenderer>().materials[0].color = cor;
            materiais = corpo.GetComponent<SkinnedMeshRenderer>().materials;
            corpo.GetComponent<SkinnedMeshRenderer>().materials = materiais;

            materiais[1].color = cor;
            materiais[2].color = cor;
            materiais[3].color = cor;

            cabeca.GetComponent<SkinnedMeshRenderer>().materials[0].color = cor;
            cabeca.GetComponent<SkinnedMeshRenderer>().materials[11].color = cor;
            cabeca.GetComponent<SkinnedMeshRenderer>().materials[12].color = cor;

            if (lobby)
            {
                player2.GetComponent<PlayerOn>().corpo.GetComponent<SkinnedMeshRenderer>().materials[0].color = cor;
                player2.GetComponent<PlayerOn>().corpo.GetComponent<SkinnedMeshRenderer>().materials[1].color = Color.white;
                player2.GetComponent<PlayerOn>().corpo.GetComponent<SkinnedMeshRenderer>().materials[2].color = cor;
                player2.GetComponent<PlayerOn>().corpo.GetComponent<SkinnedMeshRenderer>().materials[4].color = cor;
                player2.GetComponent<PlayerOn>().corpo.GetComponent<SkinnedMeshRenderer>().materials[5].color = cor;
            }
        }
        else if (outro)
        {
            player2.GetComponent<PlayerOn>().corpo.GetComponent<SkinnedMeshRenderer>().materials[0].color = cor;
            player2.GetComponent<PlayerOn>().corpo.GetComponent<SkinnedMeshRenderer>().materials[1].color = Color.white;
            player2.GetComponent<PlayerOn>().corpo.GetComponent<SkinnedMeshRenderer>().materials[2].color = cor;
            player2.GetComponent<PlayerOn>().corpo.GetComponent<SkinnedMeshRenderer>().materials[4].color = cor;
            player2.GetComponent<PlayerOn>().corpo.GetComponent<SkinnedMeshRenderer>().materials[5].color = cor;
        }
    }
    [Command]
    public void Cmdpalhaco()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().outro = true;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().palhaco = true;
    }
    [Command]
    public void Cmdanda()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().sanda = true;
    }
    [Command]
    public void Cmdcorre()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().scorre = true;
    }
    [Command]
    public void Cmdataca()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().satacou = true;
    }
    [Command]
    public void Cmdesanda()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().sanda = false;
    }
    [Command]
    public void Cmdescorre()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().scorre = false;
    }
    [Command]
    public void Cmdesataca()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().satacou = false;
    }
    [Command]
    public void Cmdbranco()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().branco = true;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().azul = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().verde = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().vermelho = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().amarelo = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().laranja = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().ciano = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().preto = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().rosa = false;
    }
    [Command]
    public void Cmdazul()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().azul = true;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().branco = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().verde = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().vermelho = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().amarelo = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().laranja = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().ciano = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().preto = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().rosa = false;
    }
    [Command]
    public void Cmdverde()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().verde = true;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().branco = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().azul = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().vermelho = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().amarelo = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().laranja = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().ciano = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().preto = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().rosa = false;
    }
    [Command]
    public void Cmdvermelho()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().vermelho = true;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().branco = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().azul = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().verde = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().amarelo = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().laranja = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().ciano = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().preto = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().rosa = false;
    }
    [Command]
    public void Cmdamarelo()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().amarelo = true;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().branco = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().azul = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().verde = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().vermelho = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().laranja = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().ciano = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().preto = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().rosa = false;
    }
    [Command]
    public void Cmdlaranja()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().laranja = true;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().branco = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().azul = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().verde = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().vermelho = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().amarelo = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().ciano = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().preto = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().rosa = false;
    }
    [Command]
    public void Cmdciano()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().ciano = true;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().branco = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().azul = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().verde = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().vermelho = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().amarelo = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().laranja = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().preto = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().rosa = false;
    }
    [Command]
    public void Cmdpreto()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().preto = true;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().branco = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().azul = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().verde = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().vermelho = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().amarelo = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().laranja = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().ciano = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().rosa = false;
    }
    [Command]
    public void Cmdrosa()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().rosa = true;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().branco = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().azul = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().verde = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().vermelho = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().amarelo = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().laranja = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().ciano = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().preto = false;
    }
    [Command]
    public void CmdNome(string nome)
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().nomes[id].text = nome;

        if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().lobby == false)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().ids[id].GetComponent<Text>().text = nome;
        }
    }
    [Command]
    public void CmdLiga()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().RpcLiga();
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().luz.GetComponent<LanternaOn>().Ligar();
    }
    [Command]
    public void CmdDesliga()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().RpcDesliga();
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().luz.GetComponent<LanternaOn>().Desligar();
    }
    [Command]
    public void CmdSair()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().soma -= 1;
    }
    [ClientRpc]
    public void RpcNome(string nome)
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().nomes[id].text = nome;

        if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().lobby == false)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().ids[id].GetComponent<Text>().text = nome;
        }
    }
    [ClientRpc]
    public void RpcLiga()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().luz.GetComponent<LanternaOn>().Ligar();
    }
    [ClientRpc]
    public void RpcDesliga()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().luz.GetComponent<LanternaOn>().Desligar();
    }
    [ClientRpc]
    public void RpcRotacao(Vector3 rotacao)
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Menu>().players[id].GetComponent<PlayerOn>().luz.transform.eulerAngles = rotacao;
    }
}


