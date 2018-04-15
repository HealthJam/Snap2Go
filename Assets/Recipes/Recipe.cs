using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct usedIngredients
{
    public Ingredient ingredient;
    public float amount;
}

[CreateAssetMenu(menuName ="Recipe/Recipe" )]
public class Recipe : ScriptableObject
{
    public string recipeName;

    public List<usedIngredients> ingredientList = new List<usedIngredients>();

    public Dictionary<Ingredient, float> ingredients = new Dictionary<Ingredient, float>();

    private void Awake()
    {
        foreach (usedIngredients ing in ingredientList)
        {
            ingredients.Add(ing.ingredient, ing.amount);
        }
    }
}
