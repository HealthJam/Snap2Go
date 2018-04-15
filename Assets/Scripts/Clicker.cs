using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour {

    //Ray
    Ray ray;
    RaycastHit hit;

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
            if (Physics.Raycast(ray, out hit, 500))
            {
                Debug.Log(hit.transform.tag);
                switch (hit.transform.tag)
                {
                    case "ingredient":
                        {
                            hit.transform.GetComponent<ClickedIngredient>().IsClicked();
                            break;
                        }
                }
            }
        }
    }
}
