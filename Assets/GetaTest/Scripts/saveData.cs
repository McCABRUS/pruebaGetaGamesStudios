using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class saveData
{
    public static void GuardarDatos(timer datos)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gameStats.data";
        FileStream stream = new FileStream(path, FileMode.Create);
        statsData datosSerializables = new statsData(datos);
        formatter.Serialize(stream, datosSerializables);
        stream.Close();
    }

    public static statsData CargarDatos()
    {
        string path = Application.persistentDataPath + "/gameStats.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            statsData data = formatter.Deserialize(stream) as statsData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("Archivo de estadísticas no escontrado en " + path);
            return null;
        }
    }


}
