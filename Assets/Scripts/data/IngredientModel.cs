using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientModel : Collectable {

    private  int id;
    private string name;
    private string description;
    private int experience;
    private string texturePath;

    public int getId()
    {
        return id;
    }

    public string getName()
    {
        return name;
    }

    public string getDescription()
    {
        return description;
    }

    public int getExperience()
    {
        return experience;
    }

    public string getTexturePath()
    {
        return texturePath;
    }
}
