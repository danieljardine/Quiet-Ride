using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerManager : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ToLookout"))
        {
            SceneManager.LoadScene("Lookout");
        }
    }
}
