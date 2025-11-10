using UnityEngine;
using System.IO;

public static class SavingDataSystem
{
    static string savePath = Application.persistentDataPath + "/SaveFile.json";

    public static void Save()
    {
        //convierte en texto el script que teníamos y lo generamos como archivo de texto con el texto dentro
        string json = JsonUtility.ToJson(Stats.userStats, true);
        File.WriteAllText(savePath, json);
        Debug.Log("Guardado en: " + savePath);
    }
    
    public static void Load()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            Stats.userStats = JsonUtility.FromJson<UserStats>(json);
            Debug.Log("Datos cargados");
        }
        else
        {
            Debug.Log("No hay datos guardados");
        }
    }
}
