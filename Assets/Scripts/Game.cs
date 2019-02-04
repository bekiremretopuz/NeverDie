using UnityEngine;

public class Game : MonoBehaviour {
    private Storage _storage;
    private AssetLoader _assetLoader;
    private MainGame _mainGame;
    private static Game _instance;

    public Game() {
        Game._instance = this;
        this._storage = new Storage();
        this._assetLoader = new AssetLoader();
        this._mainGame = new MainGame();
    }

    public Storage storage {
        get { return this._storage; }
    }

    public static Game instance {
        get { return Game._instance; }
    }
}
