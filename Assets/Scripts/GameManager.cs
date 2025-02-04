using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public int Orbs = 0, Coins = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if(GameManager.gameManager != null && GameManager.gameManager != this)
        {
            Destroy(gameObject);
        }
        else
        {
            GameManager.gameManager =  this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void OrbCollected()
    {
        Orbs++;
    }
     public void CoinCollected()
    {
        Coins++;
    }

   
    
 


   
}

public interface ICollectable
        {
            public void OnCollected();
        }
