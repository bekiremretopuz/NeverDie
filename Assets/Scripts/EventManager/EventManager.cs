using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class EventManager : MonoBehaviour {

    private Dictionary<string, Action<string>> eventDictionary;

    private static EventManager eventManager;

    public static EventManager instance {
        get {
            if (!eventManager) {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManager) {
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else {
                    eventManager.Init();
                }
            }
            return eventManager;
        }
    }

    void Init() {
        if (eventDictionary == null) {
            eventDictionary = new Dictionary<string, Action<string>>();
        }
    }

    public static void AddListener(string eventName, Action<string> listener) {
        Action<string> thisEvent;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent += listener;

            instance.eventDictionary[eventName] = thisEvent;
        }
        else {
            thisEvent += listener;
            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void RemoveListener(string eventName, Action<string> listener) {
        if (eventManager == null) return;
        Action<string> thisEvent;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent -= listener;

            instance.eventDictionary[eventName] = thisEvent;
        }
    }

    public static void on(string eventName, params string[] eventParam) {
        Action<string> thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent)) {
            for (int i = 0; i < eventParam.Length; i++) {
                thisEvent.Invoke(eventParam[i]);
            }
        }
    }
}