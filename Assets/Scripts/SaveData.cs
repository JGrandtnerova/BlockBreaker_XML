using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class SaveData 
{
    public static ActorContainer actorContainer = new ActorContainer();

    public delegate void SerializeAction();
    public static event SerializeAction OnLoaded;
    public static event SerializeAction OnBeforeSave;




    public static ActorData Load(string path,string name)
    {
        actorContainer = LoadActors(path);

        foreach(ActorData data in actorContainer.actors)
        {
            if (name == data.name)
            {
                return data;
            }
            
        }
        return null;

    }
    public static void Save(string path,ActorContainer actors)
    {
        OnBeforeSave();
        SaveActors(path, actors);
        ClearActors();
    }
    public static void AddActorData(ActorData data)
    {
        actorContainer.actors.Add(data);

    }
    public static void ClearActors()
    {
        actorContainer.actors.Clear();
    }

    public static ActorContainer LoadActors(string path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ActorContainer));
        FileStream stream = new FileStream(path, FileMode.Open);
        ActorContainer actors = serializer.Deserialize(stream) as ActorContainer;
      
        stream.Close();
        return actors;
    }
    public static void SaveActors(string path,ActorContainer actors)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ActorContainer));
        FileStream stream = new FileStream(path, FileMode.Truncate);
        serializer.Serialize(stream, actors);
        stream.Close();
    }
}
