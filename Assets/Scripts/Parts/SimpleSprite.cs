using UnityEngine;
using UnityEngine.UI;

public class SimpleSprite {  
    private Vector2 _position;
    private Vector2 _size; 
    private string _name;
    private GameObject _sprite;
    private SpriteRenderer _renderer;
    private int zIndex = 0;

    public SimpleSprite(Rect PositionSize, string textureName, string name, string parent) { 
        var texture = Resources.Load<Sprite>(textureName) as Sprite;
        this._position = new Vector2(PositionSize.x, PositionSize.y);
        this._size = new Vector2(PositionSize.width, PositionSize.height); 
        this._name = name;

        var container = GameObject.Find(parent.ToString());
        this._sprite = new GameObject();
        this._sprite.AddComponent<CanvasRenderer>();
        this._sprite.AddComponent<RectTransform>();
        this._renderer = this._sprite.AddComponent<SpriteRenderer>();
        this._renderer.sprite = texture;
        this._renderer.sortingOrder = zIndex; 
        this._sprite.transform.SetParent(container.transform);
        this._sprite.transform.position = new Vector3(_position.x, _position.y, 0);
        this._sprite.name = this._name; 
    } 

    public void setPosition(int positionX, int positionY) {
        this._sprite.transform.position = new Vector3(positionX, positionY, 0);
    } 

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
            return zIndex;
        }
        set {
            zIndex = value;
            this._renderer.sortingOrder = value;
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
}
