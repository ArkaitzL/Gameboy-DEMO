using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacciones : MonoBehaviour
{
    [SerializeField] Controles controles;

    const float DISTANCIA_INTERACCION = 3;

    private void Update()
    {
        if (Controlador.modoJuego) return;

        Interactuar();
    }

    void Interactuar()
    {
        if (Input.GetKeyDown(controles.interactuar))
        {
            Vector3 direccion = transform.forward;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, direccion, out hit, DISTANCIA_INTERACCION) && hit.collider.CompareTag("NPC"))
            {
                Controlador.desafiado = hit.collider.GetComponent<Npc>();
                Controlador.modoJuego = true;

                Controlador.transiciones.SetTrigger("Abrir");
            }
        }
    }
}
