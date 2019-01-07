using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour {

    public bool collides = false;

    private void OnCollisionEnter(Collision collision)
    {
        collides = true;
        print("collidiert " + this.gameObject);
    }
}
