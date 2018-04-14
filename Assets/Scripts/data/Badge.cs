using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class Badge {

    public int id;
    public string name;
    public string description;
    public int experience;
    public string texturePath;  //loaded from Resources dir

    public Badge(int id, string name, string description, int experience, string texturePath)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.experience = experience;
        this.texturePath = texturePath;
    }
}

