using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
      public static GameManager gameManager;
      public int Orbs = 0, Coins = 0;
      public TextMeshProUGUI CoinsText, OrbsText;

      public List<Image> items;

      public Image[] Items;

     


  
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
         CoinsText.text = "Coins: " + Coins;
         OrbsText.text = "Orbs:" + Orbs;
    }
    public void OrbCollected()
    {
        Orbs++;
        OrbsText.text = "Orbs:" + Orbs;
    }
     public void CoinCollected(int i)
    {
        Coins+= i;
        CoinsText.text = "Coins: " + Coins;

    }

    public void ItemCollected(Sprite sprite, int i)
    {
        items[i].sprite = sprite;
    }

    
    public void GetItem(Sprite sprite, int i)
    {
        items[i].sprite = sprite;
    }

   
    
 


   
}

public interface ICollectable
        {
            public void OnCollected();
        }
