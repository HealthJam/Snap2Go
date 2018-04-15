using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CenterCamera : MonoBehaviour {

	public void OnCenterButtonClicked()
	{
		if (transform.position.x != 0) 
		{
			transform.position = new Vector3 (0, transform.position.y, 0);
		}
	}
}
