using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour {

    public Camera cam;
    private Text collectText;

	// Use this for initialization
	void Awake () {
        collectText = GameObject.Find("UI/Messages/Collect").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        CheckIteraction();
	}

    void CheckIteraction()
    {
        collectText.text = "";

        RaycastHit hit;

        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 7f)){
            print(hit.transform.name);
            if (hit.transform.tag == "Collectable")
            {
                collectText.text = "Press E to collect";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.transform.GetComponent<collectable>().collect();
                }
            }
        }
    }
}
