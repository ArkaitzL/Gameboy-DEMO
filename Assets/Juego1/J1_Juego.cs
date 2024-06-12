using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaboOnLite;
using TMPro;

public class J1_Juego : MonoBehaviour
{
    [SerializeField] Controles controles;
    [SerializeField] GameObject[] flechas;
    [SerializeField] Transform centro;
    [SerializeField] GameObject particulas;
    [SerializeField] TextMeshProUGUI[] puntuaciones;
    [SerializeField] float velocidad;

    [HideInInspector] float rotacion;

    GameObject[] instanciadas = new GameObject[2];
    int[] cant_flechas = { 0, 0 }, aciertos = { 0, 0 };
    int max_flechas = 3;
    bool disponible;

    const float TIEMPO_ESPERA = .5f, MAX_ESPERA_IA = 2;

    void Iniciar(float rotacion, int max_flechas)
    {
        this.rotacion = rotacion;
        this.max_flechas = max_flechas;


        Crear(0);
        Crear(1);

        Puntuar(0, 0);
        Puntuar(1, 0);

        //IA
        ControladorBG.Rutina(Random.Range(TIEMPO_ESPERA + 0.1f, MAX_ESPERA_IA), () => {
            if (instanciadas == null || instanciadas[0] == null) return;
            IA();
        });
    }

    void Update()
    {
        //Jugador
        if (Input.GetKeyDown(controles.interactuar))
        {
            if(disponible) Lanzar(0);
        }

        //Rotar centro
        centro.Rotate(new Vector3(0,0,1) * rotacion * Time.deltaTime);
    }

    void IA() 
    {
        Lanzar(1);
        ControladorBG.Rutina(Random.Range(TIEMPO_ESPERA + 0.1f, MAX_ESPERA_IA), () => {
            if (instanciadas == null || instanciadas[0] == null) return;
            IA();
        });
    }

    void Crear(int persona)
    {
        if (max_flechas == cant_flechas[persona])
        {
            //Fin de persona X
            return;
        }

        cant_flechas[persona]++;

        instanciadas[persona] = Instantiate(flechas[persona], transform);
        if(persona == 0) disponible = false;
        ControladorBG.Rutina(TIEMPO_ESPERA, () =>
        {
            if (instanciadas == null || instanciadas[persona] == null) return;

            instanciadas[persona].GetComponent<Animator>().enabled = false;
            if (persona == 0) disponible = true;
        });
    }

    void Lanzar(int persona) 
    {
        instanciadas[persona].GetComponent<J1_Flecha>().Lanzar(this, velocidad, centro, particulas, persona);
        Crear(persona);
    }

    public void Puntuar(int persona, int puntos = 1) 
    {
        aciertos[persona] += puntos;
        puntuaciones[persona].text = $"{aciertos[persona]}/{max_flechas}";
    }
}
