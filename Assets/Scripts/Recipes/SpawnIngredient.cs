using Mapbox.Unity.Location;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIngredient : MonoBehaviour
{
    [SerializeField]
    private List<Ingredient> AllIngredients;

    [SerializeField]
    AbstractMap _map;

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

        int index = Random.Range(0, AllIngredients.Count);
        GameObject prefab = AllIngredients[index].prefab;
        var instance = Instantiate(prefab);
        instance.transform.localPosition = _map.GeoToWorldPosition(newLoc, true);
        instance.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        SpawnRandom();       
    }

    public void SpawnRandomAtLocation(double lat, double lon) {

        var map = LocationProviderFactory.Instance.mapManager;
        //transform.localPosition = map.GeoToWorldPosition(LocationProvider.CurrentLocation.LatitudeLongitude);
        Vector2d newLoc = LocationProvider.CurrentLocation.LatitudeLongitude + new Vector2d(Random.Range(-.0002f, .0002f), Random.Range(-.0002f, .0002f));

        int index = Random.Range(0, AllIngredients.Count);
        GameObject prefab = AllIngredients[index].prefab;
        var instance = Instantiate(prefab);
        instance.transform.localPosition = _map.GeoToWorldPosition(newLoc, true);
        //instance.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
        //_spawnedObjects.Add(instance);
    }

    public void SpawnIngredientAtLocation(Ingredient ing, double lat, double lon)
    {
        GameObject obj = Instantiate(ing.prefab);

        //set obj at lat lon utility


    }
}
