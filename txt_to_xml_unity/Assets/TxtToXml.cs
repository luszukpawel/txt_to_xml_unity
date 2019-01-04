using System;
using System.IO;
using System.Xml.Linq;
using UnityEngine;

public class TxtToXml : MonoBehaviour
{
    public void Convert()
    {
        Debug.Log("Conversion Executed");

        String[] data = File.ReadAllLines("TsignRecgTrain4170Annotation.txt");

        foreach (var line in data)
        {
            String[] args = line.Split(new string[] {";"}, StringSplitOptions.None);

            XElement[] _size = new[]
            {
                new XElement("width", args[1]),
                new XElement("height", args[2]),
                new XElement("depth", 3),
            };
            XElement[] _bndbox = new[]
            {
                new XElement("xmin", args[3]),
                new XElement("ymin", args[4]),
                new XElement("xmax", args[5]),
                new XElement("ymax", args[6]),
            };
            
            XElement[] _object = new[]
            {
                new XElement("name", args[7]),
                new XElement("pose", "Unspecified"),
                new XElement("truncated", 0),
                new XElement("difficult", 0),
                new XElement("bndbox", _bndbox),
            };

            XElement[] contents = new[]
            {
                new XElement("folder", "tsrd-train"),
                new XElement("filename", args[0]),
                new XElement("path", "C:/Users/pluszak/Desktop/tsrd-train/000_0001.png"),
                new XElement("source", new XElement("database", "Unknown")),
                new XElement("size", _size),
                new XElement("segmented", 0),
                new XElement("object", _object)
            };

            var xml = new XDocument(
                new XElement("annotation", contents)
            );

            xml.Save(args[0]+".Xml");
          //  return;
        }
    }
}

//new XElement("folder", from item in args select new XElement("folder",item)));