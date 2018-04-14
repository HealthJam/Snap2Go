using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SnapLocation {
    public SnapLocation(int id, string storeName, double longitude, double latitude, string streetAddress, string addressTwo, string city, string state, string zip, string county)
    {
        this.id = id;
        this.storeName = storeName;
        this.latitude = latitude;
        this.longitude = longitude;
        this.streetAddress = streetAddress;
        this.addressTwo = addressTwo;
        this.city = city;
        this.state = state;
        this.zip = zip;
        this.county = county;
    }

    public int id;
    public string storeName;
    public double longitude;
    public double latitude;
    public string streetAddress;
    public string addressTwo;
    public string city;
    public string state;
    public string zip;
    public string county;
}