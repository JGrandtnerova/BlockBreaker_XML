using System.Collections;
using UnityEngine;
using System.Xml.Serialization;
using System.Collections.Generic;

[XmlRoot("ActorCollection")]
public class ActorContainer
{
    [XmlArray("Actors")]
    [XmlArrayItem("Actors")]
    public List<ActorData> actors = new List<ActorData>();

}
