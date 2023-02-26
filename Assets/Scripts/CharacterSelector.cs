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
        characterDisplay.sprite = characterClasses[currentCharacterSelected].characterSprite;
        characterName.text = characterClasses[currentCharacterSelected].characterName;
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
        Debug.Log("Current Character selected: " + currentCharacterSelected);
        characterDisplay.sprite = characterClasses[currentCharacterSelected].characterSprite;
        characterName.text = characterClasses[currentCharacterSelected].characterName;
    }
}
