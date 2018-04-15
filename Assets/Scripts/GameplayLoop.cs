using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayLoop : MonoBehaviour {

    public enum GameState { LOADING, EXPLORE, EXPEDITION_SETUP, EXPEDITION_IN_PROGRESS, EXPEDITION_END };
    public GameState state = GameState.LOADING;

    private static GameplayLoop instance;
    public static GameplayLoop Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Debug.LogWarning("Duplicate GameplayLoop instance");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        startExploring();
    }

    public void startExploring()
    {
        // MapView that the player can move around
        // display start expedition button
        // Undiscovered locations can't be discovered in this mode.
        state = GameState.EXPLORE;
        Debug.Log("Entering explore state");
    }

    public void startExpeditionSetup()
    {
        //Start expedition button is clicked, show the map with store locations.
        //Todo zoom up, populate map with store locations

        //When a store map marker is clicked, they can confirm that is the destination store
        //Nagivation route is then shown
        Debug.Log("Entering expedition setup state");
    }

    public void startExpeditionInProgress()
    {
        //Spawn manager spawns ingredients at a higher rate.

        Debug.Log("Entering expedition in progress state");
    }

    public void exitExpedition()
    {
        //  clean up and hide nagivation route
        //  transition back to EXPLORE state

        Debug.Log("Exiting expedition state");
    }
    public void finishExpedition()
    {
        //  award xp or do whatever
        //  transition back to EXPLORE state
        Debug.Log("Finishing expedition state");
    }
}
