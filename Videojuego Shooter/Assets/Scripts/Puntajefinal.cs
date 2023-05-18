using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntajefinal : MonoBehaviour
{
    public TextMeshProUGUI puntajefinal;

    // Start is called before the first frame update
    void Start()
    {
        puntajefinal.text = "" + PlayerPrefs.GetInt("puntuacion", 0).ToString();
    }

}
