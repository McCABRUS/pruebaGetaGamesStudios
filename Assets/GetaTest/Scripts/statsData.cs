using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class statsData
{
    public int juegos;
    public int victorias;
    public int record;

    public statsData(timer data) {
        juegos = data.juegos;
        victorias = data.victorias;
        record = data.record;
    }
}
