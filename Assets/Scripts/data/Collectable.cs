using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Collectable {

    int getId();
    string getName();
    string getDescription();
    int getExperience();
    string getTexturePath(); 
}
