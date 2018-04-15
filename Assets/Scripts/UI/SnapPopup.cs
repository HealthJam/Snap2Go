using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnapPopup : MonoBehaviour
{
    public Text tName;
    public Text tLocation;

    public GameObject PopupGO;

    public Button yes;

    public Button no;

    private void Awake()
    {
        no.onClick.AddListener(() => Hide());
        yes.onClick.AddListener(() => Hide());
    }

    public void DisplayStore(string storeName, string storeLocation)
    {
        PopupGO.SetActive(true);

        tName.text = storeName;
        tLocation.text = storeLocation;
    }

    public void Hide()
    {
        PopupGO.gameObject.SetActive(false);
    }
}
