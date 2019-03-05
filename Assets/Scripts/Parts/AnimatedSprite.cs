using UnityEngine; 
using System.Collections; 

public class AnimatedSprite {
    private float _animationSpeed = 1f;
    private Vector2 _position;
    private Vector2 _size;
    private string _name;
    private GameObject _sprite;
    private SpriteRenderer _renderer;
    private int zIndex = 0;  
    private int _totalFrame = 0;
    private bool _loop = false;
    private Sprite[] _sprites;  

    public AnimatedSprite(Rect PositionSize, string textureName, bool loop, string name, string parent, float animationSpeed) { 
        this._position = new Vector2(PositionSize.x, PositionSize.y);
        this._name = name;
        this._size = new Vector2(PositionSize.width, PositionSize.height);
        this._loop = loop;
        this._animationSpeed = animationSpeed;

        var sprites = Resources.LoadAll<Sprite>(textureName); 
        this._totalFrame = sprites.Length;
        this._sprites = new Sprite[this._totalFrame];
        var container = GameObject.Find(parent.ToString());
        this._sprite = new GameObject();
        this._sprite.AddComponent<CanvasRenderer>();
        this._sprite.AddComponent<RectTransform>();
        this._renderer = this._sprite.AddComponent<SpriteRenderer>();
        this._renderer.sprite = sprites[0]; 
        this._renderer.sortingOrder = zIndex;
        this._sprite.transform.SetParent(container.transform);
        this._sprite.transform.position = new Vector3(_position.x, _position.y, 0);
        this._sprite.name = this._name; 
        for (int i = 0; i < sprites.Length; i++) {
            this._sprites[i] = sprites[i];
        }
    }

    public void monoParser(MonoBehaviour mono) { 
        mono.StartCoroutine(gotoAndPlay()); 
    }

    public IEnumerator gotoAndPlay() { //TODO: goto entered frame.
        Debug.Log(this._totalFrame + AnimationTime);
        for (int i = 0; i < this._totalFrame; i++) { 
            this._renderer.sprite = this._sprites[i]; 
           yield return new WaitForSeconds(AnimationTime);
        }
    }

    public float AnimationTime {
        get {
            return _animationSpeed;
        }
        set {
            _animationSpeed = value;
        }
    }
}
