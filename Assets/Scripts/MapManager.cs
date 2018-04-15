using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Examples;
public class MapManager : MonoBehaviour 
{
	public static MapManager instance;

	public enum GameMode
	{
		EXPLORER,
		PARENT, 
		EXPO
	};

	public GameObject locationProvider;


	private GameMode mode;


	private bool isDiscoverable = true;
	// Use this for initialization
	void Start () 
	{
		instance = this;
		SetNewMode (GameMode.EXPLORER);
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		
	}





	public void SetNewMode (GameMode _mode)
	{
		mode = _mode;

		if (mode == GameMode.EXPLORER) {

			isDiscoverable = true;


		}
	}
}
