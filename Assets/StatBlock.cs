using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBlock : MonoBehaviour
{
    public GameObject[] statNodes;
    public int[] displayValues;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnCharacterChange(float statToDisplay)
    {
        //(currentX - minX) / (maxX - minX)
        float percentage = (statToDisplay - 1) / (2 - 1) * 100;
        Debug.Log(percentage);
        
        for (int i = 0; i < statNodes.Length; i++)
        {
            if(percentage >= displayValues[i] || i == 0)
            {
                statNodes[i].SetActive(true);
            }
            else
            {
                statNodes[i].SetActive(false);
            }
        }
    }
}
