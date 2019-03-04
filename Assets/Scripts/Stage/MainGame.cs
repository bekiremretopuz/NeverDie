using UnityEngine;
using System;
using System.Collections.Generic;

public class MainGame: MonoBehaviour { 
    private GameObject _dataController;
    private Action<string> _storageUpdate;
    private Action<string> _animationStatus;

    private void Awake() {
        DataController _dataController = gameObject.AddComponent<DataController>() as DataController;
        this.initEvents();
    } 

    public void initEvents() {
        this._storageUpdate = new Action<string>(onStorageUpdate);
        this._animationStatus = new Action<string>(onAnimationStatus);
        EventManager.AddListener("animationStatus", this._animationStatus);
        EventManager.AddListener("storageUpdate", this._storageUpdate); 
    }

    private void OnDisable() {
        EventManager.RemoveListener("storageUpdate", this._storageUpdate);
        EventManager.RemoveListener("animationStatus", this._animationStatus);
    }

    void onStorageUpdate(string action) {
        Debug.Log("Storage Update" + action);
    }

    void onAnimationStatus(string action) {
        Debug.Log("Animation Update" + action);
    } 
}