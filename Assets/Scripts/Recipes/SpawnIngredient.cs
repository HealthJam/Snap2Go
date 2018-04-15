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

    public float EXPLORE_SPAWN_RATE_SECONDS = 10;
    public float EXPEDITION_SPAWN_RATE_SECONDS = 5;
    public float SPAWN_SCALE = 10f;

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
        Vector2d newLoc = LocationProvider.CurrentLocation.LatitudeLongitude + new Vector2d(Random.Range(-.002f, .002f), Random.Range(-.0022f, .0022f));

        int index = Random.Range(0, AllIngredients.Count);
        GameObject prefab = AllIngredients[index].prefab;
        var instance = Instantiate(prefab);
        instance.transform.localPosition = _map.GeoToWorldPosition(newLoc, true);
        instance.transform.localScale = new Vector3(SPAWN_SCALE, SPAWN_SCALE, SPAWN_SCALE);
    }

    private void Start()
    {
        StartCoroutine(ExpeditionSpawnRoutine());
        StartCoroutine(ExploreSpawnRoutine());
    }

    IEnumerator ExpeditionSpawnRoutine()
    {
        while (true)
        {
            while (GameplayLoop.Instance.state.Equals(GameplayLoop.GameState.EXPEDITION_IN_PROGRESS))
            {
                SpawnRandom();
                yield return new WaitForSeconds(EXPEDITION_SPAWN_RATE_SECONDS);
            }
            yield return 0;
        }
    }

    IEnumerator ExploreSpawnRoutine()
    {
        while(true) { 
            while(GameplayLoop.Instance.state.Equals(GameplayLoop.GameState.EXPLORE))
            {
                SpawnRandom();
                yield return new WaitForSeconds(EXPLORE_SPAWN_RATE_SECONDS);
            }
            yield return 0;
        }
    }
}
