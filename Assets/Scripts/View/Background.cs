
using UnityEngine; 

public class Background : MonoBehaviour {
    private Object _controlPanelBg;
    private Object _spinButtonFrame;
    private SimpleButton _startButton;
    private SimpleSprite _spinButton;
    private SimpleSprite _controlPanel;
    private AnimatedSprite _symbolHelio;

    Buttons SpinButton = new Buttons { normal = "Sprites/interface/control/btn_spin_out", over = "Sprites/interface/control/btn_spin_over", down = "Sprites/interface/control/btn_spin_down", disabled = "Sprites/interface/control/btn_spin_disabled" };
    Buttons AutoPlayButton = new Buttons { normal = "Sprites/interface/control/btn_spin_out", over = "Sprites/interface/control/btn_spin_over", down = "Sprites/interface/control/btn_spin_down", disabled = "Sprites/interface/control/btn_spin_disabled" };
    Sprites ControlPanel = new Sprites { normal = "Sprites/interface/control/control_panel_bg" };
    Sprites SymbolHelio = new Sprites { normal = "Sprites/symbol/Helio_2" };

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
        this._controlPanel.ZIndex = 0; //Default ZIndex = 0;
        this._startButton = new SimpleButton(new Rect(0, 0, 1, 1), SpinButton.normal, "StartButton", "Background");
        this._startButton.OnClick += new SimpleButton.ClickEventHandler(this.clickStartButton); 
        this._startButton.ZIndex = 1;
        this._startButton.IsEnabled = true; //Default Enable true;
        this._startButton.SetFrames = SpinButton.normal;
        this._symbolHelio = new AnimatedSprite(new Rect(1, 2, 1, 1), SymbolHelio.normal, true, "HelioSymbol", "Background", 1f);
        this._symbolHelio.gotoAndPlay(); 
    }

    public void clickStartButton() {
        EventManager.on("backgroundStatus", "start"); 
    } 
}