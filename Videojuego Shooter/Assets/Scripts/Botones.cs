using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    public string EscenaJugar;
    public string EscenaSalir;
    public void Jugar()
    {
        SceneManager.LoadScene(EscenaJugar);
    }

    public void Salir()
    {
        SceneManager.LoadScene(EscenaSalir);
    }
}
