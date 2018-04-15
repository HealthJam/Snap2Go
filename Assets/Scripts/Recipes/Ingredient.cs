using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(menuName = "Recipe/Ingredient")]
public class Ingredient : ScriptableObject
{
    public string IngredientName;

    public GameObject prefab;

    public Measurement unitType;
}
