using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMusicSheet : MonoBehaviour
{
    private XMLParser xmlParser;

    // Start is called before the first frame update
    void Start()
    {
        string path = System.IO.Path.Combine(Application.streamingAssetsPath, "MusicSheetXML/18�� ����_������_10.xml");
        xmlParser = XMLParser.GetXMLParser(path);
    }
}
