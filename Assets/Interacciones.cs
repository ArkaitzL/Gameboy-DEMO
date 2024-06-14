using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interacciones : MonoBehaviour
{
    [SerializeField] Controles controles;
    [SerializeField] GameObject teclaUI;
    [SerializeField] Image cursor;
    [SerializeField] Color32 color_interactuable, color_no_interactuable;

    public delegate void Interaccion(GameObject obj);
    private Dictionary<string, Interaccion> interacciones;

    const float DISTANCIA_INTERACCION = 4;

    private void Start()
    {
        // Lista de las interaciones -> TAG / FUNCION
        interacciones = new Dictionary<string, Interaccion>  {
            { "NPC", Npc }
        };
    }

    private void Update()
    {
        if (J_Controlador.modoJuego) return;
        Interactuar();
    }

    void Npc(GameObject objeto) 
    {
        //Interactua con el personaje
        J_Controlador.desafiado = objeto.GetComponent<Npc>();
        J_Controlador.modoJuego = true;

        J_Controlador.transiciones.SetTrigger("Abrir");
    }

    void Interactuar()
    {
        Vector3 direccion = transform.forward;
        RaycastHit hit;

        // Lanza un rayo de interaccion
        if (Physics.Raycast(transform.position, direccion, out hit, DISTANCIA_INTERACCION))
        {
            foreach (var interaccion in interacciones)
            {
                if (hit.collider.CompareTag(interaccion.Key))
                {
                    //Ejecuta la funcion
                    if (Input.GetKeyDown(controles.interactuar)) interaccion.Value.Invoke(hit.collider.gameObject);

                    //Pinta el cursor
                    cursor.color = color_interactuable;
                    teclaUI.SetActive(true);
                }
                else 
                {
                    //Pinta el cursor
                    cursor.color = color_no_interactuable;
                    teclaUI.SetActive(false);
                }
            }
        }
        else
        {
            //Pinta el 
            cursor.color = color_no_interactuable;
            teclaUI.SetActive(false);
        }
    }
}
