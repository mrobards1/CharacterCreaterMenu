using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_Controller : MonoBehaviour
{
   

   

    public void Update()
    {
        isFilled();
        toggleButton();
    }

    public void isFilled()
    {
        if ((Singleton.Instance.strengthVal != 0) && (Singleton.Instance.dexterityVal != 0) && (Singleton.Instance.constitutionVal != 0)
            && (Singleton.Instance.intelligenceVal != 0) && (Singleton.Instance.wisdomVal != 0) && (Singleton.Instance.charismaVal != 0)
            && (!string.IsNullOrEmpty(Singleton.Instance.characterName)) && (Singleton.Instance.walkingSpeed != 0) && (Singleton.Instance.runningSpeed != 0)
            && (Singleton.Instance.jumpHeight != 0) && (Singleton.Instance.characterClass != 0) && (Singleton.Instance.race != 0) && (!string.IsNullOrEmpty(Singleton.Instance.currentXP))
            && (!string.IsNullOrEmpty(Singleton.Instance.maxXP)) && (!string.IsNullOrEmpty(Singleton.Instance.currentHP)) && (!string.IsNullOrEmpty(Singleton.Instance.maxHP))
            && (!string.IsNullOrEmpty(Singleton.Instance.alignment)) && (!string.IsNullOrEmpty(Singleton.Instance.armorClass)) && (!string.IsNullOrEmpty(Singleton.Instance.itemList)))
        {
            Singleton.Instance.isFilledOut = true;
        }
        else
        {
            Singleton.Instance.isFilledOut = false;
        }
    }

    public void toggleButton()
    {
        Button Button_Play = GameObject.Find("Button_Play").GetComponent<Button>();
        if (Singleton.Instance.isFilledOut == true)
        {
            Button_Play.interactable = true;
        }
       
    }

}
