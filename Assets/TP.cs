using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP : MonoBehaviour
{
    [SerializeField] Transform posicion;

    public void Mover(Transform personaje) 
    {
        personaje.position = posicion.position;
    }
}
