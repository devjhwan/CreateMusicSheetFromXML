using System;
using System.IO;
using System.Xml;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class XMLParser
{
    private int     divisions;
    private double  beats;
    private double  beat_type;
    private int     BPM;
    private int     measureLength;

    public class XMLReadingError: System.Exception
    {
        public XMLReadingError(string message) : base(message) { }
    }

    public static XMLParser GetXMLParser(string xmlPath)
    {
        if (xmlPath == null || !File.Exists(xmlPath))
        {
            Debug.LogError(xmlPath + " doesn't exists. Check filename and directory.");
            return null;
        }
        else
        {
            try
            {
                return new XMLParser(xmlPath);
            } catch (XMLReadingError ex)
            {
                Debug.LogError(ex.Message);
                return null;
            }
        }
    }

    private XMLParser(string xmlPath)
    {
        Debug.Log(xmlPath);
        XmlDocument xmlDoc = new XmlDocument();
        if (xmlDoc == null)
            throw new XMLReadingError("Failed to create XMLDocument object");
        try
        {
            xmlDoc.Load(xmlPath);
        } catch (System.Exception ex)
        {
            throw new XMLReadingError("File loading error:" + ex.Message);
        }
        try
        {
            XmlElement root = xmlDoc.DocumentElement;
            XmlNode part = root.SelectSingleNode("part");

            divisions = int.Parse(root.GetElementsByTagName("divisions")[0].InnerText);
            beats = double.Parse(root.GetElementsByTagName("beats")[0].InnerText);
            beat_type = double.Parse(root.GetElementsByTagName("beat-type")[0].InnerText);
            BPM = int.Parse(root.GetElementsByTagName("per-minute")[0].InnerText);
            measureLength = Mathf.RoundToInt((float)(divisions * (4 * beats / beat_type)));

            XmlNodeList measures = part.ChildNodes;
            foreach(XmlNode measure in measures)
            {

            }
        } catch (NullReferenceException ex)
        {
            throw new XMLReadingError("Missing node:" + ex.Message);
        }
    }
}
