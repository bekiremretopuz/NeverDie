using UnityEngine;
public class Game : MonoBehaviour {  
    private Storage _storage;
    private Service _service;
    private EventManager _eventManager;
    private GameObject _mainGame;
    private static Game _instance;

    public void Awake() {
        Game._instance = this;
        this._eventManager = EventManager.instance;
        this._service = new Service();
        this._storage = new Storage();
        MainGame _mainGame = gameObject.AddComponent<MainGame>() as MainGame;
    }

    public Storage storage {
        get { return this._storage; }
    }

    public Service service {
        get { return this._service; }
    }

    public static Game instance {
        get { return Game._instance; }
    }
}