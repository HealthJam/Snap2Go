using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class Badge : Collectable {

    private int id;
    private string n;
    private string description;
    private int experience;
    private string texturePath;  //loaded from Resources dir

    public Badge(int id, string name, string description, int experience, string texturePath)
    {
        this.id = id;
        this.n = name;
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
        return n;
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

