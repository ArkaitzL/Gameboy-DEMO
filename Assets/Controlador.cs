using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    [SerializeField] GameObject camara1, camara2;
    [SerializeField] GameObject cursor;
    [SerializeField] Transform padre_juegos;
    [SerializeField] List<GameObject> juegos;

    GameObject juego;

    public static bool modoJuego = false;
    public static Controlador inst;

    private void Awake()
    {
        inst = this;
    }

    public void ModoJuego() 
    {
        if (juegos.Count != 0)
        {
            int random = Random.Range(0, juegos.Count);
            juego = Instantiate(juegos[random], padre_juegos);
        }
        else Debug.LogWarning("Faltan juegos");

        camara1.SetActive(false);
        camara2.SetActive(true);

        cursor.SetActive(false);
    }

    public void ModoNormal() 
    {
        Destroy(juego);
        modoJuego = false;

        camara1.SetActive(true);
        camara2.SetActive(false);

        cursor.SetActive(true);
    }
}
