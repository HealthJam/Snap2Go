using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayUi : MonoBehaviour {

    GameplayLoop game;

    public void Start()
    {
        game = GameplayLoop.Instance;    
    }

    public void ExpeditionButtonPressed()
    {
        switch(game.state)
        {
            case GameplayLoop.GameState.EXPEDITION_SETUP:
            case GameplayLoop.GameState.EXPEDITION_IN_PROGRESS:
                game.exitExpedition();
                break;
            default:
                game.startExpeditionSetup();
                break;
        }
    }
}
