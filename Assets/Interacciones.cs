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
        interacciones = new Dictionary<string, Interaccion>  {
            { "NPC", Npc }
        };
    }

    private void Update()
    {
        if (Controlador.modoJuego) return;
        Interactuar();
    }

    void Npc(GameObject objeto) 
    {
        Controlador.desafiado = objeto.GetComponent<Npc>();
        Controlador.modoJuego = true;

        Controlador.transiciones.SetTrigger("Abrir");
    }

    void Interactuar()
    {
        Vector3 direccion = transform.forward;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, direccion, out hit, DISTANCIA_INTERACCION))
        {
            if (Input.GetKeyDown(controles.interactuar))
            {
                foreach (var interaccion in interacciones)
                {
                    if (hit.collider.CompareTag(interaccion.Key)) interaccion.Value.Invoke(hit.collider.gameObject);
                }
            }

            cursor.color = color_interactuable;
            teclaUI.SetActive(true);
            return;
        }

        cursor.color = color_no_interactuable;
        teclaUI.SetActive(false);
    }
}
