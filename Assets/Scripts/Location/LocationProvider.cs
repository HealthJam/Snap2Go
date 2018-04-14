using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LocationProvider : MonoBehaviour {

    public List<SnapLocation> snapLocationList = new List<SnapLocation>();

    // Use this for initialization
    void Start()
    {
        TextAsset targetFile = Resources.Load<TextAsset>("snap_locations");
        string snapLocationJson = targetFile.text;
        IDictionary result = (IDictionary )MiniJSON.Json.Deserialize(snapLocationJson);
        IList locationList = (IList)result["results"];
        foreach (IDictionary location in locationList)
        {
            IDictionary attributes = location["attributes"] as IDictionary;
            SnapLocation snapLocation = new SnapLocation(Convert.ToInt32(attributes["OBJECTID"]),
                attributes["STORE_NAME"].ToString(),
                Convert.ToDouble(attributes["longitude"]),
                Convert.ToDouble(attributes["latitude"]),
                attributes["ADDRESS"].ToString(),
                attributes["ADDRESS2"].ToString(),
                attributes["CITY"].ToString(),
                attributes["STATE"].ToString(),
                attributes["ZIP5"].ToString(),
                attributes["County"].ToString());
            snapLocationList.Add(snapLocation);
        }
    }
}