using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Sprite2D : MonoBehaviour {
    private SpriteRenderer _spriteRenderer;

    public Sprite2D(int positionX, int positionY, string textureName, string name, string parentName) {
        var parent = GameObject.FindWithTag(parentName);
        var texture = Resources.Load<Texture2D>(textureName) as Texture2D;
        var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100);
        var createSprite = new GameObject();
        createSprite.AddComponent<SpriteRenderer>();
        createSprite.name = name;
        //createSprite.tag =  name;
        this._spriteRenderer = createSprite.GetComponent<SpriteRenderer>();
        this._spriteRenderer.transform.parent = parent.transform;
        this._spriteRenderer.sprite = sprite;
        this._spriteRenderer.transform.position = new Vector2(positionX, positionY);
    }

    public void setPosition(int positionX, int positionY) {
        this._spriteRenderer.transform.position = new Vector2(positionX, positionY);
    }

    public SpriteRenderer spriteRenderer {
        get {
            return this._spriteRenderer;
        }
        set {
            this._spriteRenderer = value;
        }
    }
}
