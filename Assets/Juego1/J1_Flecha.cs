using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaboOnLite;

public class J1_Flecha : MonoBehaviour
{
    [SerializeField] float direccion = 1;

    J1_Juego juego;
    GameObject particulas;
    Transform centro;
    float velocidad = 0;
    int persona;
    bool lanzado;

    const float DISTANCIA_CENTRO = 1.5f;

    void Update()
    {
        if (!lanzado) return;

        //Añade velocidad a la flecha
        transform.Translate((Vector3.up * direccion) * velocidad * Time.deltaTime);
        //Si impacta en el centro se detenie
        if (transform.position.y < DISTANCIA_CENTRO &&  -DISTANCIA_CENTRO < transform.position.y )
        {
            juego.Puntuar(persona);

            lanzado = false;
            transform.parent = centro;
            enabled = false;
        }

    }

    public void Lanzar(J1_Juego juego, float velocidad, Transform centro, GameObject particulas, int persona) 
    {
        lanzado = true;

        this.juego = juego;
        this.velocidad = velocidad;
        this.centro = centro;
        this.particulas = particulas;
        this.persona = persona;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Si chaca contra otra flecha se destruye
        if (!lanzado) return;
        lanzado = false;

        GameObject particulas_obj = Instantiate(particulas, transform.position, Quaternion.identity);
        Destroy(particulas_obj, 1);

        //Pierde punto ***

        Destroy(gameObject);
    }
}
