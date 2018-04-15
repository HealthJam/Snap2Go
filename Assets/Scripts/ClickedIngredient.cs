using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class ClickedIngredient : MonoBehaviour {

    public UnityEvent Clicked = new UnityEvent();

    public void IsClicked()
    {
        Clicked.Invoke();
    }
}
