using UnityEngine;
using System;

public class BackgroundController : MonoBehaviour {
    private GameObject _backgroundInterface;
    private Action<string> _backgroundStatus;

    public BackgroundController() {
        Background _backgroundInterface = gameObject.AddComponent<Background>(); 
        this._backgroundStatus = new Action<string>(onBackgroundStatus);  
        EventManager.AddListener("backgroundStatus", this._backgroundStatus);
    }

    private void onBackgroundStatus(string action) {
        Debug.Log("onBackgroundStatus" + action);
    }
}
