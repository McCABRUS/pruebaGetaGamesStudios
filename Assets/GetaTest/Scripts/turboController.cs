using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turboController : MonoBehaviour
{
    public kartController kart;
    // Start is called before the first frame update
    void Start()
    {
        iTween.RotateBy(this.gameObject, iTween.Hash(
            "y", 0.5f,
            "speed", 200f,
            "looptype", iTween.LoopType.pingPong,
            "easetype", iTween.EaseType.easeInOutSine
        ));
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "KartPlayer")
        {
            kart.velMov = 1.5f;
            Invoke ("DetenerTurbo", 1);
            
        }
    }

    void DetenerTurbo()
    {
        kart.velMov = 1f;
        Destroy(gameObject);
    }
}
