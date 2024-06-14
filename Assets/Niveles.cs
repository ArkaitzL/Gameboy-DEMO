using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Niveles : MonoBehaviour
{
    [SerializeField] Transform[] niveles;

    [HideInInspector] public int perdidos_enemigos;
    int cant_enemigos;
    int nivel_actual = -1;
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
            Destroy(niveles[nivel_actual].Find("Puerta").gameObject);

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
            Destroy(niveles[nivel_actual].Find("Puerta").gameObject); // *** Cambiar por busqueda por tag *** // *** Ponerle animacion *** //

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
