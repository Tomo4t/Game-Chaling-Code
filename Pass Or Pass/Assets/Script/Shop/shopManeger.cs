using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Collections.AllocatorManager;
public class ShopManager : MonoBehaviour , IDataPersistence
{

  
    public Image shopImage;

    public TMP_Text coinsText;

    public AudioSource click;

    private int coins;

    public ShopItemSO[] shopItemsSOArray; 

    public GameObject furnitureContsiner;
    public GameObject electronicsContainer;
    public GameObject officeContainer;
    public GameObject decorationsContainer;
    public GameObject lightingContainer;

    public GameObject itemPanelPrefabe;

    public Button TourilButten;

    public Image furnitureimage;
    public Image electronicimage;
    public Image officeimage;
    public Image decorationsimage;
    public Image lightingimage;


    [HideInInspector]public List<int> numOfOwendItes;

    [HideInInspector] public List<int> numOfSelected;

   

   



    public static ShopManager instance;
    public void Awake()
    {
      
        
        if (instance == null)
            instance = this;
    }

    public void assignNewItemShop( ShopItemSO[] items ) 
    
    {
     foreach ( ShopItemSO itemSO in items) 
        {
            GameObject container;

            if (itemSO.type == Itemestypes.furniture)
                container=furnitureContsiner.gameObject;
           else if (itemSO.type == Itemestypes.electronics)
                container = electronicsContainer.gameObject;
          else  if (itemSO.type == Itemestypes.office)
                container = officeContainer.gameObject;
          else  if (itemSO.type == Itemestypes.lihgting)
                container = lightingContainer.gameObject;
            else
                container =decorationsContainer.gameObject;



            GameObject panel = Instantiate(itemPanelPrefabe);
            panel .transform.SetParent(container.transform, false);

            ShopTemplate template=panel.GetComponent<ShopTemplate>();
            template.titleText.text = itemSO.name;
            template.priceText.text=itemSO.price.ToString();
            template.selectToggle.gameObject.SetActive(false);
            if (itemSO.price >coins)
            {
                template.purchesButton.interactable = false;
            }
            else
            {
                template.purchesButton.onClick.AddListener(() => buyItems(itemSO.ID, template,itemSO.price));
                

            }
            template.selectToggle.onValueChanged.AddListener((isOn) => SelectItem(isOn, itemSO.ID));
            itemSO.template = template;



        }
    
    
    }
    public void loadPanels()
    {
        foreach(ShopItemSO item in shopItemsSOArray)
        {
            if(numOfOwendItes.Contains(item.ID)) 
            {
             item.template.purchesButton.gameObject.SetActive(false);
             item.template.priceText.gameObject.SetActive(false);
             item.template.selectToggle.gameObject.SetActive(true);
             item.template.selectToggle.isOn =(numOfSelected.Contains(item.ID));
            }
            
        }

    }


 
    void Start()
    {
        DataPersistenceManager.Instance.LoadGame();
        coinsText.text = coins.ToString();
        ShowFurniturePanels();
        assignNewItemShop(shopItemsSOArray);
        loadPanels();
        
    
    }

    public void buyItems(int ID,ShopTemplate shopTemplate,int price) 
    {
        click.Play();
            numOfOwendItes.Add(ID);
            coins -= price;
            coinsText.text = coins.ToString();
            shopTemplate.selectToggle.gameObject.SetActive(true);
            shopTemplate.purchesButton.gameObject.SetActive(false);
            shopTemplate.priceText.gameObject.SetActive(false);
            DataPersistenceManager.Instance.SaveGame();

        checkPurchable();
    }
    public void SelectItem(bool isOn, int ID) 
    {
        click.Play();
        if (isOn == true)
        {
            numOfSelected.Add(ID);
        } else 
        {
            numOfSelected.Remove(ID); 
        }
        DataPersistenceManager.Instance.SaveGame();
    }
    public void checkPurchable()
    
    {
        foreach (ShopItemSO  itemSo in shopItemsSOArray)
        {
            if (itemSo.price > coins)
            {
                itemSo.template.purchesButton.interactable = false;
            }
            
        }
    }

    void ActivatePanels(Image[] images)
    {
        furnitureimage.gameObject.SetActive(false);
        electronicimage.gameObject.SetActive(false);
        officeimage.gameObject.SetActive(false);
        lightingimage.gameObject.SetActive(false);
        decorationsimage.gameObject.SetActive(false);

        foreach (var image in images)
        {
            image.gameObject.SetActive(true);
        }
    }

    public void ShowFurniturePanels()
    {
        ActivatePanels(new Image[] { furnitureimage });
    }

    public void ShowElectronicsPanels()
    {
        ActivatePanels(new Image[] { electronicimage });
    }

    public void ShowOfficePanels()
    {
        ActivatePanels(new Image[] { officeimage });
    }


    public void ShowDecorationPanels()
    {
        ActivatePanels(new Image[] { decorationsimage });
    }


    public void ShowLightingPanels()
    {
        ActivatePanels(new Image[] { lightingimage });
    }

    public void exitButton()
    {
        shopImage.gameObject.SetActive(false);
    }
    public void OpeanButton()
    {
        shopImage.gameObject.SetActive(true);
    }

    public void LoadData(GameData data)
    {
        Debug.Log("LodingData");
        coins = data.Money;

        numOfOwendItes = data.ShopsItem;

        numOfSelected = data.numOfSelected;

        if (data.PlayedTou)
        {
            TourilButten.gameObject.SetActive(true);
        }
        else
        {
            TourilButten.gameObject.SetActive(false);
        }
    }

    public void SaveData(ref GameData data)
    {
       data.Money = coins;

        data.ShopsItem = numOfOwendItes;

        data.numOfSelected = numOfSelected;
    }
}