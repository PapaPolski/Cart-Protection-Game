using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    public static CharacterSelector instance { get; private set; }
    public Sprite[] characters;
    public int currentCharacterSelected;
    public Image characterDisplay;

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
        Debug.Log(characters.Length);
        currentCharacterSelected = 0;
        characterDisplay.sprite = characters[currentCharacterSelected];
    }

    public void ChangeCurrentCharacter(bool positive)
    {
        if(positive)
        {
            if (currentCharacterSelected < (characters.Length-1))
            {
                currentCharacterSelected++;
            }
            else if (currentCharacterSelected == (characters.Length-1))
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
                currentCharacterSelected = (characters.Length -1);
            }
        }
        Debug.Log("Current Character selected: " + currentCharacterSelected);
        characterDisplay.sprite = characters[currentCharacterSelected];
    }
}
