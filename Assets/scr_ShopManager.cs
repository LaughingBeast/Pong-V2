using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static scr_ItemSystem;

public class scr_ShopManager : MonoBehaviour
{
    public scr_ItemSystem ItemSystem;

    


    public static int MoneyP1;
    public static int MoneyP2;

    public List<GameObject> ShopPlayer1;
    public List<GameObject> ShopPlayer2;
    public int[] ItemovePoziceP1 = new int[3]; 
    public int[] ItemovePoziceP2 = new int[3];

    public List<GameObject> ShopP1Holder = new List<GameObject>();
    public List<GameObject> ShopP2Holder = new List<GameObject>();

    public TMP_Text ShopPlayer1Text;
    public TMP_Text ShopPlayer2Text;

    GameObject LastShopButtonP1;
    GameObject LastShopButtonP2;
    int CurrentlySelectedP1 = 0;
    int CurrentlySelectedP2 = 0;
    int SelectedMin = 0;
    int SelectedMax = 2;



     


    void Start()
    {
        MoneyP1 = 100;
        MoneyP2 = 100;
        ShopPlayer1Text.text = "Points : " + MoneyP1;
        ShopPlayer2Text.text = "Points : " + MoneyP2;

        LastShopButtonP1 = ShopPlayer1[CurrentlySelectedP1];
        LastShopButtonP2 = ShopPlayer2[CurrentlySelectedP2];
        for (int i = 0; i < ShopPlayer1.Count ; i++) // zjištìní velikosti Listu
        {
           
            ShopPlayer1[i].GetComponent<Image>().color = new Color(1, 1, 1, 0.6f); //Color má rozsah 0 - 1f
            ShopPlayer2[i].GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
        }
        
        ShopPlayer1[CurrentlySelectedP1].GetComponent<Image>().color = new Color(1, 1, 1, 1);
        ShopPlayer2[CurrentlySelectedP1].GetComponent<Image>().color = new Color(1, 1, 1, 1);
    }

    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            
            if (CurrentlySelectedP1 == SelectedMin)
            {
                
                CurrentlySelectedP1 = SelectedMax;
                
                ShopPlayer1[CurrentlySelectedP1].GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LastShopButtonP1.GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
                LastShopButtonP1 = ShopPlayer1[CurrentlySelectedP1];
               
            }
            else 
            {
                CurrentlySelectedP1--;
                ShopPlayer1[CurrentlySelectedP1].GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LastShopButtonP1.GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
                LastShopButtonP1 = ShopPlayer1[CurrentlySelectedP1];
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (CurrentlySelectedP1 == SelectedMax)
            {
                CurrentlySelectedP1 = SelectedMin;
                ShopPlayer1[CurrentlySelectedP1].GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LastShopButtonP1.GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
                LastShopButtonP1 = ShopPlayer1[CurrentlySelectedP1];
            }
            else
            {

                CurrentlySelectedP1++;
                ShopPlayer1[CurrentlySelectedP1].GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LastShopButtonP1.GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
                LastShopButtonP1 = ShopPlayer1[CurrentlySelectedP1];
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {


            var INDEX = ItemovePoziceP1[CurrentlySelectedP1];

            if (ItemSystem.ItemList[INDEX].Cena <= MoneyP1)
            {
                
                MoneyP1 -= ItemSystem.ItemList[INDEX].Cena;
                ShopPlayer1Text.text = "Points : " + MoneyP1;


                GameManager.instance.P1InventoryList[ItemSystem.ItemList[INDEX].IndexovaPozice] = true;
                print(GameManager.instance.P1InventoryList[ItemSystem.ItemList[INDEX].IndexovaPozice]);

                
                var zamichanyList2 = ItemSystem.ItemList.OrderBy(a => UnityEngine.Random.value).ToList().Take(1);

                
                
                foreach (Item item in zamichanyList2)
                {
                    
                    var nahradniItem = Instantiate(item.ItemSlot);
                    nahradniItem.transform.position = ShopP1Holder[CurrentlySelectedP1].transform.position;
                    nahradniItem.transform.parent = ItemSystem.ShopListUIP1;
                    Destroy(ShopP1Holder[CurrentlySelectedP1]);
                    ShopP1Holder[CurrentlySelectedP1] = item.ItemSlot;
                }
                
                
                

                //var InstantníPolevka = Instantiate(zamichanyList2(1));
                //InstantníPolevka.transform.position = ItemSystem.P1List[CurrentlySelectedP1].transform.position;
                // InstantníPolevka.transform.parent = ItemSystem.ShopListUIP1;
                // ItemovePoziceP1[CurrentlySelectedP1] = ItemSystem.ItemList[INDEX].IndexovaPozice;
                //   ItemSystem.UpgradeP1TextList[CurrentlySelectedP1].text = ItemSystem.ItemList[INDEX].Popis;




            } else
            {
                print("Error");

            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            if (CurrentlySelectedP2 == SelectedMin)
            {

                CurrentlySelectedP2 = SelectedMax;

                ShopPlayer2[CurrentlySelectedP2].GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LastShopButtonP2.GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
                LastShopButtonP2 = ShopPlayer2[CurrentlySelectedP2];

            }
            else
            {
                CurrentlySelectedP2--;
                ShopPlayer2[CurrentlySelectedP2].GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LastShopButtonP2.GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
                LastShopButtonP2 = ShopPlayer2[CurrentlySelectedP2];
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (CurrentlySelectedP2 == SelectedMax)
            {
                CurrentlySelectedP2 = SelectedMin;
                ShopPlayer1[CurrentlySelectedP2].GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LastShopButtonP2.GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
                LastShopButtonP2 = ShopPlayer2[CurrentlySelectedP2];
            }
            else
            {

                CurrentlySelectedP2++;
                ShopPlayer2[CurrentlySelectedP2].GetComponent<Image>().color = new Color(1, 1, 1, 1);
                LastShopButtonP2.GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
                LastShopButtonP2 = ShopPlayer2[CurrentlySelectedP2];
            }
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter)) // chybí podmínka pro koupi
        {

            var INDEX = ItemovePoziceP2[CurrentlySelectedP2];

            MoneyP2 -= ItemSystem.ItemList[INDEX].Cena;
            ShopPlayer2Text.text = "Points : " + MoneyP2;

            GameManager.instance.P2InventoryList[ItemSystem.ItemList[INDEX].IndexovaPozice] = true;
            print(GameManager.instance.P2InventoryList[ItemSystem.ItemList[INDEX].IndexovaPozice]);

        }
    }
}
