using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerData
{
    public string Player_Name;
    public string Ability_Strength;
    public string Ability_Dexterity;
    public string Ability_Constitution;
    public string Ability_Intelligence;
    public string Ability_Wisdom;
    public string Ability_Charisma;
    public string Walking_Speed;
    public string Running_Speed;
    public string Jump_Height;
    public string Class;
    public string Race;
    public string Current_XP;
    public string Max_XP;
    public string Current_HP;
    public string Max_HP;
    public string Alignment;
    public string ArmorClass;
    public string ItemList;

}

[System.Serializable]
public class UI_Controller : MonoBehaviour
{


    // Get references to your UI objects
    private InputField CharacterNameInput;
    private InputField Alignment_Input;
   
    private InputField Armor_Class_Input;
    
    private InputField Item_List_Input;

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

    private Text Walking_Val;
    private Slider Slider_Walking;

    private Text Running_Val;
    private Slider Slider_Running;

    private Text Jump_Height_Val;
    private Slider Slider_Jump_Height;

    private InputField Current_XP_Input;
    private InputField Max_XP_Input;

    private InputField Current_HP_Input;
    private InputField Max_HP_Input;

    private Dropdown Class;
    private Text Class_Val;

    private Dropdown Race;
    private Text Race_Val;

    private Button Generate_Button;
    private Text Text_Json_Output;

    private Button Exit_Button;
    public List<string> dates = new List<string>();


    public string SaveToJSon()
    {
        PlayerData data = new PlayerData();
        data.Player_Name = CharacterNameInput.text;
        data.Ability_Strength = T_Out_Mod_Str.text;
        data.Ability_Dexterity = T_Out_Mod_Dex.text;
        data.Ability_Constitution = T_Out_Mod_Con.text;
        data.Ability_Intelligence = T_Out_Mod_Int.text;
        data.Ability_Wisdom = T_Out_Mod_Wis.text;
        data.Ability_Charisma = T_Out_Mod_Cha.text;
        data.Walking_Speed = Walking_Val.text;
        data.Running_Speed = Running_Val.text;
        data.Jump_Height = Jump_Height_Val.text;
        data.Current_XP = Current_XP_Input.text;
        data.Max_XP = Max_XP_Input.text;
        data.Current_HP = Current_HP_Input.text;
        data.Max_HP = Max_HP_Input.text;
        data.Alignment = Alignment_Input.text;
        data.ArmorClass = Armor_Class_Input.text;
        data.Class = Class_Val.text;
        data.Race = Race_Val.text;
        data.ItemList = Item_List_Input.text;

        string json = JsonUtility.ToJson(data, true);
        return json;

    }





    void Start()
    {
        UIReferences();
    }

