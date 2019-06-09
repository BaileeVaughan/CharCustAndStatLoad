﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CustSet : MonoBehaviour
{
    #region Variables
    //Character Cust
    [Header("Texture List")]
    public List<Texture2D> skin = new List<Texture2D>();
    public List<Texture2D> eyes = new List<Texture2D>();
    public List<Texture2D> mouth = new List<Texture2D>();
    public List<Texture2D> hair = new List<Texture2D>();
    public List<Texture2D> armour = new List<Texture2D>();
    public List<Texture2D> clothes = new List<Texture2D>();
    [Header("Index")]
    public int skinIndex;
    public int eyesIndex, mouthIndex, hairIndex, armourIndex, clothesIndex;
    [Header("Renderer")]
    public Renderer character;
    [Header("Max Index")]
    public int skinMax;
    public int eyesMax, mouthMax, hairMax, armourMax, clothesMax;
    //Stats
    [Header("Character Name")]
    public string charName = "";
    [Header("Stats")]
    //base player stats
    public string[] statArray = new string[7];
    public int[] stats = new int[7];
    public int[] tempStats = new int[7];
    public int points = 10;
    public int selectedIndex = 0;
    public CharacterClass charClass = CharacterClass.Fighter;
    public Text classText;
    public string[] selectedClass = new string[8];
    public string[] selectedRace = new string[11];
    #endregion
    #region Start
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        statArray = new string[] { "Power", "Dexterity", "Constitution", "Wisdom", "Intelligence", "Charisma", "Courage" };
        selectedRace = new string[] { "Hylian", "Twili", "Rito", "Zora", "Goron", "Minish", "Deku", "Kokiri", "Korok", "Gerudo", "Sheikah" };
        selectedClass = new string[] { "Fighter", "Opportunist", "Researcher", "Sage", "Commoner", "Scion", "Warrior", "Sharpshooter" };

        #region Pull Textures
        for (int i = 0; i < skinMax; i++)
        {
            Texture2D temp = Resources.Load("Character/Skin_" + i) as Texture2D;
            skin.Add(temp);
        }
        for (int i = 0; i < eyesMax; i++)
        {
            Texture2D temp = Resources.Load("Character/Eyes_" + i) as Texture2D;
            eyes.Add(temp);
        }
        for (int i = 0; i < mouthMax; i++)
        {
            Texture2D temp = Resources.Load("Character/Mouth_" + i) as Texture2D;
            mouth.Add(temp);
        }
        for (int i = 0; i < hairMax; i++)
        {
            Texture2D temp = Resources.Load("Character/Hair_" + i) as Texture2D;
            hair.Add(temp);
        }
        for (int i = 0; i < armourMax; i++)
        {
            Texture2D temp = Resources.Load("Character/Armour_" + i) as Texture2D;
            armour.Add(temp);
        }
        for (int i = 0; i < clothesMax; i++)
        {
            Texture2D temp = Resources.Load("Character/Clothes_" + i) as Texture2D;
            clothes.Add(temp);
        }
        #endregion
        character = GameObject.Find("Mesh").GetComponent<SkinnedMeshRenderer>();
        SetTexture("Skin", skinIndex = 0);
        SetTexture("Eyes", eyesIndex = 0);
        SetTexture("Mouth", mouthIndex = 0);
        SetTexture("Hair", hairIndex = 0);
        SetTexture("Armour", armourIndex = 0);
        SetTexture("Clothes", clothesIndex = 0);
    }
    #endregion
    #region Update
    private void Update()
    {
        CharName();
        classText.text = selectedClass[selectedIndex];
    }
    #endregion
    #region SetTexture
    public void SetTexture(string type, int dir)
    {
        int index = 0, max = 0, matIndex = 0;
        Texture2D[] textures = new Texture2D[0];
        #region Switch Materials
        switch (type)
        {
            case "Skin":
                index = skinIndex;
                max = skinMax;
                textures = skin.ToArray();
                matIndex = 1;
                break;
            case "Eyes":
                index = eyesIndex;
                max = eyesMax;
                textures = eyes.ToArray();
                matIndex = 2;
                break;
            case "Mouth":
                index = mouthIndex;
                max = mouthMax;
                textures = mouth.ToArray();
                matIndex = 3;
                break;
            case "Hair":
                index = hairIndex;
                max = hairMax;
                textures = hair.ToArray();
                matIndex = 4;
                break;
            case "Armour":
                index = armourIndex;
                max = armourMax;
                textures = armour.ToArray();
                matIndex = 5;
                break;
            case "Clothes":
                index = clothesIndex;
                max = clothesMax;
                textures = clothes.ToArray();
                matIndex = 6;
                break;
        }
        #endregion
        #region Outside Switch
        index += dir;
        if (index < 0)
        {
            index = max - 1;
        }
        if (index > max - 1)
        {
            index = 0;
        }
        Material[] mat = character.materials;
        mat[matIndex].mainTexture = textures[index];
        character.materials = mat;
        #endregion
        #region Set Material Switch
        switch (type)
        {
            case "Skin":
                skinIndex = index;
                break;
            case "Eyes":
                eyesIndex = index;
                break;
            case "Mouth":
                mouthIndex = index;
                break;
            case "Hair":
                hairIndex = index;
                break;
            case "Armour":
                armourIndex = index;
                break;
            case "Clothes":
                skinIndex = index;
                break;
        }
        #endregion
    }
    #endregion
    #region Customizers
    public void SkinPlus()
    {
        SetTexture("Skin", 1);
    }
    public void SkinMinus()
    {
        SetTexture("Skin", -1);
    }

    public void EyesPlus()
    {
        SetTexture("Eyes", 1);
    }
    public void EyesMinus()
    {
        SetTexture("Eyes", -1);
    }

    public void MouthPlus()
    {
        SetTexture("Mouth", 1);
    }
    public void MouthMinus()
    {
        SetTexture("Mouth", -1);
    }

    public void HairPlus()
    {
        SetTexture("Hair", 1);
    }
    public void HairMinus()
    {
        SetTexture("Hair", -1);
    }

    public void ArmourPlus()
    {
        SetTexture("Armour", 1);
    }
    public void ArmourMinus()
    {
        SetTexture("Armour", -1);
    }

    public void ClothesPlus()
    {
        SetTexture("Clothes", 1);
    }
    public void ClothesMinus()
    {
        SetTexture("Clothes", -1);
    }



    #endregion
    #region CharName
    void CharName()
    {
        charName = FindObjectOfType<InputField>().textComponent.text;
    }
    #endregion
    #region Reset
    public void ResetCust()
    {
        SetTexture("Skin", skinIndex = 0);
        SetTexture("Eyes", eyesIndex = 0);
        SetTexture("Mouth", mouthIndex = 0);
        SetTexture("Hair", hairIndex = 0);
        SetTexture("Armour", armourIndex = 0);
        SetTexture("Clothes", clothesIndex = 0);
    }
    #endregion
    #region Randomize
    public void Randomize()
    {
        SetTexture("Skin", Random.Range(0, skinMax - 1));
        SetTexture("Eyes", Random.Range(0, eyesMax - 1));
        SetTexture("Mouth", Random.Range(0, mouthMax - 1));
        SetTexture("Hair", Random.Range(0, hairMax - 1));
        SetTexture("Armour", Random.Range(0, armourMax - 1));
        SetTexture("Clothes", Random.Range(0, clothesMax - 1));
    }
    #endregion
    #region Choose Class
    void ChooseClass(int className)
    {
        #region ClassStats
        switch (className)
        {
            case 0:
                stats[0] = 15;
                stats[1] = 10;
                stats[2] = 15;
                stats[3] = 5;
                stats[4] = 5;
                stats[5] = 10;
                stats[6] = 15;
                charClass = CharacterClass.Fighter;
                break;
            case 1:
                stats[0] = 5;
                stats[1] = 10;
                stats[2] = 10;
                stats[3] = 15;
                stats[4] = 15;
                stats[5] = 10;
                stats[6] = 10;
                charClass = CharacterClass.Opportunist;
                break;
            case 2:
                stats[0] = 5;
                stats[1] = 5;
                stats[2] = 5;
                stats[3] = 10;
                stats[4] = 20;
                stats[5] = 10;
                stats[6] = 5;
                charClass = CharacterClass.Researcher;
                break;
            case 3:
                stats[0] = 10;
                stats[1] = 5;
                stats[2] = 5;
                stats[3] = 20;
                stats[4] = 20;
                stats[5] = 10;
                stats[6] = 10;
                charClass = CharacterClass.Sage;
                break;
            case 4:
                stats[0] = 5;
                stats[1] = 10;
                stats[2] = 10;
                stats[3] = 5;
                stats[4] = 5;
                stats[5] = 15;
                stats[6] = 5;
                charClass = CharacterClass.Commoner;
                break;
            case 5:
                stats[0] = 15;
                stats[1] = 15;
                stats[2] = 15;
                stats[3] = 5;
                stats[4] = 5;
                stats[5] = 5;
                stats[6] = 15;
                charClass = CharacterClass.Scion;
                break;
            case 6:
                stats[0] = 20;
                stats[1] = 10;
                stats[2] = 15;
                stats[3] = 5;
                stats[4] = 10;
                stats[5] = 15;
                stats[6] = 20;
                charClass = CharacterClass.Warrior;
                break;
            case 7:
                stats[0] = 15;
                stats[1] = 10;
                stats[2] = 5;
                stats[3] = 5;
                stats[4] = 15;
                stats[5] = 5;
                stats[6] = 10;
                charClass = CharacterClass.Sharpshooter;
                break;
        }
        #endregion
    }
    #endregion
    #region SelectClass
    public void PlusClass()
    {
        selectedIndex++;
        if (selectedIndex > selectedClass.Length - 1)
        {
            selectedIndex = 0;
        }
    }
    public void MinusClass()
    {
        selectedIndex--;
        if (selectedIndex < 0)
        {
            selectedIndex = selectedClass.Length - 1;
        }
        ChooseClass(selectedIndex);
    }
    #endregion
    #region Points
    
    #endregion
    #region Save and Play
    void Play()
    {
        Save();
        SceneManager.LoadScene(2);
    }

    void Save()
    {

    }
    #endregion
}
#region CharClass
public enum CharacterClass
{
    Fighter,
    Opportunist,
    Researcher,
    Sage,
    Commoner,
    Scion,
    Warrior,
    Sharpshooter
}
#endregion
#region CharRace
public enum CharacterRace
{
    Hylian,
    Twili,
    Rito,
    Zora,
    Goron,
    Minish,
    Deku,
    Kokiri,
    Korok,
    Gerudo,
    Sheikah
}
#endregion