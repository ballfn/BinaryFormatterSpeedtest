using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading;
using OdinSerializer;
[System.Serializable]
public class envSaveTest
{
    static public string Dpath = Application.persistentDataPath;
    static public bool useOdin = true;
    //call and return save function thread
    static public Thread saveChunk(chunk chunkToSave)
    {
        Thread save = new Thread(() => _SaveChunk(chunkToSave));
        save.Start();
        return save;
    }
    //save thread
    static void _SaveChunk(chunk _chunk)
    {
        string path = Dpath + "/chunk.chenv";
        if (useOdin)
        {
            byte[] bytes = SerializationUtility.SerializeValue(_chunk, DataFormat.Binary);
            File.WriteAllBytes(path, bytes);
        }
        else
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);
            formatter.Serialize(new BufferedStream(stream), _chunk);
            stream.Close();
        }
    }
    //call and return load function thread

    static public Thread LoadChunk()
    {
        var info = new DirectoryInfo(Dpath);
        FileInfo[] chunkList = info.GetFiles("chunk.chenv");
        if (chunkList.Length == 0)
        {
            //if no file exists return null
            return null;
        }
        var chunkFileToCall = chunkList[0];
        Thread load = new Thread(() => LoadChunkThread(chunkFileToCall));
        load.Start();

        return load;
    }
    //load thread
    static void LoadChunkThread(FileInfo chunkFile)
    {
        Debug.Log("loading file " + chunkFile.Name);
        if (useOdin)
        {
            byte[] bytes = File.ReadAllBytes(chunkFile.FullName);
            SerializationUtility.DeserializeValue<chunk>(bytes, DataFormat.Binary);
        }
        else
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(chunkFile.FullName, FileMode.Open);
            chunk save = formatter.Deserialize(new BufferedStream(stream)) as chunk;
            stream.Close();
        }
       
    }
}
