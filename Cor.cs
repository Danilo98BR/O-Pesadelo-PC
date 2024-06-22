using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cor : MonoBehaviour
{
    void Start()
    {
        if(Gerenciador.azul)
        {
            GetComponent<MeshRenderer>().materials[0].color = Color.blue;
        }
        else if (Gerenciador.verde)
        {
            GetComponent<MeshRenderer>().materials[0].color = Color.green;
        }
        else if (Gerenciador.vermelho)
        {
            GetComponent<MeshRenderer>().materials[0].color = Color.red;
        }
        else if (Gerenciador.amarelo)
        {
            GetComponent<MeshRenderer>().materials[0].color = Color.yellow;
        }
        else if (Gerenciador.laranja)
        {
            Color cor = new Color(1, 0.2f, 0);
            GetComponent<MeshRenderer>().materials[0].color = cor;
        }
        else if (Gerenciador.ciano)
        {
            GetComponent<MeshRenderer>().materials[0].color = Color.cyan;
        }
        else if (Gerenciador.rosa)
        {
            GetComponent<MeshRenderer>().materials[0].color = Color.magenta;
        }
        else if (Gerenciador.preto)
        {
            GetComponent<MeshRenderer>().materials[0].color = Color.black;
        }
        else if (Gerenciador.online)
        {
            GetComponent<MeshRenderer>().materials[0].color = Color.white;
        }
    }
}
