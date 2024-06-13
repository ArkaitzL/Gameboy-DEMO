using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Niveles : MonoBehaviour
{
    [SerializeField] Transform[] niveles;

    [HideInInspector] public int perdidos_enemigos;
    int cant_enemigos;
    int nivel_actual = -1;

    public static Niveles inst;

    private void Awake()
    {
        inst = this;
    }

    private void Start()
    {
        ProximoNivel();
    }

    private void Update()
    {
        if (cant_enemigos == perdidos_enemigos && niveles.Length -1 != nivel_actual)
        {
            Debug.Log("Ganado");
            niveles[nivel_actual].GetComponentInChildren<Puerta>().Abrir();

            ProximoNivel();
        }
    }

    void ProximoNivel() 
    {
        nivel_actual++;

        perdidos_enemigos = 0;
        cant_enemigos = niveles[nivel_actual].GetComponentsInChildren<Npc>().Length;
    }

    public void EnemigoDerrotado() => perdidos_enemigos += 1;
}
