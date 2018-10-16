using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class MainGame : MonoBehaviour {

    private UnityAction<string> actiontaken; //Listen to  BackgroundController
    private UnityAction<string> animationstatus; // Listen to AnimationController 

    public MainGame() { 
    }

    private void Awake() {
        actiontaken = new UnityAction<string>(onController);
        animationstatus = new UnityAction<string>(onAnimationStatus);
    }

    private void OnEnable() {
        EventManager.AddListener("actiontaken", actiontaken);
        EventManager.AddListener("animationstatus", animationstatus);
    }

    private void OnDisable() {
        EventManager.RemoveListener("actiontaken", actiontaken);
        EventManager.RemoveListener("animationstatus", animationstatus);
    }

    void onController(string value) {
        Debug.Log("Controller: " + value);
    }

    void onAnimationStatus(string value) { 
        Debug.Log("Animation: " + value);
    } 
}
