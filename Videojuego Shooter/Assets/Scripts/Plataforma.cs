using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Plataforma : MonoBehaviour
{
    public GameObject plataforma;
    public float velocidad;
    public Transform puntoActual;
    public Transform[] puntos;
    public int puntoSeleccionado;

    // Start is called before the first frame update
    void Start()
    {
        puntoActual = puntos[puntoSeleccionado];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        plataforma.transform.position = Vector3.MoveTowards(
            plataforma.transform.position, puntoActual.position, Time.deltaTime * velocidad);

        if (plataforma.transform.position == puntoActual.position)
        {
            puntoSeleccionado += 1;
            if (puntoSeleccionado == puntos.Length)
            {
                puntoSeleccionado = 0;
            }
            puntoActual = puntos[puntoSeleccionado];
        }
    }
}
