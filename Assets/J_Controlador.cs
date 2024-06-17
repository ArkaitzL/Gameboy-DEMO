using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Controlador : MonoBehaviour
{
    [SerializeField] GameObject camara1, camara2;
    [SerializeField] GameObject uiJugador;
    [SerializeField] Transform padre_juegos;
    [SerializeField] List<GameObject> juegos;

    GameObject juego;
    Niveles niveles;

    public static Animator transiciones;
    public static bool modoJuego = false;
    public static Npc desafiado = null;
    public static bool victoria;

    public static J_Controlador inst;

    private void Awake()
    {
        inst = this;
        transiciones = GetComponent<Animator>();
    }

    private void Start()
    {
        niveles = Niveles.inst;
    }

    public void CambiarModo() 
    {
        //Cambia entre modo juego y modo normal
        if (!camara1.activeSelf) ModoNormal();
        else ModoJuego();
    }

    void ModoJuego() 
    {
        //Inastancia el juego y cambia las camaras
        if (juegos.Count != 0)
        {
            int random = Random.Range(0, (niveles.nivel_actual + 1  < juegos.Count) ? niveles.nivel_actual + 1 : juegos.Count);
            juego = Instantiate(juegos[random], padre_juegos);
        }
        else Debug.LogWarning("Faltan juegos");

        camara1.SetActive(false);
        camara2.SetActive(true);

        uiJugador.SetActive(false);
    }

    void ModoNormal() 
    {
        //Destruye el juego y cambia las camaras
        modoJuego = false;

        Destroy(juego);
        if (victoria) { // Gana el juego
            desafiado.Perder();
            Niveles.inst.perdidos_enemigos++;
        }

        modoJuego = false;
        desafiado = null;

        camara1.SetActive(true);
        camara2.SetActive(false);

        uiJugador.SetActive(true);
    }
}
