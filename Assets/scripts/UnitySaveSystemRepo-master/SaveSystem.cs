using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void SaveData()
    {
        
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/player1.fun";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, SaveProgress.instance.playerData);
        
        stream.Close();


        UpdateInGame();
    }
    public static void LoadPlayer()
    {
        string path = Application.persistentDataPath+ "/player1.fun";

        Debug.Log("Log Test 5.5" + path);
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveProgress.instance.playerData = formatter.Deserialize(stream) as PlayerData;

            stream.Close();
        }
        else
        {
            SaveData();
            Debug.LogWarning("Save file not found in" + path);
        }



       
    }
    public static void DeleteData()
    {
        string path = Application.persistentDataPath + "/player1.fun";
        if (File.Exists(path))
        {
            File.Delete(path);       
        }
    }

    public static void UpdateInGame()
    {
        try
        {
           // GameManager.instance.TopBarSuperGame.UpdateInfo(SaveProgress.instance.playerData);
        }
        catch (System.Exception ex)
        {
            Debug.Log("hata:"+ex.Message);
        }
       
    }

}
