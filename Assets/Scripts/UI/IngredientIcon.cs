using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientIcon : MonoBehaviour {

    public Image ingredientImage;

    public Text ingredientName;

    public void Initialize(Ingredient data)
    {
        //ingredientImage.sprite = data.ingredientImage;

        ingredientName.text = data.name;
    }
}
