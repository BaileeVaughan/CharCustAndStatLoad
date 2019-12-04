using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//you will need to change Scenes
using UnityEngine.SceneManagement;
public class CustomisationGet : MonoBehaviour {

    [Header("Character")]
    //public variable for the Skinned Mesh Renderer which is our character reference
    public Renderer charMesh;
    public string playerName;
    public string playerClass;
    public string playerRace;
    public int[] stats;
    public string[] statArray;

    public Text[] statText;
    public Text nameText;
    public Text classText;
    public Text raceText;

    public int skin, eyes, mouth, hair, clothes, armour;
    #region Start
    private void Start()
    {
        statArray = new string[] { "Power", "Dexterity", "Constitution", "Wisdom", "Intelligence", "Charisma", "Courage" }; //stats
        stats = new int[7];
        //our character reference connected to the Skinned Mesh Renderer via finding the Mesh
        charMesh = GameObject.Find("Mesh").GetComponent<SkinnedMeshRenderer>();
        //Run the function LoadTexture
        LoadTexture();

        for (int i = 0; i < 7; i++)
        {
            statText[i].text = statArray[i] + ": " + stats[i];
        }
        nameText.text = "Name: " + playerName;
        classText.text = "Class: " + playerClass;
        raceText.text = "Race: " + playerRace;
    }
    #endregion

    #region LoadTexture Function
    void LoadTexture()
    {
        DataToSave data = SaveSystem.LoadPlayer();
        SetTexture("Skin", data.skinIndex);
        skin = data.skinIndex;
        SetTexture("Eyes", data.eyesIndex);
        eyes = data.eyesIndex;
        SetTexture("Mouth", data.mouthIndex);
        mouth = data.mouthIndex;
        SetTexture("Hair", data.hairIndex);
        hair = data.hairIndex;
        SetTexture("Armour", data.armourIndex);
        armour = data.armourIndex;
        SetTexture("Clothes", data.clothesIndex);
        clothes = data.clothesIndex;
        playerName = data.charName;  
        stats = data.stats;
        playerClass = data.selectedClass;
        playerRace = data.selectedRace;        
    }
    #endregion
    #region SetTexture
    //Create a function that is called SetTexture it should contain a string and int
    public void SetTexture(string type, int dir)  //the string is the name of the material we are editing, the int is the direction we are changing
    {
        //we need variables that exist only within this function
        //these are int material index and Texture2D array of textures
        Texture2D tex = null;
        int matIndex = 0;

        //inside a switch statement that is swapped by the string name of our material
        switch (type)
        {
            //case skin      
            case "Skin":
                //textures is our Resource.Load Character Skin save index we loaded in set as our Texture2D
                tex = Resources.Load("Character/Skin_" + dir.ToString()) as Texture2D;
                //material index element number is 1
                matIndex = 1;
                //break
                break;
            case "Eyes":
                //textures is our Resource.Load Character save index we loaded in set as our Texture2D
                tex = Resources.Load("Character/Eyes_" + dir.ToString()) as Texture2D;
                //material index element number
                matIndex = 3;
                //break
                break;
            case "Mouth":
                //textures is our Resource.Load Character save index we loaded in set as our Texture2D
                tex = Resources.Load("Character/Mouth_" + dir.ToString()) as Texture2D;
                //material index element number
                matIndex = 2;
                //break
                break;
            case "Hair":
                //textures is our Resource.Load Character save index we loaded in set as our Texture2D
                tex = Resources.Load("Character/Hair_" + dir.ToString()) as Texture2D;
                //material index element number
                matIndex = 4;
                //break
                break;
            case "Armour":
                //textures is our Resource.Load Character save index we loaded in set as our Texture2D
                tex = Resources.Load("Character/Armour_" + dir.ToString()) as Texture2D;
                //material index element number
                matIndex = 5;
                //break
                break;
            case "Clothes":
                //textures is our Resource.Load Character save index we loaded in set as our Texture2D
                tex = Resources.Load("Character/Clothes_" + dir.ToString()) as Texture2D;
                //material index element number
                matIndex = 6;
                //break
                break;
        }
        //Material array is equal to our characters material list
        Material[] mats = charMesh.materials;
        //our material arrays current material index's main texture is equal to our texture arrays current index
        mats[matIndex].mainTexture = tex;
        //our characters materials are equal to the material array
        charMesh.materials = mats;
    }
    #endregion
}
