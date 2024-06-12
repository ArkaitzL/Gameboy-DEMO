using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J1_Partidas : MonoBehaviour
{
    [SerializeField] int min_giro, max_giro;
    [SerializeField] int min_flechas, max_flechas;

    J1_Juego juego;
    
    void Start()
    {
        juego = GetComponent<J1_Juego>();

        //Tutorial
        //Inicia la partida
        //Cuando detecta que no quedan flechas la termina
    }

    private void Update()
    {
        //ELIMINAR
        if (Input.GetKeyDown(KeyCode.P))
        {
            Controlador.inst.ModoNormal();
        }
    }
}
