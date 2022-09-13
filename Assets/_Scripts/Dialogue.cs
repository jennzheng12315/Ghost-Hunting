using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI button1Component;
    public TextMeshProUGUI button2Component;

    public Button button1;
    public Button button2;

    // Start is called before the first frame update
    void Start()
    {
        Button btn1 = button1.GetComponent<Button>();
        btn1.onClick.AddListener(OnClick1);

        Button btn2 = button2.GetComponent<Button>();
        btn2.onClick.AddListener(OnClick2);

        textComponent.text = "You know, everyone seems to know about George Washington, Lafayette, all the famous generals who led us to victory. But what about us ordinary people, who worked behind the scenes?";
        textComponent.faceColor = new Color(0, 0, 0);
        button1Component.text = "What do you mean?";
        button2Component.text = "Who are you?";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClick1()
    {
        // From starting options
        if (button1Component.text.Equals("What do you mean?")) 
        {
            textComponent.text = "Well, how much do you know about the regular soldiers who fought for this country, the spies who risked thier lives, or the women who cooked and took care of the wounded?";
            button1Component.text = "Not much";
            button2Component.text = "I know some.";
        }

        // From "how much do you know..."
        else if (button1Component.text.Equals("Not much"))
        {
            textComponent.text = "Well, why don't I tell you a bit about my story then? My name is James Armistead Lafayette. I was an enslaved man-turned-spy for the Marquis de Lafayette.";
            button1Component.text = "How did you become a spy?";
            button2Component.text = "How did you infiltrate the British army?";
        }

        // From "who are you" and "why don't I tell you a bit about my story..."
        else if (button1Component.text.Equals("How did you become a spy?"))
        {
            textComponent.text = "I met Lafayette at the store where my master managed Virginia's military supplies. He invited me to join him, and though I didn't trust the Americans or the British to grant me my freedom after the war, I did trust him. So I accepted.";
            button1Component.text = "Did you get any valuable information as a spy?";
            button2Component.text = "How did you infiltrate the British army?";
        }

        // From "do you know who I am"
        else if (button1Component.text.Equals("Yes."))
        {
            textComponent.text = "I'm glad to hear that! Please let me know if you have any questions.";
            button1Component.text = "How did you become a spy?";
            button2Component.text = "How did you infiltrate the British army?";
        }

        // From "I met Lafayette..." and "How did you infiltrate the British"
        else if (button1Component.text.StartsWith("Did you get any valuable information"))
        {
            textComponent.text = "I did. One piece of intel had warned Lafayette and Washington that 10,000 British troops were headed to Yorktown. Our troops set up a blockade to stop them, and after 3 weeks of fighting, the British surrendered. We won the war!";
            button1Component.text = "What did you do after the war?";
            button2Component.text = "Do you still have any of the messages you sent as a spy?";
        }

        // From Yorktown part and infilitrate army part
        else if (button1Component.text.Equals("What did you do after the war?"))
        {
            textComponent.text = "I was forced to return to slavery since I was not a soldier, but I petitioned Congress and with Lafayette's help, I finally recieved my freedom. I took Lafayette's name as a thank you, became a farmer, and raised a large family for the rest of my life.";
            button1Component.text = "Do you still have any of the messages you sent as a spy?";
            button2.gameObject.SetActive(false);
        }

        // From after war part - Ending dialogue for user's task
        else if (button2Component.text.Equals("Do you still have any of the messages you sent as a spy?"))
        {
            textComponent.text = "I do in fact. I've been looking a draft that I left lying somewhere around here. If you can find it, I would appreciate that.";
            button1.gameObject.SetActive(false);
            button2.gameObject.SetActive(false);
        }
    }

    void OnClick2()
    {
        // From starting options or "...do you know who I am"
        if (button2Component.text.Equals("Who are you?") || button2Component.text.Equals("No."))
        {
            textComponent.text = "I'm James Armistead Lafayette. I was an enslaved man-turned-spy for the Marquis de Lafayette.";
            button1Component.text = "How did you become a spy?";
            button2Component.text = "How did you infiltrate the British army?";
        }

        // From "how much do you know..."
        else if (button2Component.text.Equals("I know some."))
        {
            textComponent.text = "Good. It seems as if more of our stories are being told these days. Do you know who I am?";
            button1Component.text = "Yes.";
            button2Component.text = "No.";
        }

        // From several other branches
        else if (button2Component.text.Equals("How did you infiltrate the British army?"))
        {
            textComponent.text = "I posed as a loyal runaway slave in Benedict Arnold's army and gained access to their headquarters. As a black man, I was often treated as invisible by white officers, allowing me to easily overhear their plans and travel between camps.";
            button1Component.text = "Did you get any valuable information?";
            button2Component.text = "What did you do after the war?";
        }

        // From after war part - Ending dialogue for user's task
        else if (button2Component.text.Equals("Do you still have any of the messages you sent as a spy?"))
        {
            textComponent.text = "I do in fact. I have a draft lying around here somewhere. If you can find it, I would appreciate that.";
            button1.gameObject.SetActive(false);
            button2.gameObject.SetActive(false);
        }
    }

}
