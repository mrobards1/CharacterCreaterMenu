using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_Controller : MonoBehaviour
{
    public Button playButton;

    public bool isFilledOut()
    {
        
        if ((Singleton.Instance.strengthVal != 0) && (Singleton.Instance.dexterityVal != 0) && (Singleton.Instance.constitutionVal != 0)
            && (Singleton.Instance.intelligenceVal != 0) && (Singleton.Instance.wisdomVal != 0) && (Singleton.Instance.charismaVal != 0))
        {
            return true;
        }
        return false;
        
    }

    private void Start()
    {
        
        
    }

    public void Pressable()
    {
        if (isFilledOut() == true)
        {
            playButton.interactable = true;
        }
    }

    private void Update()
    {
        print(isFilledOut());
    }
}
