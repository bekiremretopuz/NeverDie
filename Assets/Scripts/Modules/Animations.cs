using UnityEngine;
using DG.Tweening;

public class Animations : MonoBehaviour {
    private Animator _stormAnimation;
    private Animator _weaponAnimation;
    private Transform _stormTransform;
    private Transform _weaponTransform; 
    void Awake() {  
        this._stormAnimation = GameObject.FindWithTag("Storm").GetComponent<Animator>();
        this._weaponAnimation = GameObject.FindWithTag("Weapon").GetComponent<Animator>();
        this._stormTransform = GameObject.FindWithTag("Storm").GetComponent<Transform>();
        this._weaponTransform = GameObject.FindWithTag("Weapon").GetComponent<Transform>(); 
        //this.exampleAnimation();
    }

    private void exampleAnimation() {
        this._stormTransform.DOMove(new Vector3(4, 4, 0), 1).SetLoops(-1, LoopType.Yoyo);
        this._weaponTransform.DOMove(new Vector3(4, 4, 0), 1).SetLoops(-1, LoopType.Yoyo); 
    }

    void Update() {
        if (Input.GetKeyDown("a")) {
            this._stormAnimation.SetTrigger("StormStart");
            this._weaponAnimation.SetTrigger("WeaponStart"); 
            EventManager.on("animationStatus", "AnimationStart");
        }
        else if (Input.GetKeyUp("a")) { 
            this._stormAnimation.SetTrigger("StormStop");
            this._weaponAnimation.SetTrigger("WeaponStop"); 
            EventManager.on("animationStatus", "AnimationStop");
        }
    }
}
