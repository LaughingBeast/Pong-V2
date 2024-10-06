using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<bool> P1InventoryList = new List<bool>();
    public List<bool> P2InventoryList = new List<bool>();

    public static GameManager instance;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        } else
        {
            Destroy(gameObject);
            return;
        }
    }
}
