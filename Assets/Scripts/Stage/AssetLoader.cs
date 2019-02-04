using UnityEngine;
using UnityEngine.U2D;
public class AssetLoader : MonoBehaviour {
    public AssetLoader() {
        Game.instance.storage.insert("CurrentMode", "IdleState");
        Game.instance.storage.insert("PlayerName", "Emre"); 
    }
}