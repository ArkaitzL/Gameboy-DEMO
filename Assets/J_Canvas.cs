using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Canvas : MonoBehaviour
{
    void Start()
    {
        // Pone la camara en el canvas del juego
        Camera camara = GameObject.FindGameObjectWithTag("J_Canvas").GetComponent<Camera>();
        GetComponent<Canvas>().worldCamera = camara;
    }
}
