using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSpawn : NetworkBehaviour {

    public Behaviour[] ObjectsToDisable;

	void Start () {
        if(!isLocalPlayer) {
            foreach(Behaviour b in ObjectsToDisable){
                b.enabled = false;
            }
        }else{
            Camera.main.gameObject.SetActive(false);
        }
	}
}
