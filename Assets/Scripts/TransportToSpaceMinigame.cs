using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TransportToSpaceMinigame : MonoBehaviour
{
    public string sceneName = "SpaceMinigame";
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("SpaceMinigame"); // Cambia "SpaceMinigame" por el nombre de tu escena
    }
    
    
    

}
