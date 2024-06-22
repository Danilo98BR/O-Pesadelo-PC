using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pisca : MonoBehaviour
{
    Light luz;
    public float tempo;

    void Start()
    {
        luz = GetComponent<Light>();
        luz.enabled = false;
    }
    void Update()
    {
        tempo += Time.deltaTime;

        if (tempo >= 1)
        {
            luz.enabled = true;
        }
        if (tempo >= 1.2)
        {
            luz.enabled = false;
            tempo = 0;
        }
    }
}
