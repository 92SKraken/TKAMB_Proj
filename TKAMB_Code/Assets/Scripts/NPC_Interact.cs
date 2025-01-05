using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.Collections;
using System.IO.Pipes;
using Unity.VisualScripting.FullSerializer;
using System;

public class NPC_Interact : MonoBehaviour
{
    public GameObject d_template;
    public GameObject canvas;
    public GameObject speechReady;
    public DialogueCounts countScript;

    bool player_detection = false;

    public string Name;

    Dictionary<string, List<string>> actions = new Dictionary<string, List<string>>()
    {
        {"I'm spending the summer here.", new List<string>{"Talk", "Jem"}},
        {"I wonder who lives there.", new List<string>{"Talk", "Jem"}},
        {"I'm Jem and this is Scout.", new List<string>{"Follow", "Dill"}},
        {"Boo Radley lives there and he never comes out. (we should prob add more to this line)", new List<string>{"Talk", "Dill"}},
        {"I bet you won't touch it.", new List<string>{"Talk", "Jem"}},
        {"You'll see. I'll touch it.", new List<string>{"TouchHouse", "Jem"}}
    };

    Dictionary<string, string> Jem = new Dictionary<string, string>()
    {
        {"1a", "Hey Scout!"},
        {"1b", "Lets go play in the backyard"},
        {"2a", "Whose that?"},
        {"2b", "Lets move the bush to find out."},
        {"3a", "You can come play with us"},
        {"3b", "I'm Jem and this is Scout."},
        {"4a", "Thats the Radley house."},
        {"4b", "Boo Radley lives there and he never comes out. (we should prob add more to this line)"},
        {"5a", "You'll see. I'll touch it."}
    };
    Dictionary<string, string> Dill = new Dictionary<string, string>()
    {
        {"1a", "Hi! I'm Dill."},
        {"1b", "I can read."},
        {"1c", "I'm spending the summer here."},
        {"2a", "Wow that's a creepy house."},
        {"2b", "I wonder who lives there."},
        {"3a", "I bet you won't touch it."}
    };

    public PlayerMovement PlayerMovement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            player_detection = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player_detection = false;
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (player_detection && context.performed && !PlayerMovement.dialogue && speechReady.activeInHierarchy)
        {
            speechReady.SetActive(false);
            canvas.SetActive(true);
            PlayerMovement.dialogue = true;
            DialogueSetUp(Name);
        }
    }
    void NewDialogue(string text, string speaker)
    {
        GameObject template_clone = Instantiate(d_template, d_template.transform);
        template_clone.transform.parent = canvas.transform;
        template_clone.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
        template_clone.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = speaker;
    }
    void DialogueSetUp(string name)
    {
        Dictionary<string, Dictionary<string, string>> NPCS = new Dictionary<string, Dictionary<string, string>>()
        {
            {"Jem", Jem},
            {"Dill", Dill }
        };
        int count = Int32.Parse(countScript.dialogueCounts[name]);
        count += 1;
        countScript.dialogueCounts[name] = count.ToString();
        foreach (KeyValuePair<string, string> i in NPCS[name])
        {
            if (i.Key[0] == countScript.dialogueCounts[name][0])
            {
                NewDialogue(NPCS[name][i.Key], name);
                foreach (KeyValuePair<string, List<string>> x in actions)
                {
                    if (i.Value == x.Key)
                    {
                        ExecuteAction(x.Value);
                    }
                }
            }
        }
        canvas.transform.GetChild(1).gameObject.SetActive(true);
    }
    void ExecuteAction(List<string> action)
    {
        if (action[0] == "Talk")
        {
            DialogueSetUp(action[1]);
        }
        if (action[0] == "Follow")
        {
            GameObject follower = GameObject.Find(action[1]);
            follower.GetComponent<Follow>().canFollow = true;
        }
        if (action[0] == "TouchHouse")
        {
            GameObject house = GameObject.Find("RadleyHouse");
            house.GetComponent<TouchRadleyHouse>().onDialogue = true;
        }
    }
}
