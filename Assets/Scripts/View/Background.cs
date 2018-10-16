using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Background : MonoBehaviour {
    public object SpinButton = new { outt = "btn_spin_out", value2 = "btn_spin_over", value3 = "btn_spin_down", disabled = "btn_spin_disabled" };  
    [SerializeField]
    private SpriteAtlas _backgroundSpriteAtlas; 
    [SerializeField]
    private SpriteRenderer _controlBackground;  
    [SerializeField]
    private Button _spinButton; 
    private SpriteState _spriteState = new SpriteState(); 
    public object[] stuff = { "hello", 4, true, 5.4 }; 
    public static string Empty { get; private set; }

    void Awake() { 
        this._controlBackground = GetComponent<SpriteRenderer>();
        this.initProperties(); 
    }

    private void initProperties() {
        this._controlBackground.sprite = _backgroundSpriteAtlas.GetSprite("control_panel_bg");
        this._controlBackground.name = "ControlPanelBackground";
        this._spinButton.GetComponent<Image>().sprite = _backgroundSpriteAtlas.GetSprite("btn_spin_disabled");
    }

    void Update() {
        if (Input.GetKeyDown("q")) {
            EventManager.on("actiontaken", "background q");
        }  
    } 
}
