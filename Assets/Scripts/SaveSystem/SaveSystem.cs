using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem {

    public static void SavePlayer()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerState";
        FileStream stream = new FileStream(path, FileMode.Create);

        int data = 1;

        formatter.Serialize(stream, data);

        stream.Close();
    }

    public static int LoadPlayer()
    {
        string path = Application.persistentDataPath + "/playerState";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            var data = (int) formatter.Deserialize(stream);
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return 0;
        }
    }
}
