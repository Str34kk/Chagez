using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour {

    public Transform skinPanel;
    public Text money;
    public Text starsValue;
    public Text starsCost;
    public GameObject[] SkinCostImg = new GameObject[20];
    public GameObject[] SkinImg = new GameObject[20];

    int[] cost = new int[] {0, 10,10,30,30,50,50,100,100,150,150,200,200,300,300,400,400,500,500,600};
    int[] starCost = new int[] { 0, 0, 0, 10, 20, 50, 100, 150, 200, 250, 300, 350, 400, 450, 500, 550, 600, 700, 800, 9000, 0};

    void Start () {
        money = money.GetComponent<Text>();
        starsValue = starsValue.GetComponent<Text>();
        starsCost = starsCost.GetComponent<Text>();
        InitShop();
        CleanShop();


    }
    private void Update()
    {
        money.text = SaveManager.Instance.state.money.ToString();
        starsValue.text = SaveManager.Instance.state.stars.ToString();
        starsCost.text = starCost[SaveManager.Instance.state.stars].ToString();

        //przyciski na smartfonie
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
        }

    }

    //cyferki dla blokow w skepie
    public void InitShop()
    {
        int i = 0;
        foreach(Transform t in skinPanel)
        {
            int currentIndex = i;

            Button b = t.GetComponent<Button>();
            b.onClick.AddListener(()=>OnSkinSelect(currentIndex));

            i++;
        }
        i = 0;
    }
    //kupowanie skina
    private void OnSkinSelect(int currentIndex)
    {
        if (SaveManager.Instance.IsSkinOwned(currentIndex))
        {
            SaveManager.Instance.state.SkinUse = currentIndex;
            SaveManager.Instance.Save();
            CleanShop();
        }
        else if(SaveManager.Instance.BuySkin(currentIndex, cost[currentIndex]))
        {
            SaveManager.Instance.state.SkinUse = currentIndex;
            SaveManager.Instance.Save();
            CleanShop();
        }
    }

    //reset sklepu
    private void CleanShop()
    {
        int i = 0;
        foreach (Transform t in skinPanel)
        {
            int currentIndex = i;
            Image img = SkinImg[currentIndex].GetComponent<Image>();
            img.color = Color.Lerp(Color.white, Color.clear, 170 / 250);
            if (SaveManager.Instance.IsSkinOwned(currentIndex))
            {
                SkinCostImg[currentIndex].SetActive(false);
                SkinImg[currentIndex].SetActive(true);
            }   
            if(SaveManager.Instance.state.SkinUse == currentIndex)
            {
                img.color = Color.cyan;
            }

            i++;
        }
        i = 0;
    }

    //kupowanie gwiazdki
    public void OnBuyStarClick()
    {
        if (SaveManager.Instance.state.stars <= 19 && SaveManager.Instance.state.money >= starCost[SaveManager.Instance.state.stars])
        {
            SaveManager.Instance.state.money -= starCost[SaveManager.Instance.state.stars];
            SaveManager.Instance.state.stars++;
        }
    }
}
