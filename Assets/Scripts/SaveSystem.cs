using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveData(CustSet cust)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Player.bruh";
        FileStream stream = new FileStream(path, FileMode.Create);

        DataToSave data = new DataToSave(cust);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static DataToSave LoadPlayer ()
    {
        string path = Application.persistentDataPath + "/Player.bruh";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            DataToSave data = formatter.Deserialize(stream) as DataToSave;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
