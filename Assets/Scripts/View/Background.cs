using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Background : MonoBehaviour {
    private Object _controlPanelBg;
    private Object _spinButton;
    private Sprite2D CreateSprite;

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
        this.CreateSprite = GetComponent<Sprite2D>();
        this.initProperties();
    }

    private void initProperties() {
        this._controlPanelBg = new Sprite2D(0, 0, ControlPanel.normal, "ControlPanelBG", "Background");
        this._spinButton = new Sprite2D(0, 0, SpinButton.normal, "SpinButton", "Background");
    }

    void Update() {
        if (Input.GetKeyDown("q")) {
            EventManager.on("actiontaken", "q pressed");
        }
    }
}
