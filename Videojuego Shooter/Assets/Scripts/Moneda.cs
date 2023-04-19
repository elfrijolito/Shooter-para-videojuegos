using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Moneda : MonoBehaviour
{
    public TextMeshProUGUI cointext;
    public static int puntos = 0;

    // Start is called before the first frame update
    void Start()
    {
        cointext = GameObject.Find("Monedas").GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            puntos = puntos+ 1;
            EscribirPuntos();
            Destroy(gameObject);
    }

    void EscribirPuntos()
    {
        cointext.text = "" + puntos.ToString();
    }
}
