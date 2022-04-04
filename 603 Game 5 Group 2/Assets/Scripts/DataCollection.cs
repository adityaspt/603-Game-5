using System.IO;
using UnityEngine;

public class DataCollection
{
    public static void CollectData(Player player)
    {
        Data data = new Data(player);
        string jsonString = JsonUtility.ToJson(data);
        StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/data2.text");
        writer.Write(jsonString);
        writer.Close();
        Debug.Log("data collected");
        Debug.Log(Application.persistentDataPath);
        //Old Code as backup
/*        string path = Application.persistentDataPath + "CollectedData.json";
        FileStream stream = new FileStream(path, FileMode.Create);
        //stream.(data);
        stream.Close();*/
    }
}
