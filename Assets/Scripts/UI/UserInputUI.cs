using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInputUI : MonoBehaviour {

    public InputField userName;

    public InputField age;

    public InputField weight;
    public Button startButton;

    private void Awake()
    {
        startButton.interactable = false;
        userName.onEndEdit.AddListener((s) => userNameSet(s));
        age.onEndEdit.AddListener((s) => ageSet(s));
        weight.onEndEdit.AddListener((s) => weightSet(s));
    }

    public void userNameSet(string user)
    {
        Player.name = user;
        EnableCompleteButton();
    }

    public void ageSet(string a)
    {
        int ag = int.Parse(a);
        Player.age = ag;
        EnableCompleteButton();
    }

    public void weightSet(string w)
    {
        int we = int.Parse(w);
        Player.weight = we;
        EnableCompleteButton();
    }

    private void EnableCompleteButton()
    {
        if (Player.name != "" && Player.age != 0 && Player.weight != 0)
        {
            startButton.interactable = true;
        }
    }
}
