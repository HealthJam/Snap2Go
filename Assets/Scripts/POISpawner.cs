using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Location;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using Mapbox.Unity.Utilities;
using Mapbox.CheapRulerCs;
public class POISpawner : MonoBehaviour {




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
		Vector2d newLoc = LocationProvider.CurrentLocation.LatitudeLongitude + new Vector2d(Random.Range(-.002f, .002f), Random.Range(-.0022f, .0022f));

	
		GameObject prefab = _poi;
		var instance = Instantiate(prefab);
		instance.transform.name = "POI";
		instance.transform.localPosition = _map.GeoToWorldPosition(newLoc, true);
		instance.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
	}
	private IEnumerator Start()
	{
	//	locations = snapLocations.GetComponent<LocationProvider> ();

		yield return new WaitForSeconds (1);
		SpawnRandom ();
	//	foreach (SnapLocation snap in locations.snapLocationList) 
	//	{
	//		SpawnPOIAtLocation (snap, snap.latitude, snap.longitude);
	//	}

		

	}

	public double[] dist;
	public int currentIndex;
	public void SpawnPOIAtLocation(SnapLocation _snap, double lat, double lon)
	{
		dist = new double[813];
		var map = LocationProviderFactory.Instance.mapManager;
		CheapRuler ruler = new CheapRuler (LocationProvider.CurrentLocation.LatitudeLongitude.x, CheapRulerUnits.Miles);



		//dist[currentIndex] = Vector3.Distance(
		//	VectorExtensions.AsUnityPosition(_map.GeoToWorldPosition(LocationProvider.CurrentLocation.LatitudeLongitude),_map.CenterMercator, 1),
		//	VectorExtensions.AsUnityPosition( _map.GeoToWorldPosition(new Vector2d(lat,lon),true),_map.CenterMercator, 1));

		double[] snaploc = {lon, lat};
		double[] playerLoc = {LocationProvider.CurrentLocation.LatitudeLongitude.y, LocationProvider.CurrentLocation.LatitudeLongitude.x};

		double thisDist = ruler.Distance (playerLoc, snaploc);
	
		if (thisDist > 0) {
			Debug.Log ("Yoda" + _snap.storeName + thisDist);
			dist [currentIndex] = thisDist;
			currentIndex++;
		}


	}
}
