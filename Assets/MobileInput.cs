using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour {



	void Update() {
		if (Input.touchCount > 0) {
			Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit raycastHit;
			if (Physics.Raycast(raycast, out raycastHit))
			{
				Debug.Log("Something Hit");
				if (raycastHit.collider.name == "POI") {
					raycastHit.transform.gameObject.GetComponent<POI> ().ObjectClicked ();
				}
			}
		}
	}
}