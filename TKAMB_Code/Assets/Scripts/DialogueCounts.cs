using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCounts : MonoBehaviour
{
    public Dictionary<string, string> dialogueCounts = new Dictionary<string, string>()
    {
        {"Jem", "0.01"},
        {"Dill", "0.01"}
    };
    public string jemCount = "0";
    public string dillCount = "0";
    private void Update()
    {
        jemCount = dialogueCounts["Jem"];
        dillCount = dialogueCounts["Dill"];
    }
}
