using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    

    private Button Button_Quit;

    

    private Text T_Out_Strength;
    private Button Button_Strength_Roll;
    private Text T_Out_Mod_Str;

    private Text T_Out_Dexterity;
    private Button Button_Dexterity_Roll;
    private Text T_Out_Mod_Dex;

    private Text T_Out_Constitution;
    private Button Button_Constitution_Roll;
    private Text T_Out_Mod_Con;

    private Text T_Out_Intelligence;
    private Button Button_Intelligence_Roll;
    private Text T_Out_Mod_Int;

    private Text T_Out_Wisdom;
    private Button Button_Wisdom_Roll;
    private Text T_Out_Mod_Wis;

    private Text T_Out_Charisma;
    private Button Button_Charisma_Roll;
    private Text T_Out_Mod_Cha;

    int mod_Strength;
    int mod_Dexterity;
    int mod_Constitution;
    int mod_Intelligence;
    int mod_Wisdom;
    int mod_Charisma;

    public void Start()
    {
        UIReferences();
        

    }

    

    public void UIReferences()
    {

        T_Out_Strength = GameObject.Find("T_Out_Strength").GetComponent<Text>();
        Button_Strength_Roll = GameObject.Find("Button_Strength_Roll").GetComponent<Button>();
        T_Out_Mod_Str = GameObject.Find("T_Out_Mod_Str").GetComponent<Text>();
        Button_Strength_Roll.onClick.AddListener(CallBack_Strength);
        

        T_Out_Dexterity = GameObject.Find("T_Out_Dexterity").GetComponent<Text>();
        Button_Dexterity_Roll = GameObject.Find("Button_Dexterity_Roll").GetComponent<Button>();
        Button_Dexterity_Roll.onClick.AddListener(CallBack_Dexterity);
        T_Out_Mod_Dex = GameObject.Find("T_Out_Mod_Dex").GetComponent<Text>();
        

        T_Out_Constitution = GameObject.Find("T_Out_Constitution").GetComponent<Text>();
        Button_Constitution_Roll = GameObject.Find("Button_Constitution_Roll").GetComponent<Button>();
        Button_Constitution_Roll.onClick.AddListener(CallBack_Constitution);
        T_Out_Mod_Con = GameObject.Find("T_Out_Mod_Con").GetComponent<Text>();

        T_Out_Intelligence = GameObject.Find("T_Out_Intelligence").GetComponent<Text>();
        Button_Intelligence_Roll = GameObject.Find("Button_Intelligence_Roll").GetComponent<Button>();
        Button_Intelligence_Roll.onClick.AddListener(CallBack_Intelligence);
        T_Out_Mod_Int = GameObject.Find("T_Out_Mod_Int").GetComponent<Text>();

        T_Out_Wisdom = GameObject.Find("T_Out_Wisdom").GetComponent<Text>();
        Button_Wisdom_Roll = GameObject.Find("Button_Wisdom_Roll").GetComponent<Button>();
        Button_Wisdom_Roll.onClick.AddListener(CallBack_Wisdom);
        T_Out_Mod_Wis = GameObject.Find("T_Out_Mod_Wis").GetComponent<Text>();

        T_Out_Charisma = GameObject.Find("T_Out_Charisma").GetComponent<Text>();
        Button_Charisma_Roll = GameObject.Find("Button_Charisma_Roll").GetComponent<Button>();
        Button_Charisma_Roll.onClick.AddListener(CallBack_Charisma);
        T_Out_Mod_Cha = GameObject.Find("T_Out_Mod_Cha").GetComponent<Text>();

        Button_Quit = GameObject.Find("Button_Quit").GetComponent<Button>();
        Button_Quit.onClick.AddListener(QuitGame);

       
    }

   public void SceneSwitch(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }


    int Dice_Simulator()
    {
        int[] Eight_Die_Rolls = new int[5];
        for (int i = 0; i < Eight_Die_Rolls.Length; i++)
        {
            Eight_Die_Rolls[i] = Random.RandomRange(1, 8);
        }

        int[] Six_Die_Rolls = new int[3];
        for (int i = 0; i < Six_Die_Rolls.Length; i++)
        {
            Six_Die_Rolls[i] = Random.RandomRange(1, 6);
        }

        int temp1;

        for (int i = 0; i < Eight_Die_Rolls.Length - 1; i++)
            for (int j = i + 1; j < Eight_Die_Rolls.Length; j++)
                if (Eight_Die_Rolls[i] < Eight_Die_Rolls[j])
                {
                    temp1 = Eight_Die_Rolls[i];
                    Eight_Die_Rolls[i] = Eight_Die_Rolls[j];
                    Eight_Die_Rolls[j] = temp1;
                }

        int addedNums1 = 0;
        for (int i = 0; i < Eight_Die_Rolls.Length; i++)
        {
            addedNums1 += Eight_Die_Rolls[i];
        }

        int temp2;

        for (int i = 0; i < Six_Die_Rolls.Length - 1; i++)
            for (int j = i + 1; j < Six_Die_Rolls.Length; j++)
                if (Six_Die_Rolls[i] < Six_Die_Rolls[j])
                {
                    temp2 = Six_Die_Rolls[i];
                    Six_Die_Rolls[i] = Six_Die_Rolls[j];
                    Six_Die_Rolls[j] = temp2;
                }

        int addedNums2 = 0;
        for (int i = 0; i < Six_Die_Rolls.Length; i++)
        {
            addedNums2 += Six_Die_Rolls[i];
        }
        int totalRoll = addedNums1 + addedNums2;
        return totalRoll;

    }

    public void CallBack_Strength()
    {
        int strength = Dice_Simulator();
        T_Out_Strength.text = strength.ToString();
        mod_Strength = strength + 2;
        T_Out_Mod_Str.text = mod_Strength.ToString();
        Singleton.Instance.strengthVal = mod_Strength;
    }

    
   

    public void CallBack_Dexterity()
    {
        int dexterity = Dice_Simulator();
        T_Out_Dexterity.text = dexterity.ToString();
        mod_Dexterity = dexterity + 2;
        T_Out_Mod_Dex.text = mod_Dexterity.ToString();
        Singleton.Instance.dexterityVal = mod_Dexterity;
    }

    public void CallBack_Constitution()
    {
        int constitution = Dice_Simulator();
        T_Out_Constitution.text = constitution.ToString();
        mod_Constitution = constitution + 2;
        T_Out_Mod_Con.text = mod_Constitution.ToString();
        Singleton.Instance.constitutionVal = mod_Constitution;
    }

    public void CallBack_Intelligence()
    {
        int intelligence = Dice_Simulator();
        T_Out_Intelligence.text = intelligence.ToString();
        mod_Intelligence = intelligence + 2;
        T_Out_Mod_Int.text = mod_Intelligence.ToString();
        Singleton.Instance.intelligenceVal = mod_Intelligence;
    }

    public void CallBack_Wisdom()
    {
        int wisdom = Dice_Simulator();
        T_Out_Wisdom.text = wisdom.ToString();
        mod_Wisdom = wisdom + 2;
        T_Out_Mod_Wis.text = mod_Wisdom.ToString();
        Singleton.Instance.wisdomVal = mod_Wisdom;
    }

    public void CallBack_Charisma()
    {
        int charisma = Dice_Simulator();
        T_Out_Charisma.text = charisma.ToString();
        mod_Charisma = charisma + 2;
        T_Out_Mod_Cha.text = mod_Charisma.ToString();
        Singleton.Instance.charismaVal = mod_Charisma;
    }

        public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }


}
