﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public float DoorDistance = 1.5f, fadeSpeed;

    public Image introScreen;

    // Use this for initialization
    void Start () {
		
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
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit data;
        if (Physics.Raycast(ray, out data, DoorDistance))
        {
            StartCoroutine(RoomSceneTransition());

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
            SceneManager.LoadScene("DriveIn");
            yield break;
        }
    }
    public void Fade()
    {
        introScreen.CrossFadeAlpha(255f, 1f, false);
    }

}