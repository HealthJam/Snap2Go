﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeIcon : MonoBehaviour {

    public Image recipeImage;

    public Text recipeName;

    public Text description;

    public void Initialize(Recipe data)
    {
        //recipeImage.sprite = data.recipeImage;

        recipeName.text = data.name;

        description.text = "You will need: ";

        foreach (usedIngredients ing in data.ingredientList)
        {
            description.text += ing.ingredient.IngredientName + ", ";
        }

        description.text = description.text.Remove(description.text.Length - 2);
    }
}
