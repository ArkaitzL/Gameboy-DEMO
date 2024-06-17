using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Niveles : MonoBehaviour
{
    [SerializeField] Transform[] niveles;
    [SerializeField] GameObject[] puertas;

    [HideInInspector] public int perdidos_enemigos;
    [HideInInspector] public int nivel_actual = -1;
    int cant_enemigos;
    bool fin;

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
        //TEMPORAL ***************
        if (Input.GetKeyDown(KeyCode.P))
        {
            Destroy(puertas[nivel_actual]);

            if (niveles.Length - 1 == nivel_actual)
            {
                fin = true;
                return;
            }; 
            ProximoNivel();
        }
        //TEMPORAL ***************

        if (!fin && cant_enemigos == perdidos_enemigos)
        {
            Destroy(puertas[nivel_actual]);

            if (niveles.Length - 1 == nivel_actual) 
            {
                fin = true;
                return;
            };

            ProximoNivel();
        }
    }

    void ProximoNivel() 
    {
        nivel_actual++;

        perdidos_enemigos = 0;
        cant_enemigos = niveles[nivel_actual].GetComponentsInChildren<Npc>().Length; // *** Cambiar por busqueda por tag *** //
    }

    public void EnemigoDerrotado() => perdidos_enemigos += 1;
}
