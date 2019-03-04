using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Background : MonoBehaviour {
    private Object _controlPanelBg;
    private Object _spinButtonFrame; 
    private SimpleButton _startButton;
    private SimpleSprite _spinButton;
    private SimpleSprite _controlPanel;
 
    Buttons SpinButton = new Buttons { normal = "Sprites/interface/control/btn_spin_out", over = "Sprites/interface/control/btn_spin_over", down = "Sprites/interface/control/btn_spin_down", disabled = "Sprites/interface/control/btn_spin_disabled" };
    Buttons AutoPlayButton = new Buttons { normal = "Sprites/interface/control/btn_spin_out", over = "Sprites/interface/control/btn_spin_over", down = "Sprites/interface/control/btn_spin_down", disabled = "Sprites/interface/control/btn_spin_disabled" };
    Sprites ControlPanel = new Sprites { normal = "Sprites/interface/control/control_panel_bg" };

    public class Buttons {
        public string normal { get; set; }
        public string over { get; set; }
        public string down { get; set; }
        public string disabled { get; set; }
    }

    public class Sprites {
        public string normal { get; set; }
    }

    void Awake() { 
        this.initProperties();
    }

    private void initProperties() {
        this._controlPanel = new SimpleSprite(new Rect(0, 0, 1, 1), ControlPanel.normal, "ControlPanelBG", "Background");
        this._spinButton = new SimpleSprite(new Rect(10, 10, 1, 1), SpinButton.normal, "SpinButton", "Background");
        this._startButton = new SimpleButton(new Rect(50, 50, 250, 250), "Start", "StartButton", "Background");
        this._startButton.OnClick += new SimpleButton.ClickEventHandler(this.buttonClick);
        this._startButton.OnMouseOver += new SimpleButton.OnMouseOverEventHandler(this.buttonClick); 
    }

    private void buttonClick() {
        Debug.Log("kk");
    }

    void Update() {
        if (Input.GetKeyDown("q")) { 
            EventManager.on("backgroundStatus", "q pressed");
        }
    }
}
