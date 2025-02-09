using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSaver : MonoBehaviour
{
    public int ID;

    private void Awake();
    {
        if (PlayerPrefs.HasKey("Coin" + ID) && PlayerPrefs.GetInt("Coin" + ID) == 1)
        {
            LoadCoin();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("Coin" + ID, 1);
    }

    public void LoadCoin()
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
