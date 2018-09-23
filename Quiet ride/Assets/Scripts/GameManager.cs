using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public float DoorDistance = 1.5f, fadeSpeed;

    public Image introScreen;
    vp_Input control;
    private RaycastHit hit;

    // Use this for initialization
    void Start () {
       control = gameObject.GetComponent<vp_Input>();
        

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("e"))
        {
            CheckRayCast();
        }
    }
    private void CheckRayCast()
    {
        // Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        // RaycastHit data;
        // if (Physics.Raycast(ray, out data, DoorDistance))
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, DoorDistance))
            if (hit.transform.tag == "Door")
            {
                StartCoroutine(RoomSceneTransition());
            }
        if (Physics.Raycast(ray, out hit, 1000f))
        {
            if (hit.transform.tag == "Drink")
            {
                StartCoroutine(DriveInTransition());
            }
        }
        if (Physics.Raycast(ray, out hit, 1000f))
        {
            if (hit.transform.tag == "Sign")
            {
                Application.Quit();
                Debug.Log("done");
            }
        }

    }
    IEnumerator RoomSceneTransition()
    {
        while (true)
        {
            Fade();
            yield return new WaitForSeconds(0.5f);
            Debug.Log("Room door closing");
            yield return new WaitForSeconds(0.5f);
            Debug.Log("Car door opening");
            yield return new WaitForSeconds(0.5f);
            Debug.Log("Engine start");
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene("DriveThrough");
            UnFade();
            yield break;
        }
    }
    IEnumerator DriveInTransition()
    {
        while (true)
        {
            Fade();
            yield return new WaitForSeconds(0.5f);
            Debug.Log("Drink sip");
            yield return new WaitForSeconds(0.5f);
            Debug.Log("Car speeds up");
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene("PreLookout");
            UnFade();
            yield break;
        }
    }
    IEnumerator LookoutTransition()
    {
        while (true)
        {
            Fade();
            yield return new WaitForSeconds(0.5f);
            Debug.Log("Car stop");
            yield return new WaitForSeconds(0.5f);
            Debug.Log("Footsteps");
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene("Lookout");
            UnFade();
            yield break;
        }
    }
    public void Fade()
    {
        introScreen.CrossFadeAlpha(255f, 1f, false);
    }
    public void UnFade()
    {
        introScreen.CrossFadeAlpha(1f, 1f, false);
    }
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ToLookout"))
        {
            LookoutTransition();
        }
    }
}
