using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InterfaceAction : MonoBehaviour {

    public interface IPlayerData {
        string username { get; set; }
        string Password { get; }
        bool FirstEntry { get; set; }
    }
}

