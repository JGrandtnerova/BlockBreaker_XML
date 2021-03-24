using System.Collections;
using UnityEngine;
using System.Xml.Serialization;
using System.Collections.Generic;

[XmlRoot("ActorCollection")] //nazov schemy rootu/korena XML dokumentu
public class ActorContainer
{
    [XmlArray("Actors")]
    [XmlArrayItem("Actors")]
    public List<ActorData> actors = new List<ActorData>();

}
