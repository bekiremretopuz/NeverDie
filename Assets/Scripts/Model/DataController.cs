using UnityEngine;
using System;
using SimpleJSON;

public class DataController : MonoBehaviour {
    private Action<string> _serviceResponse; //Listen To Service

    private void OnEnable() {
        this._serviceResponse = new Action<string>(onServiceResponse);
        EventManager.AddListener("response", this._serviceResponse);
    }

    private void OnDisable() {
        EventManager.RemoveListener("response", this._serviceResponse);
    } 

    private void onServiceResponse(string action) {
        Debug.Log("Service Response" + action);
    }
}
