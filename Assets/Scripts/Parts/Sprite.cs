using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite2D : MonoBehaviour {
    public Sprite2D(int posX, int posY, Texture texture)
    { 
        Instantiate(texture, new Vector2(posX, posY), Quaternion.identity); 

    }
}
