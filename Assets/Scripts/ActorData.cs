using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization; //obsahuje triedy, ktoré sa používajú na serializáciu objektov do dokument. v XML formate

public class ActorData
{
    [XmlAttribute("Name")]
    public string name;

    [XmlElement("Level")]
    public int level;

    [XmlElement("Score")]
    public int score;
}
