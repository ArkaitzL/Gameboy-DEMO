using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Collider))]
public class Movimiento : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] float velocidad = 7;

    [Header("Rotación")]
    [SerializeField] float sensibilidad = 2;
    [SerializeField] float anguloMax = 90f, anguloMin = -90f;
    float rotacionX = 0f;

    [Header("Otros")]
    [SerializeField] Controles controles;
    [SerializeField] Animator transiciones;

    Rigidbody rb;
    CharacterController cc;

    const float DISTANCIA_INTERACCION = 3;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();

        rb.freezeRotation = true; // Para evitar que el Rigidbody gire por la física
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Mover();

        if (Controlador.modoJuego) return;
        
        Rotar();
        Interactuar();
    }

    void Mover()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 movimiento = transform.TransformDirection(new Vector3(x, 0, z).normalized * velocidad);
        cc.Move(Controlador.modoJuego ? Vector3.zero : movimiento * Time.deltaTime);
    }

    void Rotar() 
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidad;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidad;

        if (mouseX != 0)
        {
            // Rotar cuerpo
            transform.Rotate(Vector3.up, mouseX);
        }

        if (mouseY != 0)
        {
            // Rotar cámara
            rotacionX -= mouseY;
            rotacionX = Mathf.Clamp(rotacionX, anguloMin, anguloMax);
            Camera.main.transform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);
        }
    }

    void Interactuar() 
    {
        if (Input.GetKeyDown(controles.interactuar)) 
        {
            Vector3 direccion = transform.forward;

            RaycastHit hit;
            if (Physics.Raycast(transform.position, direccion, out hit, DISTANCIA_INTERACCION) && hit.collider.CompareTag("NPC"))
            {
                transiciones.SetTrigger("Abrir");
                Controlador.modoJuego = true;
            }
        }
    }
}
