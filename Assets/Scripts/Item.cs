using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, ICollectable
{
    public int ID;
    public Sprite Sprite;
    // Start is called before the first frame update

    public void OnCollected()
    {
        GameManager.gameManager.ItemCollected(Sprite, ID);
        Destroy(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
