using UnityEngine; 
using System.Collections.Generic;
using SocketIO;  

public class Service {
    private SocketIOComponent _socket; 

    public Service() {
        GameObject socketIo = GameObject.Find("MainGame");
        this._socket = socketIo.GetComponent<SocketIOComponent>(); 
        this._socket.On("response", this.onServiceResponse);
    }

    public void send(string action, Dictionary<string, string> data) {  
        this._socket.Emit(action.ToString(), new JSONObject(data));
    }

    public void onServiceResponse(SocketIOEvent e) { 
        EventManager.on("response", e.data.ToString());
    }
}
