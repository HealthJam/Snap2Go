using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mapbox.Unity.Utilities;

public class POI : MonoBehaviour 
{

	private double lon;
	private double lat;
	private bool isDiscovered;
	public Texture discovered;
	public GameObject discovereyMarker;

	public enum POIState
	{
		UNDISCOVERED,
		DISCOVERED, 
		PARENTMODE
	}

	private POIState state;
	private POIState lastState;

	// Use this for initialization
	void Init (double _lat, double _lon) {
		// use this to place object VectorExtensions;
		lat = _lat;
		lon = _lon;

		state = POIState.UNDISCOVERED;

		lastState = state;

		SetNewState (state);
	}
	
	// Update is called once per frame
	void Update () {
		



	}
		
	public void SetNewState (POIState newState)
	{
		// do things to clean last state 
		switch (newState)
		{
		case POIState.UNDISCOVERED:
			{}
			break;
		case POIState.DISCOVERED:
			{
				isDiscovered = true;
				discovereyMarker.GetComponent<MeshRenderer> ().material.mainTexture = discovered;
			}
			break;
		case POIState.PARENTMODE:
			{}
			break;
		}
		state = newState;
	}

	public void SetLocation(double _lat, double _lon)
	{
		
	}


	public void ObjectClicked()
	{
		SetNewState (POIState.DISCOVERED);
	}
}
