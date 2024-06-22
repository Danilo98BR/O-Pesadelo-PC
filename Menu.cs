using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.SceneManagement;

public class Menu : NetworkBehaviour
{
    AudioSource musica;
    public AudioSource urso;
    public AudioSource botao;
    
    public GameObject[] players;
    public Slider volume;

    public Button seta1;
    public Button seta2;

    public Canvas menu;
    public Canvas jogo;
    public Canvas carrega;
    public Canvas online;
    public Canvas opcoes;
    public Canvas credit;

    // MENU
    public Text[] voltar;
    public Text tituloprincipal;
    public Text jogarprincipal;
    public Text onlineprincipal;
    public Text opcoesprincipal;
    public Text sairprincipal;

    string volta;
    string nometitulo;
    string jogar;
    string carregar;
    string jogaronline;
    string opcao;
    string sair;

    // JOGAR
    public Text historia;
    public Text contar;
    public Text inicia;
    public Text carregando;
    public Text [] credito;

    string titulo;
    string texto;
    string inicio;
    string creditos;

    public float seg;
    public bool comeca;

    // Online
    public NetworkManager net;
    public Text[] nomes;
    public InputField id;
    public Canvas botoes;
    public string nome;
    bool achou;

    [SyncVar] public bool um;
    [SyncVar] public bool dois;
    [SyncVar] public bool tres;
    [SyncVar] public bool quatro;
    [SyncVar] public bool cinco;
    [SyncVar] public bool seies;
    [SyncVar] public int soma;

    public Button servidor;
    public Text comecapartida;
    public bool sairlobby;
    string partida;

    public Text crianome;
    public Text nomejogador;
    public Text entrar;
    public Text placar;
    public Text[] pontos;
    public Canvas pontuacao;

    string placarpontos;
    string peganome;
    string usuario;
    string entra;
    string nomelobby;

    // LOBBY
    public Text titulolobby;
    public Text procura;
    public Text mudacor;
    public Text voltacor;
    public Text sairdolobby;

    public GameObject[] nomesid;
    public GameObject[] setas;
    public GameObject[] ids;
    public GameObject[] posicoes;

    string procurar;
    string mudacores;
    string voltacores;
    string sailobby;

    // OPÇÕES
    public Text menuopcao;
    public Text resolucao;
    public Text idioma;

    string menuopcoes;
    string tela;
    string language;

    // Pausa
    string pausa;
    string resume;
    string voltamenu;

    public int altura;
    public int largura;
    public int muda;
    public int x;
    public int y;

    public float escala;

    public static bool pausar;
    public bool mudou;
    public bool cena;
    public bool lobby;
    bool portugues;
    bool ajusta;
    bool pausou;

    // JOGO
    public Canvas cores;
    public Canvas perdeuse;
    public Canvas ganhou;
    public Canvas lanterna;
    public Canvas pcorre;
    public Text tutorial;
    public AudioSource fim;
    public AudioClip noite;
    public AudioClip perde;
    public AudioClip ganha;
    public static Color cor;
    public Text perdeu;
    public Text venceu;
    public Text denovo;
    public Text[] voltarmenu;
    public Text[] sairjogo;
    public static string aviso;
    string novo;
    string acabou;
    string morreu;
    string ligar;
    string corre;
    public int trocar;
    public bool aperta;

    public Text controles;
    public Text andar;
    public Text correr;
    public Text pular;
    public Text spausar;
    public Text scorre;

    string controle;
    string anda;
    string pula;
    string spausa;
    string correndo;


    void Start()
    {
        largura = Screen.width;
        altura = Screen.height;
        x = largura;
        y = altura;
        net = GameObject.FindGameObjectWithTag("lobby").GetComponent<NetworkManager>();
      
        if (cena == false)
        {
            Cursor.visible = true;
            menu.enabled = true;
            carrega.enabled = false;
            online.enabled = false;
            jogo.enabled = false;
            opcoes.enabled = false;
            credit.enabled = false;
            botoes.enabled = false;
            resolucao.text = tela + x + " x " + y;
            QualitySettings.vSyncCount = 1;
            musica = GetComponent<AudioSource>();
            musica.Play();
        }
        else if (lobby)
        {
            cores.enabled = false;

            if (Gerenciador.palhaco)
            {
                Gerenciador.palhaco = false;
            }
        }
        else
        {
            menu.enabled = false;
            opcoes.enabled = false;
            musica = GetComponent<AudioSource>();
            musica.Play();
        }
    }
    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");

