using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Location;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using Mapbox.Unity.Utilities;
using Mapbox.CheapRulerCs;
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
		Vector2d newLoc = LocationProvider.CurrentLocation.LatitudeLongitude + new Vector2d(Random.Range(-.002f, .002f), Random.Range(-.0022f, .0022f));

	//	int index = Random.Range(0, AllIngredients.Count);
	//	GameObject prefab = AllIngredients[index].prefab;
	//	var instance = Instantiate(prefab);
	//	instance.transform.localPosition = _map.GeoToWorldPosition(newLoc, true);
	//	instance.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
	}

	private IEnumerator Start()
	{
		locations = snapLocations.GetComponent<LocationProvider> ();

		yield return new WaitForSeconds (1);

		foreach (SnapLocation snap in locations.snapLocationList) 
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
            store.transform.localScale = new Vector3(2,2,2);
            Debug.Log(currentIndex);
        }
	}
}
