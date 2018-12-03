using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    public static bool pause = false;
    public static bool buildMode = false;
    public static float distance = 15;
    public GameObject test;
    public GameObject camera;
    private GameObject buildObject;
    private static float speed;
    private static float framedistance = 1;
    private static Quaternion buildObjectRotation;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        buildObjectRotation = test.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            pause = !pause;
            Cursor.visible = !Cursor.visible;
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        if (Input.GetKeyDown("b"))
        {
            buildObject = null;
            buildMode = !buildMode;

        }
        if (buildMode)
        {
            building();
        }
    }

    void building()
    {
        Camera cam = GetComponentInChildren<Camera>();
        Vector3 target = cam.transform.position + cam.transform.rotation * Vector3.forward * distance;
        target = new Vector3(round(target.x/framedistance)*framedistance, round(target.y/ framedistance) * framedistance, round(target.z/ framedistance) * framedistance);


        if (buildObject == null && Input.GetKeyDown("n"))
        {
            buildObject = (GameObject)Instantiate(test);
            buildObject.transform.position = target;
            buildObject.transform.rotation = buildObjectRotation;
        }

        if (buildObject != null) { 
            speed = Vector3.Distance(target, buildObject.transform.position) * 15;
            buildObject.transform.position = Vector3.MoveTowards(buildObject.transform.position, target, speed * Time.deltaTime);
         }

        //Raycast
        if (buildObject == null)
        {
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(camera.transform.position, camera.transform.rotation * Vector3.forward, out hit, 100))
            {
                if (hit.collider.gameObject.isStatic == false)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        buildObject = hit.collider.gameObject;
                    }
                }

            }

        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                buildObjectRotation = buildObject.transform.rotation;
                buildObject = null;
            }
        }


        if (Input.GetKey("q"))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                buildObject.transform.Rotate(Vector3.forward * -6);
            }
            else
            {
                buildObject.transform.Rotate(Vector3.forward * -1);
            }
        }
        if (Input.GetKey("e"))
        {
            if(Input.GetKey(KeyCode.LeftShift)){
                buildObject.transform.Rotate(Vector3.forward * 6);
            }else{
                buildObject.transform.Rotate(Vector3.forward * 1);
            }
           
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            distance += Input.GetAxis("Mouse ScrollWheel")*framedistance;
        }
    }

    float round(float n){
        return Mathf.Round(n);
    }
}

