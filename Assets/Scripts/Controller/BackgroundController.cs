using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
    Background _backgroundInterface = new Background();

    public BackgroundController()  {
        this.initProperties();
    }

    public void initProperties () {
        this._backgroundInterface.initProperties();
	}
}