    private void UIReferences()
    {

        CharacterNameInput = GameObject.Find("CharacterNameInput").GetComponent<InputField>();
        CharacterNameInput.onEndEdit.AddListener(CharacterName);


        Alignment_Input = GameObject.Find("Alignment_Input").GetComponent<InputField>();
        Alignment_Input.onEndEdit.AddListener(CallBack_Alignment);

        Item_List_Input = GameObject.Find("Item_List_Input").GetComponent<InputField>();
        Item_List_Input.onEndEdit.AddListener(CallBack_Item_List);

        Armor_Class_Input = GameObject.Find("Armor_Class_Input").GetComponent<InputField>();
        Armor_Class_Input.onEndEdit.AddListener(CallBack_Armor_Class);


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

        Walking_Val = GameObject.Find("Walking_Val").GetComponent<Text>();
        Slider_Walking = GameObject.Find("Slider_Walking").GetComponent<Slider>();
        Slider_Walking.onValueChanged.AddListener(CallBack_Walking_Slider);

        Running_Val = GameObject.Find("Running_Val").GetComponent<Text>();
        Slider_Running = GameObject.Find("Slider_Running").GetComponent<Slider>();
        Slider_Running.onValueChanged.AddListener(CallBack_Running_Slider);

        Jump_Height_Val = GameObject.Find("Jump_Height_Val").GetComponent<Text>();
        Slider_Jump_Height = GameObject.Find("Slider_Jump_Height").GetComponent<Slider>();
        Slider_Jump_Height.onValueChanged.AddListener(CallBack_Jump_Height_Slider);

        Current_XP_Input = GameObject.Find("Current_XP_Input").GetComponent<InputField>();
        Current_XP_Input.onEndEdit.AddListener(CallBack_Current_XP);

        Max_XP_Input = GameObject.Find("Max_XP_Input").GetComponent<InputField>();
        Max_XP_Input.onEndEdit.AddListener(CallBack_Max_XP);

        Current_HP_Input = GameObject.Find("Current_HP_Input").GetComponent<InputField>();
        Current_HP_Input.onEndEdit.AddListener(CallBack_Current_HP);

        Max_HP_Input = GameObject.Find("Max_HP_Input").GetComponent<InputField>();
        Max_HP_Input.onEndEdit.AddListener(CallBack_Max_HP);

        Class_Val = GameObject.Find("Class_Select_Value").GetComponent<Text>();
        Class = GameObject.Find("Class_Select").GetComponent<Dropdown>();
        Class.onValueChanged.AddListener(CallBack_Class);

        Race_Val = GameObject.Find("Race_Select_Value").GetComponent<Text>();
        Race = GameObject.Find("Race_Select").GetComponent<Dropdown>();
        Race.onValueChanged.AddListener(CallBack_Race);

        Text_Json_Output = GameObject.Find("Text_Json_Output").GetComponent<Text>();
        Generate_Button = GameObject.Find("Generate_Button").GetComponent<Button>();
        Generate_Button.onClick.AddListener(CallBack_Json_Output);

        Exit_Button = GameObject.Find("Button_Exit").GetComponent<Button>();
        Exit_Button.onClick.AddListener(QuitGame);

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


    public void CharacterName(string characterName)
    {
        Singleton.Instance.characterName = characterName;
        Debug.Log("Callback_Race was called");
    }


    public void CallBack_Race(int Race)
    {
        Race_Val.text = Race.ToString();
        Debug.Log("Callback_Race was called");
        Singleton.Instance.race = Race;

    }

    public void CallBack_Class(int Class)
    {
        Class_Val.text = Class.ToString();
        Debug.Log("Callback_Class was called");
        Singleton.Instance.characterClass = Class;
    }

    public void CallBack_Alignment(string alignment)
    {
        Singleton.Instance.alignment = alignment;
        Debug.Log("Callback_Race was called");
    }

    public void CallBack_Strength()
    {
        int strength = Dice_Simulator();
        T_Out_Strength.text = strength.ToString();
        int mod_Strength = strength + 2;
        T_Out_Mod_Str.text = mod_Strength.ToString();
        Singleton.Instance.strengthVal = mod_Strength;
    }

    public void CallBack_Dexterity()
    {
        int dexterity = Dice_Simulator();
        T_Out_Dexterity.text = dexterity.ToString();
        int mod_Dexterity = dexterity + 2;
        T_Out_Mod_Dex.text = mod_Dexterity.ToString();
        Singleton.Instance.dexterityVal = mod_Dexterity;
    }

    public void CallBack_Constitution()
    {
        int constitution = Dice_Simulator();
        T_Out_Constitution.text = constitution.ToString();
        int mod_Constitution = constitution + 2;
        T_Out_Mod_Con.text = mod_Constitution.ToString();
        Singleton.Instance.constitutionVal = mod_Constitution;
    }

    public void CallBack_Intelligence()
    {
        int intelligence = Dice_Simulator();
        T_Out_Intelligence.text = intelligence.ToString();
        int mod_Intelligence = intelligence + 2;
        T_Out_Mod_Int.text = mod_Intelligence.ToString();
        Singleton.Instance.intelligenceVal = mod_Intelligence;
    }

    public void CallBack_Wisdom()
    {
        int wisdom = Dice_Simulator();
        T_Out_Wisdom.text = wisdom.ToString();
        int mod_Wisdom = wisdom + 2;
        T_Out_Mod_Wis.text = mod_Wisdom.ToString();
        Singleton.Instance.wisdomVal = mod_Wisdom;
    }

    public void CallBack_Charisma()
    {
        int charisma = Dice_Simulator();
        T_Out_Charisma.text = charisma.ToString();
        int mod_Charisma = charisma + 2;
        T_Out_Mod_Cha.text = mod_Charisma.ToString();
        Singleton.Instance.charismaVal = mod_Charisma;
    }

    public void CallBack_Walking_Slider(float Slider_Walking)
    {
        Walking_Val.text = Slider_Walking.ToString();
        Singleton.Instance.walkingSpeed = Slider_Walking;
    }

    public void CallBack_Running_Slider(float Slider_Running)
    {
        Running_Val.text = Slider_Running.ToString();
        Singleton.Instance.runningSpeed = Slider_Running;
    }

    public void CallBack_Jump_Height_Slider(float Slider_Jump_Height)
    {
        Jump_Height_Val.text = Slider_Jump_Height.ToString();
        Singleton.Instance.jumpHeight = Slider_Jump_Height;
    }

    public void CallBack_Current_XP(string Current_XP_Input)
    {
        Singleton.Instance.currentXP = Current_XP_Input;
        Debug.Log("Callback_Current_XP was called");
    }

    public void CallBack_Max_XP(string Max_XP_Input)
    {
        Singleton.Instance.maxXP = Max_XP_Input;
        Debug.Log("Callback_Max_XP was called");
    }

    public void CallBack_Current_HP(string Current_HP_Input)
    {
        Singleton.Instance.currentHP = Current_HP_Input;
        Debug.Log("Callback_Current_HP was called");
    }

    public void CallBack_Max_HP(string Max_HP_Input)
    {
        Singleton.Instance.maxHP = Max_HP_Input;
        Debug.Log("Callback_Max_HP was called");
    }

    public void CallBack_Armor_Class(string Armor_Class_Input)
    {
        if (int.Parse(Armor_Class_Input.ToString()) > 100)
        {
            Armor_Class_Input = "100";
        }
        else if (int.Parse(Armor_Class_Input.ToString()) < 0)
        {
            Armor_Class_Input = "0";
        }
        Singleton.Instance.armorClass = Armor_Class_Input;
        Debug.Log("Callback_Max_HP was called");
    }

    public void CallBack_Item_List(string item_list)
    {
        Singleton.Instance.itemList = item_list;
        Debug.Log("CallBack_Item_List was called");
    }

    public void CallBack_Json_Output()
    {
        Text_Json_Output.text = SaveToJSon();
    }

    

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }



}