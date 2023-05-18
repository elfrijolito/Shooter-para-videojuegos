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
        PlayerPrefs.DeleteKey("puntuacion");
        cointext = GameObject.Find("Monedas").GetComponent<TextMeshProUGUI>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            puntos = puntos + 1;
            EscribirPuntos();
            Destroy(gameObject);

            if(puntos > PlayerPrefs.GetInt("puntuacion", 0))
            {
                PlayerPrefs.SetInt("puntuacion", puntos);
            }
        }
            

    }

    void EscribirPuntos()
    {
        cointext.text = "" + puntos.ToString(); 
    }
}
