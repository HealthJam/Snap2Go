﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadgeUI : MonoBehaviour {

    public Image badgeImage;

    public Text badgeName;

    public Text description;

    public Text experience;

    public void Initialize(Badge data)
    {
        badgeImage.sprite = Resources.Load<Sprite>(data.texturePath);

        badgeName.text = data.name;

        description.text = data.description;

        experience.text = data.experience.ToString();
    }
}
