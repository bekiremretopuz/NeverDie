using UnityEngine;
using UnityEngine.UI;

public class SimpleButton {
    private Vector2 _position;
    private Vector2 _size;
    private string _text;
    private string _name;
    private GameObject _button;
    private Button _refButton;
    private SpriteRenderer _renderer;
    private int _zIndex = 0;
    private bool _isEnabled = true;
    private Sprite _texture;
    private string _textureName;
    public delegate void ClickEventHandler();
    public event ClickEventHandler OnClick;

    public SimpleButton(Rect PositionSize, string textureName, string name, string parent) {
        this._position = new Vector2(PositionSize.x, PositionSize.y);
        this._textureName = textureName;
        this._size = new Vector2(PositionSize.width, PositionSize.height); 
        this._name = name;
        this._texture = Resources.Load<Sprite>(textureName) as Sprite;
         
        var container = GameObject.Find(parent.ToString());
        this._button = new GameObject();
        this._button.AddComponent<CanvasRenderer>();
        this._button.AddComponent<RectTransform>(); 
        this._renderer = this._button.AddComponent<SpriteRenderer>();
        this._renderer.sprite = this._texture;
        this._renderer.sortingOrder = _zIndex; 
        this._refButton = this._button.AddComponent<Button>();
        this._refButton.transition = Selectable.Transition.None;
        this._refButton.interactable = this._isEnabled;
        Image mImage = this._button.AddComponent<Image>(); 
        var tempColor = mImage.color;
        tempColor.a = 0f;
        mImage.color = tempColor;
        this._refButton.targetGraphic = mImage; 
        this._button.transform.SetParent(container.transform); 
        this._button.transform.position = new Vector3(_position.x, _position.y, 0);
        var rectTransform = this._refButton.GetComponents<RectTransform>();
        this._refButton.GetComponent<RectTransform>().sizeDelta = this._size;
        this._button.name = this._name;

        this._refButton.onClick.AddListener(() => {  
            this.OnButtonClick(this._refButton); });
    }

    public void OnButtonClick(Button button) { 
        OnClick();
    }

    //TODO: remove click listener
    //void Destroy() {
    //    this._refButton.onClick.RemoveListener(() => this.OnButtonClick(this._refButton);
    //}

    #region Getter And Setter

    public Rect PositionSize {
        get {
            return new Rect(_position.x, _position.y, _size.x, _size.y);
        }
        set {
            _position = new Vector2(value.x, value.y);
            _size = new Vector2(value.width, value.height);
        }
    }

    public Vector2 Position {
        get {
            return _position;
        }
        set {
            _position = value;
        }
    }

    public int ZIndex {
        get {
            return _zIndex;
        }
        set {
            _zIndex = value;
            this._renderer.sortingOrder = value;
        }
    }

    public string SetFrames {
        get {
            return _textureName;
        }
        set {
            _textureName = value;
            this._texture = Resources.Load<Sprite>(_textureName) as Sprite;
            this._renderer.sprite = this._texture;
        }
    }

    public bool IsEnabled {
        get {
            return _isEnabled;
        }
        set {
            _isEnabled = value;
            this._refButton.interactable = value;
        }
    } 

    public string Text {
        get {
            return _text;
        }
        set {
            _text = value;
        }
    }

    public string Name {
        get {
            return _name;
        }
        set {
            _name = value;
        }
    }

    public Vector2 Size {
        get {
            return _size;
        }
        set {
            _size = value;
        }
    }

    public bool IsActive {
        get {
            return this._button.activeInHierarchy;
        }
    }

    public bool ActiveSelf {
        get {
            return this._button.activeSelf;
        }
    }
    #endregion
}