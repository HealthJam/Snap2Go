using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

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

    public Sprite recipeImage;

    public List<usedIngredients> ingredientList = new List<usedIngredients>();

    public Dictionary<Ingredient, float> ingredients = new Dictionary<Ingredient, float>();

    private bool init = false;

    public void Init()
    {
        init = true;

        if (init)
            return;
        foreach (usedIngredients ing in ingredientList)
        {
            ingredients.Add(ing.ingredient, ing.amount);
        }
    }
}
