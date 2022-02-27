using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Singleton : MonoBehaviour
{

    public static Singleton Instance { get; private set; }

    public string characterName;
    public int strengthVal;
    public int dexterityVal;
    public int constitutionVal;
    public int intelligenceVal;
    public int wisdomVal;
    public int charismaVal;
    public float walkingSpeed;
    public float runningSpeed;
    public float jumpHeight;
    public int characterClass;
    public int race;
    public string currentXP;
    public string maxXP;
    public string currentHP;
    public string maxHP;
    public string alignment;
    public string armorClass;
    public string itemList;
    public bool isFilledOut;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

   
    
}
