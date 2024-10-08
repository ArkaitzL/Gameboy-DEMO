using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaboOnLite;

public class J1_Partidas : MonoBehaviour
{
    [SerializeField] int min_giro, max_giro;
    [SerializeField] int min_flechas, max_flechas;

    J1_Juego juego;

    const float TIEMPO_ESPERA = 2.25f;

    void Start()
    {
        //Inicia el juego estableciendo valores random
        juego = GetComponent<J1_Juego>();

        ControladorBG.Rutina(TIEMPO_ESPERA, () => {
            int flechas = Random.Range(min_flechas, max_flechas);
            int giro = Random.Range(min_giro, max_giro);

            juego.Iniciar(giro, flechas);
        });
    }
}
