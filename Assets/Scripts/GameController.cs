using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Button saveButton;
    public Button loadButton;
    public const string playerPath = "Prefabs/Player";

    private static string dataPath = string.Empty;

    private void Awake()
    {
        dataPath = System.IO.Path.Combine(Application.dataPath,"Resources/actors.xml");
    }

    private void Start()
    {
        //CreateActor(playerPath,)
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Actor CreateActor(string path, string name)
    {
        Actor actor = new Actor();
        GameObject prefab = Resources.Load<GameObject>(path);
        
        return actor;
    }
    public static Actor CreateActor(ActorData data, string path, string name)
    {
        Actor actor = new Actor();
        GameObject prefab = Resources.Load<GameObject>(path);

        actor.data = data;

        return actor;
    }

}
