using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Singleton : MonoBehaviour
{

    public static Singleton Instance { get; private set; }

    public int strengthVal;
    public int dexterityVal;
    public int constitutionVal;
    public int intelligenceVal;
    public int wisdomVal;
    public int charismaVal;
    

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
