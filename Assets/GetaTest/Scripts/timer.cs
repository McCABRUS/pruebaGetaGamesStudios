using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class timer : MonoBehaviour
{

    public int segundos;
    public GameObject conteo;
    public loader cargaMenuPrincipal;
    private bool victoria;

    public int juegos;
    public int victorias;
    public int record;

    // Start is called before the first frame update
    void Start()
    {
        victoria = false;
        IniciarTimer();
    }

    
    public void IniciarTimer()
    {
        DibujarTimer(segundos);
        Invoke("ActualizarTimer", 1f);
    }

    public void DetenerTimer()
    {
        //juego finalizado (Victoria)
        CargarDatos();
        victoria = true;
        string s;
        string isRecord;
        if(segundos == 1)
        {
            s = "";
        }
        else
        {
            s = "s";
        }
        if (record < segundos)
        {
            record = segundos;
            isRecord = "nuevo record";
        }
        else
        {
            isRecord = "Lo lograste";
        }
        conteo.GetComponent<TMPro.TextMeshProUGUI>().text = "¡Victoria! con " + segundos +  " segundo" + s + " restante" + s +" ¡" + isRecord + "!";
        cargaMenuPrincipal.cargarNivel();
        juegos++;
        victorias++;
        
        GuardarDatos();

    }

    private void ActualizarTimer()
    {
        if(!victoria)
        {
            segundos--;

            if (segundos <= 0)
            {
                //juego finalizado (Derrota)
                CargarDatos();
                conteo.GetComponent<TMPro.TextMeshProUGUI>().text = "¡Derrota! Mejor suerte para la próxima.";
                conteo.GetComponent<TMPro.TextMeshProUGUI>().fontSize = 30f;
                cargaMenuPrincipal.cargarNivel();
                juegos++;
                GuardarDatos();

            }
            else
            {
                DibujarTimer(segundos);
                Invoke("ActualizarTimer", 1f);
            }
        }        
    }

    private void DibujarTimer(int s)
    {
        conteo.GetComponent<TMPro.TextMeshProUGUI>().text = s.ToString();
    }

    public void GuardarDatos()
    {
        saveData.GuardarDatos(this);
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
        
        
    }

}
