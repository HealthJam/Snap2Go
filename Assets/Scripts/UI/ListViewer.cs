using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListViewer : MonoBehaviour
{
    public Transform contentPanel;
    public Text listName;

    public Image icon;

    public ProfileUI profileUI;

    // Use this for initialization
    void Awake()
    {
        //RemoveButtons();
    }

    private void RemoveButtons()
    {
        int childCount = contentPanel.childCount;
        while (childCount > 0)
        {
            GameObject toRemove = contentPanel.GetChild(childCount - 1).gameObject;
            Destroy(toRemove);
            childCount--;
        }
    }

    public void AddButtons(List<GameObject> objs)
    {
        for (int i = 0; i < objs.Count; i++)
        {
            objs[i].transform.SetParent(contentPanel);
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        RemoveButtons();
        gameObject.SetActive(false);
        profileUI.Show();
    }
}
