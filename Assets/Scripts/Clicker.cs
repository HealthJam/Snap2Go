using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour {

    //Ray
    Ray ray;
    RaycastHit hit;

    public SnapPopup popup;

    void selectedAsteroidIndicator(Transform TF)
    {
        GameObject GO = GameObject.FindGameObjectWithTag("selectionParticle");
        Destroy(GO);
        Instantiate(Resources.Load("AsteroidSelectedParticle"), TF.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 5000))
            {
                Debug.Log(hit.transform.tag);
                switch (hit.transform.tag)
                {
                    case "ingredient":
                        {
                            hit.transform.GetComponent<ClickedIngredient>().IsClicked();
                            break;
                        }
                    case "store":
                        {
                            ClickedStore store = hit.transform.GetComponent<ClickedStore>();
                            popup.DisplayStore(store.storeName, store.storeLocation);
                            break;
                        }
                }
            }
        }
    }
}
