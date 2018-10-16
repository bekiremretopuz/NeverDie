using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
    private Background _backgroundInterface;

    public BackgroundController() {
        this._backgroundInterface = new Background();
    } 
}
