using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_TEMP : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            J_Controlador.victoria = true;
            J_Controlador.transiciones.SetTrigger("Abrir");
        }
    }
}
