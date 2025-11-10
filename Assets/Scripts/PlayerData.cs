using System;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    //public static PlayerData Instance;
    public string playerName;
    public Vector3 playerPosition;
    public int _playerMaxHealth;
    public int _playerMaxMana;
    public int _playerExp;

    /*void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }*/

    public void SaveData()
    {
        /*UserData.playerName = playerName;
        UserData._playerMaxHealth = _playerMaxHealth;
        UserData._playerMaxMana = _playerMaxMana;
        UserData._playerExp = _playerExp;
        UserData.playerPosition = playerPosition;*/

        Stats.userStats.playerName = playerName;
        Stats.userStats.playerPosition = playerPosition;
        Stats.userStats.playerHealth = _playerMaxHealth;
        Stats.userStats.playerExp = _playerExp;

        SavingDataSystem.Save();

        //Debug.Log("Data Saved");
    }

    public void LoadData()
    {
        /*playerName = UserData.playerName;
        _playerMaxHealth = UserData._playerMaxHealth;
        _playerMaxMana = UserData._playerMaxMana;
        _playerExp = UserData._playerExp;
        playerPosition = UserData.playerPosition;*/
        SavingDataSystem.Load();

        playerName = Stats.userStats.playerName;
        playerPosition = Stats.userStats.playerPosition;
        _playerMaxHealth = Stats.userStats.playerHealth;
        _playerExp = Stats.userStats.playerExp;

        //Debug.Log("Data Loaded");
    }

    public void SavePrefs()
    {
        //para guardar --> .set
        PlayerPrefs.SetString("Player Name", playerName);
        PlayerPrefs.SetInt("Player Health", _playerMaxHealth);
        PlayerPrefs.SetInt("Player Mana", _playerMaxMana);
        PlayerPrefs.SetInt("Player exp", _playerExp);
        //
        PlayerPrefs.SetFloat("Player x", playerPosition.x);
        PlayerPrefs.SetFloat("Player y", playerPosition.y);
        PlayerPrefs.SetFloat("Player z", playerPosition.z);
    }
    
    public void LoadPrefs()
    {
        //para cargar --> .get
        playerName = PlayerPrefs.GetString("Player Name", "No name");
        _playerMaxHealth = PlayerPrefs.GetInt("Player Health", 1);
        _playerMaxMana = PlayerPrefs.GetInt("Player Mana", 1);
        _playerExp = PlayerPrefs.GetInt("Player exp", 1);
        //
        playerPosition.x = PlayerPrefs.GetFloat("Player x");
        playerPosition.y = PlayerPrefs.GetFloat("Player y");
        playerPosition.z = PlayerPrefs.GetFloat("Player z");

        //playerPosition = new Vector3(PlayerPrefs.GetFloat("Player x"), PlayerPrefs.GetFloat("Player y"), PlayerPrefs.GetFloat("Player z"));
    }
}