using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Skin
{
    public string head;
    public string torso;
    public string upperArmL;
    public string lowerArmL;
    public string handL;
    public string thighL;
    public string calfL;
    public string footL;
    public string upperArmR;
    public string lowerArmR;
    public string handR;
    public string thighR;
    public string calfR;
    public string footR;

    public static Skin CreateFromJSON(TextAsset jsonString)
    {
        return JsonUtility.FromJson<Skin>(jsonString.text);
    }

    public List<string> GetAllKeys()
    {
        return new()
        {
            head,
            torso,
            upperArmL,
            upperArmR,
            thighL,
            thighR,
            lowerArmL,
            lowerArmR,
            handL,
            handR,
            footL,
            footR,
            calfL,
            calfR
        };

    }
}
