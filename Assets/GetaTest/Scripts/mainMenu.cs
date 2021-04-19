using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenu : MonoBehaviour
{
    public GameObject juegosText;
    public GameObject victoriasText;
    public GameObject recordText;

    public int juegos;
    public int victorias;
    public int record;
    private void Start()
    {
        CargarDatos();
    }

    public void Salir()
    {
        Debug.Log("Se ha cerrado el juego");
        Application.Quit();
    }
    public void CargarDatos()
    {
        statsData data = saveData.CargarDatos();

        if (data != null)
        {
            juegos = data.juegos;
            victorias = data.victorias;
            record = data.record;
        }
        else
        {
            juegos = 0;
            victorias = 0;
            record = 0;
        }

        juegosText.GetComponent<TMPro.TextMeshProUGUI>().text = juegos.ToString();
        victoriasText.GetComponent<TMPro.TextMeshProUGUI>().text = victorias.ToString();
        recordText.GetComponent<TMPro.TextMeshProUGUI>().text = record.ToString();

    }
}
