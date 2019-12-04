using System.Security.Cryptography.X509Certificates;
using UnityEngine.Networking;
using System.Net.Security;
using System.Collections;
using System.Net.Mail;
using UnityEngine.UI;
using UnityEngine;
using System.Net;

public class SaveStats : MonoBehaviour
{
    public int skin, eyes, mouth, hair, armour, clothes, power;
    public int dexterity, constitution, wisdom, intelligence, charisma, courage, charClass, charRace;
    public string charName;

    public CustomisationGet custSet;

    public void Save()
    {
        name = custSet.nameText.text;
        skin = custSet.skin;
        eyes = custSet.eyes;
        mouth = custSet.mouth;
        hair = custSet.hair;
        armour = custSet.armour;
        clothes = custSet.clothes;
        power = custSet.stats[0];
        dexterity = custSet.stats[1];
        constitution = custSet.stats[2];
        wisdom = custSet.stats[3];
        intelligence = custSet.stats[4];
        charisma = custSet.stats[5];
        courage = custSet.stats[6];
        charClass = 0;
        charRace = 0;
        StartCoroutine(SaveCharStats());
    }

    IEnumerator SaveCharStats() //Used save char stats
    {
        string createUserURL = "http://localhost/nsirpg/UserLogin.php";
        WWWForm form = new WWWForm();
        form.AddField("skin", skin);
        form.AddField("eyes", eyes);
        form.AddField("mouth", mouth);
        form.AddField("hair", hair);
        form.AddField("armour", armour);
        form.AddField("clothes", clothes);
        form.AddField("power", power);
        form.AddField("dexterity", dexterity);
        form.AddField("constitution", constitution);
        form.AddField("wisdom", wisdom);
        form.AddField("intelligence", intelligence);
        form.AddField("charisma", charisma);
        form.AddField("courage", courage);
        form.AddField("charClass", charClass);
        form.AddField("charRace", charRace);
        form.AddField("charName", name);
        UnityWebRequest webRequest = UnityWebRequest.Post(createUserURL, form);
        yield return webRequest.SendWebRequest();
        Debug.Log(webRequest.downloadHandler.text);
    }
}
