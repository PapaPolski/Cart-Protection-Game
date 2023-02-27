using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelector : MonoBehaviour
{
    public static CharacterSelector instance { get; private set; }
    public int currentCharacterSelected;
    public Image characterDisplay;

    public Character[] characterClasses;
    public TextMeshProUGUI characterName;
    public GameObject startButton, unlockCondition, characterPanel;

    public TextMeshProUGUI flavorText;
    public StatBlock speedStat, craftStat, cartStat;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != null)
        {
            Destroy(instance.gameObject);
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        currentCharacterSelected = 0;
        CheckUnlockCondition(0);
    }

    public void ChangeCurrentCharacter(bool positive)
    {
        if(positive)
        {
            if (currentCharacterSelected < (characterClasses.Length-1))
            {
                currentCharacterSelected++;
            }
            else if (currentCharacterSelected == (characterClasses.Length-1))
            {
                currentCharacterSelected = 0;
            }
        }
        else
        {
            if(currentCharacterSelected > 0)
            {
                currentCharacterSelected--;
            }
            else if(currentCharacterSelected == 0)
            {
                currentCharacterSelected = (characterClasses.Length -1);
            }
        }
        CheckUnlockCondition(currentCharacterSelected);
    }

    void CheckUnlockCondition(int characterCheck)
    {
        if (characterClasses[currentCharacterSelected].unlockedFromStart)
        {
            HandleUnlock(true);
        }   
        else
        {
            switch(characterClasses[currentCharacterSelected].playerPrefKey)
            {
                case "Hiscore":
                    CheckPlayerPrefKey("Hiscore");
                    break;
                case "TotalGhosts":
                    CheckPlayerPrefKey("TotalGhosts");
                    break;
                case "TotalTreasure":
                    CheckPlayerPrefKey("TotalTreasure");
                    break;
                case "TotalLaps":
                    CheckPlayerPrefKey("TotalLaps");
                    break;
            }
        }
    }

    void CheckPlayerPrefKey(string playerPrefString)
    {
        if (PlayerPrefs.HasKey(playerPrefString))
        {
            if (characterClasses[currentCharacterSelected].unlockConditionAmount > PlayerPrefs.GetInt(playerPrefString))
            {
                HandleUnlock(false);
                Debug.Log("You need to get a highscore of " + characterClasses[currentCharacterSelected].unlockConditionAmount.ToString());
            }
            else if (characterClasses[currentCharacterSelected].unlockConditionAmount <= PlayerPrefs.GetInt(playerPrefString))
            {
                HandleUnlock(true);
            }
        }
        else
        {
            HandleUnlock(false);
        }
    }
    void HandleUnlock(bool unlocked)
    {
        Color color = characterDisplay.color;
        if (unlocked)
        {
            characterDisplay.sprite = characterClasses[currentCharacterSelected].characterSprite;
            color.a = 1f;
            characterDisplay.color = color;
            characterName.text = characterClasses[currentCharacterSelected].characterName;
            if (!startButton.active)
                startButton.SetActive(true);
            unlockCondition.SetActive(false);
            characterPanel.SetActive(true);
        }
        else
        {
            characterDisplay.sprite = characterClasses[currentCharacterSelected].characterSprite;
            color.a = 0.2f;
            characterDisplay.color = color;
            characterName.text = characterClasses[currentCharacterSelected].characterName;
            if (startButton.active)
                startButton.SetActive(false);
            unlockCondition.SetActive(true);
            characterPanel.SetActive(false);
        }
        CharacterPanelInfo();
    }

    void CharacterPanelInfo()
    {
        flavorText.text = characterClasses[currentCharacterSelected].flavorText;
        unlockCondition.GetComponent<TextMeshProUGUI>().text = characterClasses[currentCharacterSelected].unlockText;

        speedStat.OnCharacterChange(characterClasses[currentCharacterSelected].speed);

    }
}
