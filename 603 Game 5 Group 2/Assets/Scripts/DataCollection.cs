using System.IO;
using UnityEngine;

public class DataCollection
{
    public static void CollectData(Player player)
    {
        string path = Application.persistentDataPath + "CollectedData.json";
        FileStream stream = new FileStream(path, FileMode.Create);
        Data data = new Data(player);

        //stream.(data);
        stream.Close();
    }
}
