using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public delegate void IngredientClick(GameObject obj, Ingredient i);

public class ClickedIngredient : MonoBehaviour {

    public IngredientClick clickCallback;

    public Ingredient data;

    public void IsClicked()
    {
        clickCallback.Invoke(gameObject, data);
    }
}
