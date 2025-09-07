using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private float statHappy = 100, statSatiety = 100, statEnergy = 100, max = 100;
    public Image CurrentHappiness, CurrentSatiety, CurrentEnergy;

    bool Activ = true;

    [SerializeField] private TMP_Text cointCnt;

    public Text eatCnt;

    public Button Feed, Play, Sleep, Read, BtnBuyEat;
    public GameObject BackNight, Game_over_box, PetNormal, PetSad, PetVerySad, PetHungry, PetVeryHungry, PetTierd, PetAcSleep;

    private void Start()
    {
        Button btn1 = Feed.GetComponent<Button>();
        btn1.onClick.AddListener(FeedPet);

        Button btn2 = Play.GetComponent<Button>();
        btn2.onClick.AddListener(PlayPet);


        Button btn3 = Sleep.GetComponent<Button>();
        btn3.onClick.AddListener(PetSleep);

        Button btn4 = Read.GetComponent<Button>();
        btn4.onClick.AddListener(PlayerRead);

        Button btn5 = BtnBuyEat.GetComponent<Button>();
        btn5.onClick.AddListener(Buy);

        BackNight.gameObject.SetActive(false);

        UpdateEnergyBar();
        UpdateHappyBar();
        UpdateSatietyBar();

        Update();
    }

    void ChoseSprite() 
    {
        if (statSatiety < 20)
        {
            PetVerySad.gameObject.SetActive(false);
            PetSad.gameObject.SetActive(false);
            PetNormal.gameObject.SetActive(false);
            PetHungry.gameObject.SetActive(false);
            PetTierd.gameObject.SetActive(false);

            PetVeryHungry.gameObject.SetActive(true);
        }
        else
                if (statSatiety > 20 && statSatiety < 50)
        {
            PetVerySad.gameObject.SetActive(false);
            PetSad.gameObject.SetActive(false);
            PetNormal.gameObject.SetActive(false);
            PetVeryHungry.gameObject.SetActive(false);
            PetTierd.gameObject.SetActive(false);

            PetHungry.gameObject.SetActive(true);
        }
        else
                if (statHappy < 20)
        {
            PetSad.gameObject.SetActive(false);
            PetNormal.gameObject.SetActive(false);
            PetHungry.gameObject.SetActive(false);
            PetVeryHungry.gameObject.SetActive(false);
            PetTierd.gameObject.SetActive(false);

            PetVerySad.gameObject.SetActive(true);
        }
        else
                if (statHappy > 20 && statHappy < 50)
        {
            PetVerySad.gameObject.SetActive(false);
            PetNormal.gameObject.SetActive(false);
            PetHungry.gameObject.SetActive(false);
            PetVeryHungry.gameObject.SetActive(false);
            PetTierd.gameObject.SetActive(false);

            PetSad.gameObject.SetActive(true);
        }
        else if (statEnergy < 20)
        {
            PetVerySad.gameObject.SetActive(false);
            PetSad.gameObject.SetActive(false);
            PetNormal.gameObject.SetActive(false);
            PetHungry.gameObject.SetActive(false);
            PetVeryHungry.gameObject.SetActive(false);

            PetTierd.gameObject.SetActive(true);
        }
        else
        {
            PetVerySad.gameObject.SetActive(false);
            PetSad.gameObject.SetActive(false);
            PetHungry.gameObject.SetActive(false);
            PetVeryHungry.gameObject.SetActive(false);
            PetTierd.gameObject.SetActive(false);

            PetNormal.gameObject.SetActive(true);
        }
    }

    private void Awake()
    {
        float happy = PlayerPrefs.GetFloat("happy");

        PlayerPrefs.SetFloat("happy", happy);
        statHappy = happy;

        ChoseSprite();

        float satiety = PlayerPrefs.GetFloat("satiety");

        PlayerPrefs.SetFloat("satiety", satiety);
        statSatiety = satiety;

        ChoseSprite();


        float enegy = PlayerPrefs.GetFloat("enegy");

        PlayerPrefs.SetFloat("enegy", enegy);
        statEnergy = enegy;

        ChoseSprite();


        max = 100;

        int coins = PlayerPrefs.GetInt("coins");
        PlayerPrefs.SetInt("coins", coins);
        cointCnt.text = (coins).ToString();

        int eat = PlayerPrefs.GetInt("eat");
        eatCnt.text = "x " + (eat).ToString();
    }



    private void Update()
    {
        statHappy -= 2.5f * Time.deltaTime;
        if (statHappy < 0) statHappy = 0;
        
        PlayerPrefs.SetFloat("happy", statHappy);

        if (statHappy > 50 && statHappy < 52 && Activ)
        {
            PetSad.gameObject.SetActive(true);

            PetVerySad.gameObject.SetActive(false); PetNormal.gameObject.SetActive(false);
            PetHungry.gameObject.SetActive(false); PetVeryHungry.gameObject.SetActive(false);
            PetTierd.gameObject.SetActive(false);
        }
        else
        if (statHappy > 20 && statHappy < 22 && Activ)
        {
            PetVerySad.gameObject.SetActive(true);

            PetSad.gameObject.SetActive(false); PetNormal.gameObject.SetActive(false);
            PetHungry.gameObject.SetActive(false); PetVeryHungry.gameObject.SetActive(false);
            PetTierd.gameObject.SetActive(false);
        }

        if (Activ)
        {
            statEnergy -= 3.5f * Time.deltaTime;
            if (statEnergy < 0) statEnergy = 0;

            PlayerPrefs.SetFloat("enegy", statEnergy);
        }
        else
        {
            statEnergy += 3.5f * Time.deltaTime;
            if (statEnergy > max) statEnergy = max;
            
            PlayerPrefs.SetFloat("enegy", statEnergy);
        }
        if (statEnergy > 20 && statEnergy < 22 && Activ)
        {
            PetTierd.gameObject.SetActive(true);

            PetVerySad.gameObject.SetActive(false); PetSad.gameObject.SetActive(false);
            PetNormal.gameObject.SetActive(false); PetHungry.gameObject.SetActive(false);
            PetVeryHungry.gameObject.SetActive(false);
        }

        statSatiety -= 1.5f * Time.deltaTime;
        if (statSatiety < 0) statSatiety = 0;

        PlayerPrefs.SetFloat("satiety", statSatiety);


        if (statSatiety > 50 && statSatiety < 52 && Activ)
        {
            PetHungry.gameObject.SetActive(true);

            PetVerySad.gameObject.SetActive(false); PetSad.gameObject.SetActive(false);
            PetNormal.gameObject.SetActive(false); PetVeryHungry.gameObject.SetActive(false);
            PetTierd.gameObject.SetActive(false);

        }
        else
        if (statSatiety > 20 && statSatiety < 22 && Activ)
        {
            PetVeryHungry.gameObject.SetActive(true);

            PetHungry.gameObject.SetActive(false); PetVerySad.gameObject.SetActive(false);
            PetSad.gameObject.SetActive(false); PetNormal.gameObject.SetActive(false);
            PetTierd.gameObject.SetActive(false);

        }

        UpdateEnergyBar();
        UpdateHappyBar();
        UpdateSatietyBar();

        GameOver();
    }

    private void UpdateSatietyBar()
    {
        float ratio = statSatiety / max;
        CurrentSatiety.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    private void UpdateHappyBar()
    {
        float ratio = statHappy / max;
        CurrentHappiness.rectTransform.localScale = new Vector3(ratio, 1, 1);

    }
    private void UpdateEnergyBar()
    {
        float ratio = statEnergy / max;
        CurrentEnergy.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    void PlayPet()
    {
        Debug.Log("Play button has been clicked");
        if (Activ)
        {
            statHappy += 10;
            if (statHappy > 100)
                statHappy = max;
        }
        else { return; }
        if (statHappy > 50)
        {
            ChoseSprite();
        }
        else
        if (statHappy > 20)
        {
            PetSad.gameObject.SetActive(true);

            PetVerySad.gameObject.SetActive(false);
            PetNormal.gameObject.SetActive(false);
            PetHungry.gameObject.SetActive(false);
            PetVeryHungry.gameObject.SetActive(false);
            PetTierd.gameObject.SetActive(false);

        }

        UpdateHappyBar();
    }


    public void Buy()
    {
        int coins = PlayerPrefs.GetInt("coins");
        if (coins >= 15)
        {
            PlayerPrefs.SetInt("coins", coins - 15);
            cointCnt.text = (coins - 15).ToString();

            int eat = PlayerPrefs.GetInt("eat");
            PlayerPrefs.SetInt("eat", eat + 1);
            eatCnt.text = "x " + (eat + 1).ToString();
        }
    }

    void FeedPet()
    {
        Debug.Log("Feed button has been clicked");

        if (Activ && PlayerPrefs.GetInt("eat") > 0 && statSatiety < 80)
        {
            statSatiety += 30;
            if (statSatiety > 100)
                statSatiety = max;

            int eat = PlayerPrefs.GetInt("eat");
            PlayerPrefs.SetInt("eat", eat - 1);
            eatCnt.text = "x " + (eat - 1).ToString();
        }
        else { return; }
        if (statSatiety > 50)
        {
            ChoseSprite();
        }
        else
        if (statSatiety > 20)
        {
            PetHungry.gameObject.SetActive(true);
            PetVeryHungry.gameObject.SetActive(false);
            PetSad.gameObject.SetActive(false);
            PetVerySad.gameObject.SetActive(false);
            PetNormal.gameObject.SetActive(false);
            PetTierd.gameObject.SetActive(false);

        }

        UpdateSatietyBar();
    }

    void PetSleep()
    {
        Debug.Log("Play button has been clicked");


        Activ = !Activ;

        if (!Activ)
        {
            PetAcSleep.gameObject.SetActive(true);
            BackNight.gameObject.SetActive(true);

            PetHungry.gameObject.SetActive(false);
            PetVeryHungry.gameObject.SetActive(false);
            PetSad.gameObject.SetActive(false);
            PetVerySad.gameObject.SetActive(false);
            PetNormal.gameObject.SetActive(false);
            PetTierd.gameObject.SetActive(false);
        }
        else
            if (Activ)
        {
            PetAcSleep.gameObject.SetActive(false);
            BackNight.gameObject.SetActive(false);

            ChoseSprite();
        }

        UpdateEnergyBar();
    }
    void PlayerRead()
    {
        Debug.Log("Read button has been clicked");

    }

    void GameOver()
    {
        if (statEnergy == 0 && statHappy == 0 && statSatiety == 0)
        {
            Feed.gameObject.SetActive(false);
            Play.gameObject.SetActive(false);
            Sleep.gameObject.SetActive(false);
            Read.gameObject.SetActive(false);
            Game_over_box.gameObject.SetActive(true);

            PetVerySad.gameObject.SetActive(false);
            PetSad.gameObject.SetActive(false);
            PetNormal.gameObject.SetActive(false);
            PetHungry.gameObject.SetActive(false);
            PetVeryHungry.gameObject.SetActive(false);
            PetTierd.gameObject.SetActive(false);


            PlayerPrefs.SetInt("eat", 0);
            PlayerPrefs.SetFloat("coins", 0);
        }
    }
}
