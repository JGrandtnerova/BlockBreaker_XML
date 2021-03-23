using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class ActorData
{
    [XmlAttribute("Name")]
    public string name;

    [XmlElement("Level")]
    public int level;

    [XmlElement("Score")]
    public int score;
}
