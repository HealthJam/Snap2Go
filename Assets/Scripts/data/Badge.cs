using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class Badge : Collectable {

    private int id;
    private string name;
    private string description;
    private int experience;
    private string texturePath;  //loaded from Resources dir

    public Badge(int id, string name, string description, int experience, string texturePath)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.experience = experience;
        this.texturePath = texturePath;
    }

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

