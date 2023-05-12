using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NinjasManagement : MonoBehaviour
{
    int currentNinja;
    public int maxNinjas;

    public List<int> ninjasPrices = new List<int>();
    public List<string> ninjasDescriptions = new List<string>();

    public GameObject ninjaObj;

    Animator _anim;
    SpriteRenderer _spriteRender;
    public MainMenuGUI menuGUI;

    public ParticleSystem smokeParticles;

    void Start()
    {
        _anim = ninjaObj.GetComponent<Animator>();
        _spriteRender = ninjaObj.GetComponent<SpriteRenderer>();

        currentNinja = GameManager.instance.currentNinja;
        ChangeNinjaSprite();
    }

    
    void Update()
    {
        SwitchButtons();

        if (GameManager.instance.ninjasOwned[currentNinja])
        {
            _spriteRender.color = Color.white;
            menuGUI.description.text = ninjasDescriptions[currentNinja];
        }
        else
        {
            _spriteRender.color = new Color(0.25f, 0.25f, 0.25f, 1);
            menuGUI.description.text = "???";
        }
    }

    void SwitchButtons()
    {
        if (GameManager.instance.ninjasOwned[currentNinja])
        {
            menuGUI.playButton.gameObject.SetActive(true);
            menuGUI.buyButton.gameObject.SetActive(false);
        }
        else
        {
            menuGUI.playButton.gameObject.SetActive(false);
            menuGUI.buyButton.gameObject.SetActive(true);

            menuGUI.priceTxt.text = ninjasPrices[currentNinja].ToString();

            if(ninjasPrices[currentNinja] < GameManager.instance.coins)
            {
                menuGUI.buyButton.interactable = true;
            }
            else
            {
                menuGUI.buyButton.interactable = false;
            }
        }
    }

    public void SelectNinja(int adder)
    {
        smokeParticles.Play();

        if (adder > 0)
        {
            if(currentNinja < maxNinjas)
            {
                currentNinja += adder;
            }
            else
            {
                currentNinja = 0;
            }
        }
        else if(adder < 0)
        {
            if (currentNinja > 0)
            {
                currentNinja += adder;
            }
            else
            {
                currentNinja = maxNinjas;
            }
        }
        ChangeNinjaSprite();
        GameManager.instance.currentNinja = currentNinja;
    }

    void ChangeNinjaSprite()
    {
        _anim.SetInteger("selectedNinja", currentNinja);
    }

    public void BuyNinja()
    {
        if(!GameManager.instance.ninjasOwned[currentNinja] && ninjasPrices[currentNinja] < GameManager.instance.coins)
        {
            GameManager.instance.coins -= ninjasPrices[currentNinja];

            GameManager.instance.ninjasOwned[currentNinja] = true;
            GameManager.instance.SaveGame();
            menuGUI.UpdateValues();
        }
    }
}
