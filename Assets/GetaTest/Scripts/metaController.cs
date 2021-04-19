using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class metaController : MonoBehaviour
{
    public timer tiempo;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "KartPlayer" && tiempo.segundos > 0)
        {
            tiempo.DetenerTimer();
            Destroy(gameObject);
        }

    }
}