        if (ajusta == false)
        {
            if (altura == 768)
            {
                muda = 1;
                ajusta = true;
            }
            else if (altura == 1080)
            {
                muda = 2;
                ajusta = true;
            }
            else if (altura == 1440)
            {
                muda = 3;
                ajusta = true;
            }
            else if (altura == 2160)
            {
                muda = 4;
                ajusta = true;
            }
            else
            {
                ajusta = true;
            }
        }
        if (Screen.height == 1080)
        {
            escala = 2.2f;
        }
        else
        {
            escala = Screen.height * 2.2f / 1080;
        }
        if (lobby == false)
        {
            menu.GetComponent<Canvas>().scaleFactor = escala;
            jogo.GetComponent<Canvas>().scaleFactor = escala;
            opcoes.GetComponent<Canvas>().scaleFactor = escala;           
        }
        if (cena == false)
        {
            online.GetComponent<Canvas>().scaleFactor = escala;
            botoes.GetComponent<Canvas>().scaleFactor = escala;
            credit.GetComponent<Canvas>().scaleFactor = escala;
            carrega.GetComponent<Canvas>().scaleFactor = escala / 1.2f;

            musica.volume = volume.value;
            botao.volume = volume.value;

            if (comeca)
            {
                seg -= Time.deltaTime;
                musica.volume = seg;
                botao.volume = seg;

                if (seg <= - 4)
                {
                    SceneManager.LoadScene("Jogo");
                }
            }
            if (Application.systemLanguage == SystemLanguage.Portuguese & Gerenciador.troca == false & lobby == false)
            {
                portugues = true;
                Gerenciador.portugues = true;
            }
            else
            {
                portugues = false;
                Gerenciador.portugues = false;

                volta = "Back";
                voltar[0].text = volta;
                voltar[1].text = volta;
                voltar[2].text = volta;
                voltar[3].text = volta;
                voltar[4].text = volta;

                ///////////---------MENU---------\\\\\\\\\\\

                nometitulo = "The Nightmare";
                jogar = "Play";
                jogaronline = "MultiPlayer";
                opcao = "Options";
                creditos = "Credits";
                sair = "Quit Game";

                tituloprincipal.text = nometitulo;
                jogarprincipal.text = jogar;
                onlineprincipal.text = jogaronline;
                opcoesprincipal.text = opcao;
                credito[0].text = creditos;
                credito[1].text = creditos;
                sairprincipal.text = sair;

                ///////////---------JOGAR---------\\\\\\\\\\\ 

                titulo = "Plot";
                texto = "A girl named Ana, sleeps next to her teddy bear Ted every night. but in one of her dreams, she ends up being chased by a maniacal clown. Now, she will have to collect all the teddy bears to wake up or she will be trapped in this nightmare forever.";
                inicio = "Start";

                historia.text = titulo;
                contar.text = texto;
                inicia.text = inicio;

                ///////////---------CARREGA---------\\\\\\\\\\\

                controle = "Controls";
                anda = "Walk";
                corre = "Run";
                pula = "Jump";
                spausa = "Pause the Game";
                carregar = "Loading...";

                controles.text = controle;
                andar.text = anda;
                correr.text = corre;
                pular.text = pula;
                spausar.text = spausa;
                carregando.text = carregar;

                ///////////---------ONLINE---------\\\\\\\\\\\

                nomelobby = "MultiPlayer";
                peganome = "Create a player name to enter";
                usuario = "Name:";
                entra = "Enter";

                titulolobby.text = nomelobby;
                crianome.text = peganome;
                nomejogador.text = usuario;
                entrar.text = entra;

                ///////////---------OPÇÕES---------\\\\\\\\\\\ 

                menuopcoes = "Options";
                tela = "Resolution:   ";
                language = "Language:   English(USA)";

                menuopcao.text = menuopcoes;
                resolucao.text = tela + x + " x " + y;
                idioma.text = language;

                seta1.GetComponent<RectTransform>().localPosition = new Vector3(-40, 0, 0);
                seta2.GetComponent<RectTransform>().localPosition = new Vector3(175, 0, 0);
            }
            if (portugues & Gerenciador.troca == false & lobby == false)
            {
                volta = "Voltar";
                voltar[0].text = volta;
                voltar[1].text = volta;
                voltar[2].text = volta;
                voltar[3].text = volta;
                voltar[4].text = volta;

                ///////////---------MENU---------\\\\\\\\\\\

                nometitulo = "O Pesadelo";
                jogar = "Jogar";
                jogaronline = "MultiJogador";
                opcao = "Opções";
                creditos = "Créditos";
                sair = "Sair do Jogo";

                tituloprincipal.text = nometitulo;
                jogarprincipal.text = jogar;
                onlineprincipal.text = jogaronline;
                opcoesprincipal.text = opcao;
                credito[0].text = creditos;
                credito[1].text = creditos;
                sairprincipal.text = sair;

                ///////////---------JOGAR---------\\\\\\\\\\\ 

                titulo = "Trama";
                texto = "Uma garota chamada Ana, dorme ao lado de seu ursinho Ted todas as noites. Mas em um dos seus sonhos, ela acaba sendo perseguida por um palhaço maníaco. Agora, ela terá que coletar todos os ursos de pelúcia para acordar ou ficará presa nesse pesadelo para sempre.";
                inicio = "Iniciar";

                historia.text = titulo;
                contar.text = texto;
                inicia.text = inicio;

                ///////////---------CARREGA---------\\\\\\\\\\\

                controle = "Controles";
                anda = "Andar";
                corre = "Correr";
                pula = "Pular";
                spausa = "Pausar o Jogo";
                carregar = "Carregando...";

                controles.text = controle;
                andar.text = anda;
                correr.text = corre;
                pular.text = pula;
                spausar.text = spausa;
                carregando.text = carregar;

                ///////////---------ONLINE---------\\\\\\\\\\\

                nomelobby = "MultiJogador";
                peganome = "Crie um nome de jogador para entrar";
                usuario = "Nome:";
                entra = "Entrar";

                titulolobby.text = nomelobby;
                crianome.text = peganome;
                nomejogador.text = usuario;
                entrar.text = entra;

                ///////////---------OPÇÕES---------\\\\\\\\\\\ 

                menuopcoes = "Opções";
                tela = "Resolução:   ";
                language = "Idioma:   Português(Brasil)";

                menuopcao.text = menuopcoes;
                resolucao.text = tela + x + " x " + y;
                idioma.text = language;

                seta1.GetComponent<RectTransform>().localPosition = new Vector3(-95, 0, 0);
                seta2.GetComponent<RectTransform>().localPosition = new Vector3(190, 0, 0);
            }
        }
        else if (cena & lobby == false)
        {
            musica.volume = volume.value;
            botao.volume = volume.value;

            online.GetComponent<Canvas>().scaleFactor = escala;
            perdeuse.GetComponent<Canvas>().scaleFactor = escala;
            ganhou.GetComponent<Canvas>().scaleFactor = escala;
            pontuacao.GetComponent<Canvas>().scaleFactor = escala;
            lanterna.GetComponent<Canvas>().scaleFactor = escala;
            pcorre.GetComponent<Canvas>().scaleFactor = escala;

            if (Input.GetKey(KeyCode.F) & aperta == false & PlayerOff.mover == false & cena)
            {
                aperta = true;
                lanterna.enabled = false;
            }
            else if (PlayerOff.mover)
            {
                lanterna.enabled = false;
            }
            if (Gerenciador.palhaco)
            {
                if(Input.GetKey(KeyCode.W) & (Input.GetKey(KeyCode.LeftShift)))
                {
                    pcorre.enabled = false;
                }
            }
            else
            {
                pcorre.enabled = false;
            }
        }
        else if (cena & lobby)
        {
            jogo.GetComponent<Canvas>().scaleFactor = escala;
            online.GetComponent<Canvas>().scaleFactor = escala;
            opcoes.GetComponent<Canvas>().scaleFactor = escala;
        }
        if (cena & Application.systemLanguage == SystemLanguage.Portuguese & Gerenciador.troca == false & lobby == false)
        {
            portugues = true;
            Gerenciador.portugues = true;

            if (Input.GetKeyDown(KeyCode.P))
            {
                if (pausar == false & pausou == false)
                {
                    Pausa();
                    pausar = true;
                }
                else if (pausar & pausou)
                {
                    Retoma();
                    pausar = false;
                }
            }
            else if (Input.GetKeyUp(KeyCode.P))
            {
                if (pausar)
                {
                    pausou = true;
                }
            }
        }
        else if (cena & lobby == false)
        {
            portugues = false;
            Gerenciador.portugues = false;

            if (Input.GetKeyDown(KeyCode.P))
            {
                if (pausar == false & pausou == false)
                {
                    Pausa();
                    pausar = true;
                }
                else if (pausar & pausou)
                {
                    Retoma();
                    pausar = false;
                }
            }
            else if (Input.GetKeyUp(KeyCode.P))
            {
                if (pausar)
                {
                    pausou = true;
                }
            }
            ///////////---------Pausa---------\\\\\\\\\\\

            pausa = "Pause";
            resume = "Resume";
            voltamenu = "Back to Menu";
            opcao = "Options";
            sair = "Quit Game";

            tituloprincipal.text = pausa;
            jogarprincipal.text = resume;
            onlineprincipal.text = voltamenu;
            opcoesprincipal.text = opcao;
            sairprincipal.text = sair;

            ///////////---------OPÇÕES---------\\\\\\\\\\\ 

            menuopcoes = "Options";
            tela = "Resolution:   ";
            language = "Language:   English(USA)";
            volta = "Back";

            voltar[0].text = volta;
            menuopcao.text = menuopcoes;
            resolucao.text = tela + x + " x " + y;
            idioma.text = language;

            seta1.GetComponent<RectTransform>().localPosition = new Vector3(-40, 0, 0);
            seta2.GetComponent<RectTransform>().localPosition = new Vector3(175, 0, 0);

            ///////////---------JOGO---------\\\\\\\\\\\

            if (Gerenciador.palhaco)
            {
                ligar = "Attack";
                correndo = "Run";
            }
            else
            {
                ligar = "Turn on and turn off the flashlight";
            }
            novo = "Try Again";
            aviso = "Reached Maximum Capacity!";
            acabou = "Thanks For Playing!";
            morreu = "You lose!";
            placarpontos = "Scoreboard";

            denovo.text = novo;
            tutorial.text = ligar;
            perdeu.text = morreu;
            venceu.text = acabou;
            scorre.text = correndo;
            placar.text = placarpontos;

            perdeu.GetComponent<RectTransform>().localPosition = new Vector3(80, 65);

            voltarmenu[0].text = voltamenu;
            voltarmenu[1].text = voltamenu;

            sairjogo[0].text = sair;
            sairjogo[1].text = sair;
        }
        if (cena & portugues & Gerenciador.troca == false)
        {
            ///////////---------Pausa---------\\\\\\\\\\\

            pausa = "Pausa";
            resume = "Resumir";
            voltamenu = "Voltar ao Menu";
            opcao = "Opções";
            sair = "Sair do Jogo";

            tituloprincipal.text = pausa;
            jogarprincipal.text = resume;
            onlineprincipal.text = voltamenu;
            opcoesprincipal.text = opcao;
            sairprincipal.text = sair;

            ///////////---------OPÇÕES---------\\\\\\\\\\\ 

            menuopcoes = "Opções";
            tela = "Resolução:   ";
            language = "Idioma:   Português(Brasil)";
            volta = "Voltar";

            voltar[0].text = volta;
            menuopcao.text = menuopcoes;
            resolucao.text = tela + x + " x " + y;
            idioma.text = language;

            seta1.GetComponent<RectTransform>().localPosition = new Vector3(-95, 0, 0);
            seta2.GetComponent<RectTransform>().localPosition = new Vector3(190, 0, 0);

            ///////////---------JOGO---------\\\\\\\\\\\

            if (Gerenciador.palhaco)
            {
                ligar = "Atacar";
                correndo = "Correr";
            }
            else
            {
                ligar = "Ligar e desligar a lanterna";
            }
            novo = "Tentar Novamente";
            aviso = "Antingiu Máxima Capacidade!";
            acabou = "Obrigado Por Jogar!";
            morreu = "Você Perdeu!";
            placarpontos = "Placar de Pontos";

            denovo.text = novo;
            tutorial.text = ligar;
            perdeu.text = morreu;
            venceu.text = acabou;
            scorre.text = correndo;
            placar.text = placarpontos;

            voltarmenu[0].text = voltamenu;
            voltarmenu[1].text = voltamenu;

            sairjogo[0].text = sair;
            sairjogo[1].text = sair;
        }
        else if (cena & lobby & Gerenciador.portugues)
        {
            ///////////---------LOBBY---------\\\\\\\\\\\

            nomelobby = "MultiJogador";
            mudacores = "Mudar Cor";
            voltacores = "Voltar";
            partida = "Iniciar partida";
            sailobby = "Sair do Lobby";

            if (Gerenciador.host)
            {
                comecapartida.text = partida;
                procurar = "O jogador host inicia a partida";
            }
            else
            {
                comecapartida.enabled = false;
                procurar = "Aguarde o jogador host iniciar...";
            }
            titulolobby.text = nomelobby;
            procura.text = procurar;
            mudacor.text = mudacores;
            voltacor.text = voltacores;
            sairdolobby.text = sailobby;
        }
        else if (cena & lobby)
        {
            ///////////---------LOBBY---------\\\\\\\\\\\

            nomelobby = "MultiPlayer";
            mudacores = "Change Color";
            voltacores = "Back";
            partida = "Start Game";
            sailobby = "Quit Lobby";

            if(Gerenciador.host)
            {
                comecapartida.text = partida;
                procurar = "the host player starts the game";
            }
            else
            {
                comecapartida.enabled = false;
                procurar = "Wait the host player starts...";
            }
            titulolobby.text = nomelobby;
            procura.text = procurar;
            mudacor.text = mudacores;
            voltacor.text = voltacores;
            sairdolobby.text = sailobby;
        }
        if (mudou)
        {
            if (muda == 0)
            {
                x = 1280;
                y = 720;
            }
            else if (muda == 1)
            {
                x = 1366;
                y = 768;
            }
            else if (muda == 2)
            {
                x = 1920;
                y = 1080;
            }
            else if (muda == 3)
            {
                x = 2560;
                y = 1440;
            }
            else if (muda == 4)
            {
                x = 3840;
                y = 2160;
            }
            mudou = false;

            if (cena == false)
            {
                resolucao.text = tela + x + " x " + y;
            }
            Screen.SetResolution(x, y, true);
        }
    }
    public void MenuPrincipal()
    {
        SomBotao();
        menu.enabled = true;
        carrega.enabled = false;
        online.enabled = false;
        jogo.enabled = false;
        opcoes.enabled = false;
        credit.enabled = false;
    }
    public void Jogar()
    {
        SomBotao();
        jogo.enabled = true;
        menu.enabled = false;
        opcoes.enabled = false;
    }
    public void Online()
    {
        SomBotao();
        jogo.enabled = false;
        online.enabled = true;
        menu.enabled = false;
        opcoes.enabled = false;
    }
    public void Opcoes()
    {
        SomBotao();
        opcoes.enabled = true;
        menu.enabled = false;
        jogo.enabled = false;
    }
    public void Creditos()
    {
        SomBotao();
        menu.enabled = false;
        credit.enabled = true;
    }
    public void Resolucao()
    {
        SomBotao();
        mudou = true;

        if (altura == 768)
        {
            if (muda < 1)
            {
                muda++;
            }
        }
        else if (altura == 1080)
        {
            if (muda < 2)
            {
                muda++;
            }
        }
        else if (altura == 1440)
        {
            if (muda < 3)
            {
                muda++;
            }
        }
        else if (altura == 2160)
        {
            if (muda < 4)
            {
                muda++;
            }
        }
    }
    public void VoltaResolucao()
    {
        SomBotao();
        mudou = true;

        if (muda > 0)
        {
            muda--;
            mudou = true;
        }
    }
    public void Idioma()
    {
        SomBotao();

        if (portugues & Gerenciador.troca == false)
        {
            Gerenciador.troca = true;
        }
        else if (portugues == false & Gerenciador.troca)
        {
            Gerenciador.troca = false;
        }
    }
    public void Pausa()
    {
        Cursor.visible = true;

        if (Gerenciador.online == false)
        {
            musica.Pause();

            if (PlayerOff.pausar)
            {
                Time.timeScale = 0;
            }
            else
            {
                SomBotao();
                Time.timeScale = 0;
                menu.enabled = true;
                opcoes.enabled = false;
            }
        }
        else
        {
            SomBotao();
            menu.enabled = true;
            opcoes.enabled = false;
        }
    }
    public void Retoma()
    {
        SomBotao();
        pausar = false;
        pausou = false;
        Cursor.visible = false;

        if (Gerenciador.online == false)
        {
            musica.UnPause();
            Time.timeScale = 1;
            menu.enabled = false;
            opcoes.enabled = false;
        }
        else
        {
            menu.enabled = false;
            opcoes.enabled = false;
        }
    }
    public void Opcoes2()
    {
        SomBotao();
        opcoes.enabled = true;
        menu.enabled = false;
    }
    public void SomBotao()
    {
        botao.Play();
    }
    public void SomPerde()
    {
        botao.Stop();
        fim.clip = perde;
        fim.Play();
    }
    public void SomGanha()
    {
        botao.Stop();
        fim.clip = ganha;
        fim.Play();
    }
    public void Jogo()
    {
        seg = 1;
        SomBotao();
        comeca = true;
        jogo.enabled = false;
        carrega.enabled = true;
    }
    public void VoltaMenu()
    {
        pausar = false;
        pausou = false;

        if (Gerenciador.online == false)
        {
            Retoma();
            SceneManager.LoadScene("Menu");
        }
        else
        {
            Desconecta();
            net.onlineScene = "Lobby";
        }
    }
    public void Tentar()
    {
        SceneManager.LoadScene("Jogo");
    }
    public void Sair()
    {
        SomBotao();
        Application.Quit();
    }
    public void PegaUrso()
    {
        urso.Play();
    }
    void OnInternetMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matches)
    {
        if (matches.Count == 0 & achou == false)
        {
            achou = true;
            NetworkManager.singleton.matchMaker.CreateMatch("sala", 6, true, "", "", "", 0, 0, OnInternetMatchCreate);
        }
        else if (matches[0].currentSize <= 5 & achou == false)
        {
            achou = true;
            NetworkManager.singleton.matchMaker.JoinMatch(matches[0].networkId, "", "", "", 0, 0, OnJoinInternetMatch);
        }
    }
    void OnInternetMatchCreate(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        Gerenciador.host = true;
        Gerenciador.online = true;
        MatchInfo hostInfo = matchInfo;
        NetworkManager.singleton.StartHost(hostInfo);
    }
    void OnJoinInternetMatch(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        Gerenciador.cliente = true;
        Gerenciador.online = true;
        MatchInfo hostInfo = matchInfo;
        NetworkManager.singleton.StartClient(hostInfo);
    }
    public void Desconecta()
    {
        sairlobby = false;
        Gerenciador.online = false;
        net.StopMatchMaker();

        if (Gerenciador.host)
        {
            net.StopHost();
            Gerenciador.host = false;
        }
        else if (Gerenciador.cliente)
        {
            net.StopClient();
            Gerenciador.cliente = false;
        }
    }
    public void SairLobby()
    {
        SomBotao();
        sairlobby = true;

        Gerenciador.azul = false;
        Gerenciador.verde = false;
        Gerenciador.vermelho = false;
        Gerenciador.amarelo = false;
        Gerenciador.laranja = false;
        Gerenciador.ciano = false;
        Gerenciador.branco = false;
        Gerenciador.preto = false;
        Gerenciador.rosa = false;
    }
    public void Nomes(string nome)
    {
        soma++;

        if (um == false)
        {
            um = true;
            nomes[0].text = nome;
        }
        else if (dois == false)
        {
            dois = true;
            nomes[1].text = nome;
        }
        else if (tres == false)
        {
            tres = true;
            nomes[2].text = nome;
        }
        else if (quatro == false)
        {
            quatro = true;
            nomes[3].text = nome;
        }
        else if (cinco == false)
        {
            cinco = true;
            nomes[4].text = nome;
        }
        else if (seies == false)
        {
            seies = true;
            nomes[5].text = nome;
        }
    }
    public void SalvaNome()
    {
        SomBotao();
        nome = id.text;

        if (nome.Length > 0)
        {
            net.StartMatchMaker();
            Gerenciador.nome = nome;
            entrar.color = Color.green;
            net.matchMaker.ListMatches(0, 10, "sala", true, 0, 0, OnInternetMatchList);
        }
    }
    public void Pronto()
    {
        comecapartida.color = Color.green;
    }
    public void Verifica()
    {
        if (net.numPlayers > 0)
        {
            net.onlineScene = "Jogo";
            net.ServerChangeScene("Jogo");
        }
    }
    public void Troca()
    {
        trocar++;

        if (trocar == 1)
        {
            Gerenciador.palhaco = true;
        }
        else if (trocar == 2)
        {
            trocar = 0;
            Gerenciador.palhaco = false;
        }
    }
    public void Cores()
    {
        SomBotao();
        cores.enabled = true;
    }
    public void VoltaCores()
    {
        SomBotao();
        cores.enabled = false;
    }
    public void Azul()
    {
        SomBotao();
        Gerenciador.azul = true;
        Gerenciador.verde = false;
        Gerenciador.vermelho = false;
        Gerenciador.amarelo = false;
        Gerenciador.laranja = false;
        Gerenciador.ciano = false;
        Gerenciador.branco = false;
        Gerenciador.preto = false;
        Gerenciador.rosa = false;
    }
    public void Verde()
    {
        SomBotao();
        Gerenciador.verde = true;
        Gerenciador.azul = false;
        Gerenciador.vermelho = false;
        Gerenciador.amarelo = false;
        Gerenciador.laranja = false;
        Gerenciador.ciano = false;
        Gerenciador.branco = false;
        Gerenciador.preto = false;
        Gerenciador.rosa = false;
    }
    public void Vermelho()
    {
        SomBotao();
        Gerenciador.vermelho = true;
        Gerenciador.azul = false;
        Gerenciador.verde = false;
        Gerenciador.amarelo = false;
        Gerenciador.laranja = false;
        Gerenciador.ciano = false;
        Gerenciador.branco = false;
        Gerenciador.preto = false;
        Gerenciador.rosa = false;
    }
    public void Amarelo()
    {
        SomBotao();
        Gerenciador.amarelo = true;
        Gerenciador.azul = false;
        Gerenciador.verde = false;
        Gerenciador.vermelho = false;
        Gerenciador.laranja = false;
        Gerenciador.ciano = false;
        Gerenciador.branco = false;
        Gerenciador.preto = false;
        Gerenciador.rosa = false;
    }
    public void Laranja()
    {
        SomBotao();
        Gerenciador.laranja = true;
        Gerenciador.azul = false;
        Gerenciador.verde = false;
        Gerenciador.vermelho = false;
        Gerenciador.amarelo = false;
        Gerenciador.ciano = false;
        Gerenciador.branco = false;
        Gerenciador.preto = false;
        Gerenciador.rosa = false;
    }
    public void Branco()
    {
        SomBotao();
        Gerenciador.branco = true;
        Gerenciador.azul = false;
        Gerenciador.verde = false;
        Gerenciador.vermelho = false;
        Gerenciador.amarelo = false;
        Gerenciador.laranja = false;
        Gerenciador.ciano = false;
        Gerenciador.preto = false;
        Gerenciador.rosa = false;
    }
    public void Preto()
    {
        SomBotao();
        Gerenciador.preto = true;
        Gerenciador.azul = false;
        Gerenciador.verde = false;
        Gerenciador.vermelho = false;
        Gerenciador.amarelo = false;
        Gerenciador.laranja = false;
        Gerenciador.ciano = false;
        Gerenciador.branco = false;
        Gerenciador.rosa = false;
    }
    public void Ciano()
    {
        SomBotao();
        Gerenciador.ciano = true;
        Gerenciador.azul = false;
        Gerenciador.verde = false;
        Gerenciador.vermelho = false;
        Gerenciador.amarelo = false;
        Gerenciador.laranja = false;
        Gerenciador.branco = false;
        Gerenciador.preto = false;
        Gerenciador.rosa = false;
    }
    public void Rosa()
    {
        SomBotao();
        Gerenciador.rosa = true;
        Gerenciador.azul = false;
        Gerenciador.verde = false;
        Gerenciador.vermelho = false;
        Gerenciador.amarelo = false;
        Gerenciador.laranja = false;
        Gerenciador.branco = false;
        Gerenciador.ciano = false;
        Gerenciador.preto = false;
    }
}
