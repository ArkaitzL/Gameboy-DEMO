using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    [SerializeField] GameObject camara1, camara2;
    [SerializeField] GameObject uiJugador;
    [SerializeField] Transform padre_juegos;
    [SerializeField] List<GameObject> juegos;

    GameObject juego;

    public static Animator transiciones;
    public static bool modoJuego = false;
    public static Npc desafiado = null;
    public static bool victoria;

    public static Controlador inst;

    private void Awake()
    {
        inst = this;
        transiciones = GetComponent<Animator>();
    }

    public void CambiarModo() 
    {
        if (!camara1.activeSelf) ModoNormal();
        else ModoJuego();
    }

    void ModoJuego() 
    {
        if (juegos.Count != 0)
        {
            int random = Random.Range(0, juegos.Count);
            juego = Instantiate(juegos[random], padre_juegos);
        }
        else Debug.LogWarning("Faltan juegos");

        camara1.SetActive(false);
        camara2.SetActive(true);

        uiJugador.SetActive(false);
    }

    void ModoNormal() 
    {
        modoJuego = false;

        Destroy(juego);
        if (victoria) desafiado.Perder();

        modoJuego = false;
        desafiado = null;

        camara1.SetActive(true);
        camara2.SetActive(false);

        uiJugador.SetActive(true);
    }
}
