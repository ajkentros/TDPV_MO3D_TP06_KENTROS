using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceIndicatorController : MonoBehaviour
{
    // define variables para la Ball y el scrollbar de la fuerza
    public BowlingBallController ballController;
    public Scrollbar forceScrollbar;


    void Start()
    {
        // ajusta el valor inicial del size del Scrollbar a cero
        if (forceScrollbar != null)
        {
            forceScrollbar.size = 0f;
        }
    }
    void Update()
    {
        // si son nulos la ball y el scrollbar de la fuerza => sale mensaje
        if (ballController == null || forceScrollbar == null)
        {
            Debug.LogError("No hay Ball y Fuerza en Quad");
            return;
        }

        // define variable para usar en el scrollbar
        float normalizedForce = ballController.CurrentForce / ballController.MaxForce;

        // verifica si normalizedForce no es NaN (nulla)
        if (!float.IsNaN(normalizedForce))
        {
            forceScrollbar.size = normalizedForce;
        }
        else
        {
            // mensaje de depuración
            Debug.LogError("normalizedForce es NaN en ForceIndicatorController.");
        }
    }
}
