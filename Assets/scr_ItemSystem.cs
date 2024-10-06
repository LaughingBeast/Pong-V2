
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class scr_ItemSystem : MonoBehaviour
{

    public scr_ShopManager ShopManager;

    public List<GameObject> ObjList;
    public List<Item> ItemList = new List<Item>();
    public List<TMP_Text> UpgradeP1TextList;
    public List<TMP_Text> UpgradeP2TextList;
    public List<int> IndexoviListP1 = new List<int>();
    public List<int> IndexoviListP2 = new List<int>();


    public Transform ShopListUIP1;
    public Transform ShopListUIP2;

   

    public GameObject Player1ItemSlot1;
    public GameObject Player1ItemSlot2;
    public GameObject Player1ItemSlot3;

    public GameObject Player2ItemSlot1;
    public GameObject Player2ItemSlot2;
    public GameObject Player2ItemSlot3;

    public GameObject[] P1List;
    public GameObject[] P2List;



    public int P1ShopPozice = 0;
    public int P2ShopPozice = 0;    

    void Start()
    {
        P1List = new GameObject[] { Player1ItemSlot1, Player1ItemSlot2, Player1ItemSlot3 };
        P2List = new GameObject[] { Player2ItemSlot1, Player2ItemSlot2, Player2ItemSlot3 };


        for (int i = 0; i < ObjList.Count; i++)
        {

            ItemList.Add(new Item(i, ObjList[i], false, "",0));
            GameManager.instance.P1InventoryList.Add(false);
            GameManager.instance.P2InventoryList.Add(false);


        }
        ItemList[0].Cena = 5;
        ItemList[0].Popis = "Vytvoøí kulièku èistì pro nepøítele. Když dosáhne svého cíle nepøitel dostane stun na 2 s. Cena : " + ItemList[0].Cena;
        ItemList[1].Cena = 5;
        ItemList[1].Popis = "Pøi zmáèknutí klávesy \"E\" pomíchá na krátkou dobu nepøíteli ovládání. Cena : " + ItemList[1].Cena;
        ItemList[2].Cena = 5;
       ItemList[2].Popis = "Pøidá možnost vystøelit až 3 kulièky navíc na nepøítele. Cena : " + ItemList[2].Cena;
        ShopSpawn();




    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void ShopSpawn()
    {
        var zamichanyList = ItemList.OrderBy(a => UnityEngine.Random.value).ToList().Take(3); // dohledat
        int i = 0;
        foreach (Item item in zamichanyList)
        { 
            var InstantníPolevka = Instantiate(item.ItemSlot);
            ShopManager.ShopP1Holder.Add(InstantníPolevka);
            InstantníPolevka.transform.position =  P1List[P1ShopPozice].transform.position;
            InstantníPolevka.transform.parent = ShopListUIP1;
            ShopManager.ItemovePoziceP1[i] = item.IndexovaPozice;
            UpgradeP1TextList[i].text = item.Popis;
            IndexoviListP1.Add(item.IndexovaPozice);
            P1ShopPozice++;
            
            
            i++;
            
        }

        zamichanyList = ItemList.OrderBy(a => UnityEngine.Random.value).ToList().Take(3); // dohledat
        i = 0;
        foreach (Item item in zamichanyList)
        {
            var InstantníPolevka = Instantiate(item.ItemSlot);
            InstantníPolevka.transform.position = P2List[P2ShopPozice].transform.position;
            InstantníPolevka.transform.parent = ShopListUIP2;
            ShopManager.ItemovePoziceP2[i] = item.IndexovaPozice;
            UpgradeP2TextList[i].text = item.Popis;
            P2ShopPozice++;
            IndexoviListP2.Add(item.IndexovaPozice);
            print("Index ITEMU : " + i + " " + IndexoviListP2[i]);

            i++;
        }
    }





    public class Item
    {
        public int IndexovaPozice {  get; set; }
        public GameObject ItemSlot {  get; set; }
        public bool Active { get; set; }

        public string Popis {  get; set; }

        public int Cena { get; set; }


        //List<> ItemList { get; set; }


        public Item (int indexovapozice,GameObject itemSlot, bool active,string popis,int cena)
        {
            
            IndexovaPozice = indexovapozice;
            ItemSlot = itemSlot;
            Active = active;
            Popis = popis;
            Cena = cena;    
            
           
            
        }

    }
}
