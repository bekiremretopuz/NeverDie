using UnityEngine;
using UnityEngine.UI;

public class SimpleButton {
    private Vector2 _position;
    private Vector2 _size;
    private string _text;
    private string _name;
    private GameObject _button;
    private bool _hover = false;
    private bool _isEnabled = false;
    public delegate void ClickEventHandler();
    public event ClickEventHandler OnClick;
    public delegate void OnMouseOverEventHandler();
    public event OnMouseOverEventHandler OnMouseOver; 

    public SimpleButton(Rect PositionSize, string Content, string name, string parent) {
        var container = GameObject.Find(parent.ToString()); 
        this._position = new Vector2(PositionSize.x, PositionSize.y);
        this._size = new Vector2(PositionSize.width, PositionSize.height);
        this._text = Content;
        this._name = name;

        this._button = new GameObject();
        this._button.AddComponent<CanvasRenderer>();
        this._button.AddComponent<RectTransform>();
        Button button = this._button.AddComponent<Button>();
        Image mImage = this._button.AddComponent<Image>();
        button.targetGraphic = mImage;
        this._button.transform.SetParent(container.transform);
        this._button.transform.position = new Vector3(_position.x, _position.y, 0);
        this._button.name = this._name; 
        button.onClick.AddListener(() => { this.OnButtonClick(button); }); 
    }

    public void OnButtonClick(Button button) { 
        OnClick();
    }

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
