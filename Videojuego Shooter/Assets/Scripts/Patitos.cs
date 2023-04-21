using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Patitos : MonoBehaviour
{
    public TextMeshProUGUI cointext;
    public static int puntos = 0;

    // Start is called before the first frame update
    void Start()
    {
        cointext = GameObject.Find("Patos").GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            puntos = puntos + 1;
        EscribirPuntos();
        Destroy(gameObject);
    }

    void EscribirPuntos()
    {
        cointext.text = "" + puntos.ToString();
    }
}
