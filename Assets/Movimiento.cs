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

    Rigidbody rb;
    CharacterController cc;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();

        // Congela el cursor y el rb
        rb.freezeRotation = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Mover();
        if (J_Controlador.modoJuego) return;
        Rotar();
    }

    void Mover()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 movimiento = transform.TransformDirection(new Vector3(x, 0, z).normalized * velocidad);
        cc.Move(J_Controlador.modoJuego ? Vector3.zero : movimiento * Time.deltaTime);
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
}
