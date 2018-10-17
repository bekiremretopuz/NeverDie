using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Background : MonoBehaviour { 
    [SerializeField]
    private SpriteAtlas _backgroundSpriteAtlas; 
    [SerializeField]
    private SpriteRenderer _controlBackground;  
    [SerializeField]
    private Button _spinButton; 
    private SpriteState _spriteState = new SpriteState();

    public class Buttons {
        public string normal { get; set; }
        public string over { get; set; }
        public string down { get; set; }
        public string disabled { get; set; }
    }

    Buttons SpinButton = new Buttons { normal = "btn_spin_out", over = "btn_spin_over", down = "btn_spin_down", disabled = "btn_spin_disabled" };
    Buttons AutoPlayButton = new Buttons { normal = "btn_spin_out", over = "btn_spin_over", down = "btn_spin_down", disabled = "btn_spin_disabled" };

    void Awake() { 
        this._controlBackground = GetComponent<SpriteRenderer>();
        this.initProperties(); 
    }

    private void initProperties() {
        this._controlBackground.sprite = _backgroundSpriteAtlas.GetSprite("control_panel_bg");
        this._controlBackground.name = "ControlPanelBackground";
        this._spinButton.GetComponent<Image>().sprite = _backgroundSpriteAtlas.GetSprite(SpinButton.normal);
    }

    void Update() {
        if (Input.GetKeyDown("q")) {
            EventManager.on("actiontaken", "q pressed");
        }  
    } 
}
