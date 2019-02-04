using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

[System.Serializable]
public class ThisEvent : UnityEvent<string> { }

public class EventManager : MonoBehaviour {
    private Dictionary<string, ThisEvent> eventDictionary;

    private static EventManager eventManger;

    public static EventManager Instance {
        get {
            if (!eventManger) {
                eventManger = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManger) {
                    Debug.Log("There needs to be one active EventManager script on a gameobject in your scene.");
                }
                else {
                    eventManger.Init();

                }
            }
            return eventManger;
        }
    }

    void Init() {
        if (eventDictionary == null) {
            eventDictionary = new Dictionary<string, ThisEvent>();
        }
    }

    public static void AddListener(string eventName, UnityAction<string> listener) {
        ThisEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.AddListener(listener);
        }
        else {
            thisEvent = new ThisEvent();
            thisEvent.AddListener(listener);
            Instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void RemoveListener(string eventName, UnityAction<string> listener) {
        if (eventManger == null) return;
        ThisEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void on(string eventName, string json) {
        ThisEvent thisEvent = null;
        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.Invoke(json);
        }
    }
}