using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aceiteController : MonoBehaviour
{
    public kartController kart;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "KartPlayer")
        {
            kart.velMov = 0.45f;
            iTween.RotateBy(kart.gameObject, iTween.Hash(
                    "y", 0.125f,
                    "name", "primerTween",
                    "time", 1f,
                    "easetype", iTween.EaseType.easeOutElastic
                )
            );
            Invoke("SegundaVez", 1.5f);
        }
    }
    void SegundaVez()
    {
        kart.velMov = 0.6f;
        iTween.RotateBy(kart.gameObject, iTween.Hash(
                "y", -0.25f,
                "name", "segundoTween",
                "time", 1f,
                "easetype", iTween.EaseType.easeInOutElastic
            )
        );
        Invoke("RecuperarControl", 1.5f);

    }

    void RecuperarControl()
    {
        iTween.RotateBy(kart.gameObject, iTween.Hash(
                "y", 0.125f,
                "time", 0.4f,
                "easetype", iTween.EaseType.linear
            )
        );
        kart.velMov = 1f;
        Destroy(gameObject);
    }
}
