using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCounts : MonoBehaviour
{
    public Dictionary<string, string> dialogueCounts = new Dictionary<string, string>()
    {
        {"Jem", "0.01"},
        {"Dill", "0.01"},
        {"Scout", "0.01"},
        {"Teacher", "0.01"}
    };
    public string jemCount = "0.01";
    public string dillCount = "0.01";
    public string scoutCount = "0.01";
    public string teacherCount = "0.01";

    private void Start()
    {
        dialogueCounts["Jem"] = jemCount;
        dialogueCounts["Dill"] = dillCount;
        dialogueCounts["Scout"] = scoutCount;
        dialogueCounts["Teacher"] = teacherCount;
    }
    private void Update()
    {
        jemCount = dialogueCounts["Jem"];
        dillCount = dialogueCounts["Dill"];
        scoutCount = dialogueCounts["Scout"];
        teacherCount = dialogueCounts["Teacher"];
    }
}
