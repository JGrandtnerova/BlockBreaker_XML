using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;

public class SaveData 
{
    public static ActorData LoadName(string path,string name)
    {
        ActorContainer actorContainer = new ActorContainer();
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

    public static void SaveActor(ActorData  tosavedata)
    {
        bool saved = false;


        ActorContainer newactors = new ActorContainer();
        ActorContainer actors = LoadActors(Path.Combine(Application.dataPath, "Resources/actors.xml"));
        foreach (ActorData data in actors.actors)
        {
            if (data.name == tosavedata.name)
            {
                newactors.actors.Add(tosavedata);
                saved = true;
            }
            else { newactors.actors.Add(data); }

        }
        Console.WriteLine(tosavedata);
        if (!saved)
        {
            newactors.actors.Add(tosavedata);
        }

        SaveActors(Path.Combine(Application.dataPath, "Resources/actors.xml"), newactors);
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
     public static List<ActorData> TopPlayers()
     {
         ActorContainer actors = LoadActors(Path.Combine(Application.dataPath, "Resources/actors.xml"));

        List<ActorData> unsorted = new List<ActorData>();

        foreach (ActorData data in actors.actors)
         {

            unsorted.Add(data);

        }

        List<ActorData> sorrted = unsorted.OrderByDescending(o => o.score).ToList();

        return sorrted;
    }

}
