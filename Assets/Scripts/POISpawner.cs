using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Location;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using Mapbox.Unity.Utilities;
using Mapbox.CheapRulerCs;
using System;

public class POISpawner : MonoBehaviour {

    public GameObject storePrefab;

	[SerializeField]
	GameObject snapLocations;

	[SerializeField]
	AbstractMap _map;

	[SerializeField]
	GameObject _poi;

	LocationProvider locations;
	ILocationProvider _locationProvider;
	ILocationProvider LocationProvider
	{
		get
		{
			if (_locationProvider == null)
			{
				_locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider;
			}

			return _locationProvider;
		}
	}

	public void SpawnRandom()
	{
		var map = LocationProviderFactory.Instance.mapManager;
		float _spawnScale = 10f;
		Vector2d newLoc = LocationProvider.CurrentLocation.LatitudeLongitude + new Vector2d(UnityEngine.Random.Range(-.002f, .002f), UnityEngine.Random.Range(-.0022f, .0022f));

	
		GameObject prefab = _poi;
		var instance = Instantiate(prefab);
		instance.transform.name = "POI";
		instance.transform.localPosition = _map.GeoToWorldPosition(newLoc, true);
		instance.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
	}

	private void Start()
	{
        List<SnapLocation> snapLocationList = new List<SnapLocation>();
        TextAsset targetFile = Resources.Load<TextAsset>("snap_locations");
        string snapLocationJson = targetFile.text;
        IDictionary result = (IDictionary)MiniJSON.Json.Deserialize(snapLocationJson);
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

        foreach (SnapLocation snap in snapLocationList) 
		{
			SpawnPOIAtLocation (snap, snap.latitude, snap.longitude);
		}
	}

	public double[] dist;
	public int currentIndex;
	public void SpawnPOIAtLocation(SnapLocation _snap, double lat, double lon)
	{
		var map = LocationProviderFactory.Instance.mapManager;
        if(_snap.city.ToLower().Equals("orlando"))
        {
            Debug.Log(_snap.storeName);
            Vector2d loc = new Vector2d(lat, lon);
            currentIndex++;
            GameObject store = Instantiate(storePrefab);
            store.transform.localPosition = _map.GeoToWorldPosition(loc, true);
            store.transform.localScale = new Vector3(1,1,1) * 10;
            Debug.Log(currentIndex);
        }
	}
}
