using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSaver : MonoBehaviour
{
    public int ID;

    private void Awake()
    {
        if (PlayerPrefs.HasKey ("Orb" + ID) && PlayerPrefs.GetInt ("Orb" + ID) == 1)
        {
            LoadOrb();

        }
         
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("Orb" + ID, 1);
    }

    public void LoadOrb()
    {
        GameManager.gameManager.CoinCollected(1);
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
