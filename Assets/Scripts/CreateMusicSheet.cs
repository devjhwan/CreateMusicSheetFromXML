using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMusicSheet : MonoBehaviour
{
    private XMLParser xmlParser;

    // Start is called before the first frame update
    void Start()
    {
        string path = System.IO.Path.Combine(Application.streamingAssetsPath, "MusicSheetXML/18세 순이_이찬원_10.xml");
        xmlParser = XMLParser.GetXMLParser(path);
    }
}
