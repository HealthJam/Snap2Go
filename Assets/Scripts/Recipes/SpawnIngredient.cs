using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIngredient : MonoBehaviour
{
    [SerializeField]
    private List<Ingredient> AllIngredients;

    public void SpawnRandom()
    {

    }

    public void SpawnRandomAtLocation(double lat, double lon)
    {

    }

    public void SpawnIngredientAtLocation(Ingredient ing, double lat, double lon)
    {
        GameObject obj = Instantiate(ing.prefab);

        //set obj at lat lon utility


    }
}
