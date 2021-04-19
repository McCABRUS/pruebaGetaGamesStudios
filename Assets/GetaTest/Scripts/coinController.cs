using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinController : MonoBehaviour
{
    public timer tiempo;
    // Start is called before the first frame update
    void Start()
    {
        iTween.RotateBy(this.gameObject, iTween.Hash(
            "z", 0.5f,
            "speed", 200f,
            "looptype", iTween.LoopType.pingPong,
            "easetype", iTween.EaseType.easeInOutSine
        ));
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "KartPlayer" && tiempo.segundos > 0)
        {
            tiempo.conteo.GetComponent<TMPro.TextMeshProUGUI>().text = tiempo.segundos + " +3";
            tiempo.segundos += 3;
            Destroy(gameObject);
        }
        
    }
}
