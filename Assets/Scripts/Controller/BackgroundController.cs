using UnityEngine;
using System;
using System.Collections.Generic;
public class BackgroundController : MonoBehaviour { 
    private Action<string> _backgroundStatus;

    public BackgroundController() {
        this._backgroundStatus = new Action<string>(onBackgroundStatus);  
        EventManager.AddListener("backgroundStatus", this._backgroundStatus);
    }

    private void onBackgroundStatus(string action) {
        Debug.Log("onBackgroundStatus" + action);
        Game.instance.service.send("login", new Dictionary<string, string>() { { "name", "emre" } });

    }
}
