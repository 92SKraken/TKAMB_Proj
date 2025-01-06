using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

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
        {"Hey.", new List<string>{"Talk", "Jem"}},
        {"Hey yourself.", new List<string>{"Talk", "Dill"}},
        {"I can read.", new List<string>{"Talk", "Scout"}},
        {"So what?", new List<string>{"Talk", "Dill"}},
        {"Just thought you'd like to know I can read. You got anything needs readin' I can do it.", new List<string>{"Talk", "Jem"}},
        {"How old are you? Four and a half?", new List<string>{"Talk", "Dill"}},
        {"Goin' on seven.", new List<string>{"Talk", "Jem"}},
        {"Lord, what a name.", new List<string>{"Talk", "Dill"}},
        {"'s not any funnier'n yours. Aunt Rachel says your name's Jeremy Atticus Finch.", new List<string>{"Talk", "Jem"}},
        {"Your name's longer'n you are. Bet it's a foot longer.", new List<string>{"Talk", "Dill"}},
        {"Folks call me Dill.", new List<string>{"Follow", "Dill"}},
        {"I wonder who lives there.", new List<string>{"Talk", "Jem"}},
        {"Boo Radley lives there and he never comes out. (we should prob add more to this line)", new List<string>{"Talk", "Dill"}},
        {"I bet you won't touch it.", new List<string>{"Talk", "Jem"}},
        {"You'll see. I'll touch it.", new List<string>{"TouchHouse", "Jem"}},
        {"See you later Dill.", new List<string>{"RadleyDone", "Dill"}},
        {"Yes you … Jean louise.", new List<string>{"Talk", "Scout"}},
        {"That’s the alphabet.", new List<string>{"Talk", "Teacher"}},
        {"Don’t let your father teach you any more.", new List<string>{"Talk", "Scout"}},
        {"He hasn’t taught me anything, Miss Caroline. Atticus ain’t got time to teach me anything.", new List<string>{"Talk", "Teacher"}},
        {"Somebody did. You weren’t born reading The Mobile Register.", new List<string>{"Talk", "Scout"}},
        {"Jem says I was. He read in a book where I was a Bullfinch instead of a Finch. Jem says my name’s really Jean Louise Bullfinch, that I got swapped when I was born and I’m really a-", new List<string>{"Talk", "Teacher"}}

    };

    Dictionary<string, string> Jem = new Dictionary<string, string>()
    {
        {"0.11a", "Hey Scout!"},
        {"0.11b", "Lets go play in the backyard."},
        {"0.21a", "Whose that?"},
        {"0.21b", "Lets move the bush to find out."},
        {"0.31a", "Hey yourself."},
        {"0.41b", "How old are you? Four and a half?"},
        {"0.51a", "Shoot no wonder, then."},
        {"0.51b", "Scout yonder's been readin' ever since she was born, and she ain't even started to school yet."},
        {"0.51c", "You look right puny for goin' on seven."},
        {"0.51d", "Why don't you come over, Charles Barker Harris?"},
        {"0.51e", "Lord, what a name."},
        {"0.61a", "I'm big enough to fit mine."},
        {"0.61b", "Your name's longer'n you are. Bet it's a foot longer."},
        {"0.71a", "Thats the Radley house."},
        {"0.71b", "Boo Radley lives there and he never comes out. (we should prob add more to this line)"},
        {"0.81a", "You'll see. I'll touch it."},
        {"0.91a", "Its time to go home."},
        {"0.91b", "See you later Dill."},
        {"1.01a", "Its the first day of school."},
        {"1.01", "Let's go! Hurry up!"}
    };
    Dictionary<string, string> Dill = new Dictionary<string, string>()
    {
        {"0.11a", "Hey."},
        {"0.21b", "I'm Charles Baker Harris."},
        {"0.21c", "I can read."},
        {"0.31a", "Just thought you'd like to know I can read. You got anything needs readin' I can do it."},
        {"0.41a", "Goin' on seven."},
        {"0.51a", "'s not any funnier'n yours. Aunt Rachel says your name's Jeremy Atticus Finch."},
        {"0.61a", "Folks call me Dill."},
        {"0.71a", "Wow that's a creepy house."},
        {"0.71b", "I wonder who lives there."},
        {"0.81a", "I bet you won't touch it."}
    };
    Dictionary<string, string> Scout = new Dictionary<string, string>()
    {
        {"0.11a", "So what?"},
        {"0.21a", "That’s the alphabet."},
        {"0.31a", "Teach me?"},
        {"0.31b", "He hasn’t taught me anything, Miss Caroline. Atticus ain’t got time to teach me anything."},
        {"0.41a", "Jem says I was. He read in a book where I was a Bullfinch instead of a Finch. Jem says my name’s really Jean Louise Bullfinch, that I got swapped when I was born and I’m really a-"}
    };
    Dictionary<string, string> Teacher = new Dictionary<string, string>()
    {
        {"0.11a", "This says I am Miss Caroline Fisher. I am from North Alabama, from Winston County."},
        {"0.11b", "Does anybody know what these are?"},
        {"0.11c", "Yes you … Jean louise."},
        {"0.21a", "Don’t let your father teach you any more."},
        {"0.31a", "If he didn’t teach you, who did?"},
        {"0.31b", "Somebody did. You weren’t born reading The Mobile Register."},
        {"0.41a", "Let’s not let our imaginations run away with us, dear."},
        {"0.41b", "Now you tell your father not to teach you any more. It’s best to begin reading with a fresh mind. You tell him I’ll take over from here and try to undo the damage."},
        {"0.41c", "Go back to your seat now hun."}

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
            {"Dill", Dill },
            {"Scout", Scout},
            {"Teacher", Teacher}
        };
        List<string> executeMe = new List<string>{"", ""};
        double count = double.Parse(countScript.dialogueCounts[name]);
        count += 0.1;
        countScript.dialogueCounts[name] = count.ToString();
        foreach (KeyValuePair<string, string> npc in NPCS[name])
        {
            if (npc.Key.Substring(0, 3) == countScript.dialogueCounts[name].Substring(0, 3))
            {
                NewDialogue(NPCS[name][npc.Key], name);
                foreach (KeyValuePair<string, List<string>> action in actions)
                {
                    if (npc.Value == action.Key)
                    {
                        executeMe = action.Value;
                    }
                }
            }
        }
        if (executeMe[0] != "")
        {
            ExecuteAction(executeMe);
        }
        canvas.transform.GetChild(1).gameObject.SetActive(true);
    }
    void ExecuteAction(List<string> action)
    {
        if (action[0] == "Talk")
        {
            DialogueSetUp(action[1]);
        }
        else if (action[0] == "Follow")
        {
            GameObject follower = GameObject.Find(action[1]);
            follower.GetComponent<Follow>().canFollow = true;
        }
        else if (action[0] == "TouchHouse")
        {
            GameObject house = GameObject.Find("RadleyHouse");
            house.GetComponent<TouchRadleyHouse>().onDialogue = true;
        }
        else if (action[0] == "RadleyDone")
        {
            GameObject dill = GameObject.Find("Dill");
            dill.SetActive(false);
            GameObject door = GameObject.Find("FinchDoor");
            door.GetComponent<Sleep>().canSleep = true;
        }
    }
}
