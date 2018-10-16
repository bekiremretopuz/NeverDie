using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using UnityEngine.Events;

public class Animation : MonoBehaviour { 

    void Update() {
        if (Input.GetKeyDown("a")) {
            EventManager.on("animationstatus", "animation a");
        }
    }
}
