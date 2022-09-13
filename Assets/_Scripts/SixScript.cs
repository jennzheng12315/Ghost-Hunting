using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SixScript : MonoBehaviour
{
    public AudioSource NoWay;
    public AudioSource DLYH;    // Don't Lose Your Head
    public AudioSource HoS;     // Heart of Stone
    public AudioSource GetDown;
    public AudioSource AYWD;    // All You Wanna Do
    public AudioSource IDNYL;   // I Don't Need Your Love

    public GameObject fog;

    public RawImage ghost;
    public RawImage speechBubble;
    public TextMeshProUGUI text;

    public Button next;
    public TextMeshProUGUI nextText;

    public Button CatherineA;
    public Button AnneB;
    public Button Jane;
    public Button AnneC;
    public Button Katherine;
    public Button CatherineP;

    // Locations to put speech bubble/button for each wife
    private Vector3 CatherineAVector = new Vector3(400f, 700f, 0f);
    private Vector3 AnneBVector = new Vector3(700f, 700f, 0f);
    private Vector3 JaneVector = new Vector3(1100f, 700f, 0f);
    private Vector3 AnneCVector = new Vector3(1500f, 700f, 0f);
    private Vector3 KatherineVector = new Vector3(1900f, 700f, 0f);
    private Vector3 CatherinePVector = new Vector3(2200f, 700f, 0f);

    private int textOffset = 0; // Where to put text in relation to speech bubble
    private bool fade = false;  // Should wives fade yet?
    private float alpha = 1f;   // For fading

    // Start is called before the first frame update
    void Start()
    {
        // Button onclick functions
        Button nextBtn = next.GetComponent<Button>();
        nextBtn.onClick.AddListener(OnClickNext);

        Button CatherineABtn = CatherineA.GetComponent<Button>();
        CatherineABtn.onClick.AddListener(OnClickCatherineA);

        Button AnneBBtn = AnneB.GetComponent<Button>();
        AnneBBtn.onClick.AddListener(OnClickAnneB);

        Button JaneBtn = Jane.GetComponent<Button>();
        JaneBtn.onClick.AddListener(OnClickJane);

        Button AnneCBtn = AnneC.GetComponent<Button>();
        AnneCBtn.onClick.AddListener(OnClickAnneC);

        Button KatherineBtn = Katherine.GetComponent<Button>();
        KatherineBtn.onClick.AddListener(OnClickKatherine);

        Button CatherinePBtn = CatherineP.GetComponent<Button>();
        CatherinePBtn.onClick.AddListener(OnClickCatherineP);

        ChoicesSetup(); // Move buttons beneath each wife for trivia game

        // Intro start
        text.text = "<b>Catherine of Aragon:</b> Why are you interested in this jerk? There are much better things to learn about than him.";
        nextText.text = "Next";
        text.faceColor = new Color(0, 0, 0);
        MoveToCatherineA();

        // Pause music at the beginning
        NoWay.Stop();
        DLYH.Stop();
        HoS.Stop();
        GetDown.Stop();
        AYWD.Stop();
        IDNYL.Stop();

        fog.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (fade == true)
        {
            GhostDisappear();
        }
    }

    // Makes text and button changes when Next button is clicked
    void OnClickNext()
    {
        // Intro text

        if (text.text.Equals("<b>Catherine of Aragon:</b> Why are you interested in this jerk? There are much better things to learn about than him."))
        {
            text.text = "<b>Anne Boleyn:</b> He beheaded or divorced most of us, and he never stayed loyal to his wife for long.";
            MoveToAnneB();
        }

        else if (text.text.Equals("<b>Anne Boleyn:</b> He beheaded or divorced most of us, and he never stayed loyal to his wife for long."))
        {
            text.text = "<b>Jane Seymour:</b> And yet, everyone knows *his* name.";
            MoveToJane();
        }

        else if (text.text.Equals("<b>Jane Seymour:</b> And yet, everyone knows *his* name."))
        {
            text.text = "<b>Anne of Cleves:</b> Yeah, what about us? I bet you don't even know who we are outside of our connection to Henry.";
            MoveToAnneC();
        }

        else if (text.text.Equals("<b>Anne of Cleves:</b> Yeah, what about us? I bet you don't even know who we are outside of our connection to Henry."))
        {
            text.text = "<b>Katherine Howard:</b> You know what, we challenge you to a trivia game!";
            MoveToKatherine();
        }

        else if (text.text.Equals("<b>Katherine Howard:</b> You know what, we challenge you to a trivia game!"))
        {
            text.text = "<b>Catherine Parr:</b> Great idea! We'll give you a description about one of us, and you'll have to guess who it is.";
            MoveToCatherineP();
        }

        else if (text.text.Equals("<b>Catherine Parr:</b> Great idea! We'll give you a description about one of us, and you'll have to guess who it is."))
        {
            text.text = "<b>Catherine Parr:</b> Ready to start?";
            nextText.text = "Yes!";
            MoveToCatherineP();
        }

        // Trivia Game: wives' responses

        else if (text.text.Equals("Correct! Unfortunately, I had to downplay my success for my husband's less significant victories in France so I didn't make him seem weak in front of the people or hurt his fragile ego."))
        {
            text.text = "I was beloved by the people during my regency and believed myself to be queen of England until I died, never truly considering our divorce to be real.";
            MoveToCatherineA();
        }

        else if (text.text.Equals("I was beloved by the people during my regency and believed myself to be queen of England until I died, never truly considering our divorce to be real."))
        {
            NoWay.Stop();
            text.text = "This queen became a best-selling author and encouraged female nobility to get an education. She also ruled over England while Henry was off invading France yet again and provided a stable life for his children.";
            MoveToJane();
            next.gameObject.SetActive(false);
            ChoicesAppear();
            TurnWhite();
        }

        else if (text.text.Equals("You're correct. I was the last of Henry's wives. I had already lost two husbands and was in love with Jane Seymour's younger brother when I caught Henry's eye. I married him out of duty, cared for him until his death, and then married my true love."))
        {
            text.text = "I died a year from complications from childbirth. My daughter survived, but after my husband was executed for treason, no one knows what happened to her.";
            MoveToCatherineP();
        }

        else if (text.text.Equals("I died a year from complications from childbirth. My daughter survived, but after my husband was executed for treason, no one knows what happened to her."))
        {
            IDNYL.Stop();
            text.text = "Next up, this wife recieved a generous settlement after Henry divorced her and was \"one of the most sweet, gracious and humane queens England have had.\"";
            MoveToAnneB();
            next.gameObject.SetActive(false);
            ChoicesAppear();
            TurnWhite();
        }

        else if (text.text.Equals("Ah yes, the French had said that in one of their reports. Henry married me in hopes of gaining a spare heir, but after we met, he disliked me so much he complained about my looks to everyone around him. He eventually wanted divorce, and I agreed."))
        {
            text.text = "There was no love between us, and after the rumors surrounding his last wives, I was not foolish enough to refuse him. He gave me plenty of money and called me \"beloved sister,\" which helped me secure my independence in English society for the rest of my life.";
            MoveToAnneC();
        }

        else if (text.text.Equals("There was no love between us, and after the rumors surrounding his last wives, I was not foolish enough to refuse him. He gave me plenty of money and called me \"beloved sister,\" which helped me secure my independence in English society for the rest of my life."))
        {
            GetDown.Stop();
            text.text = "I'll go next. This wife helped Henry reconcile with Mary, his daughter from his first marriage who later became the first Queen of England. She also gave him his long-desired son.";
            MoveToCatherineA();
            next.gameObject.SetActive(false);
            ChoicesAppear();
            TurnWhite();
        }

        else if (text.text.Equals("That's me. Henry married me eleven days after Anne Boleyn's death. I acted meek and demure to avoid a similar fate, and a year later, I gave him what he wanted most, a son. I was very ill during my pregnancy however, and you know what Henry said?")) 
        {
            text.text = "He told the physicians, \"If you cannot save both, at least let the child live for other wives are easily found.\" Well, he got his wish. My son survived, and I died from an infection days later. I never got to see my baby grow up and was never crowned queen.";
            MoveToJane();
        }

        else if (text.text.Equals("He told the physicians, \"If you cannot save both, at least let the child live for other wives are easily found.\" Well, he got his wish. My son survived, and I died from an infection days later. I never got to see my baby grow up and was never crowned queen."))
        {
            HoS.Stop();
            text.text = "My turn! This queen died while fighting for anti-poverty legistation and protecting monastaries from being used for the Crown's profit.";
            MoveToKatherine();
            next.gameObject.SetActive(false);
            ChoicesAppear();
            TurnWhite();
        }

        else if (text.text.Equals("That's right. However, everyone saw me as a temptress and opportunist. I highly suspect my opponent on both of these projects, Thomas Cromwell, used that to discredit me and get me arrested for adultery."))
        {
            text.text = "But the one I ultimately blame is Henry, who didn't stop my beheading despite the fact that he was so in love with me three years ago that he broke England away from the Church just to marry me.";
            MoveToAnneB();
        }

        else if (text.text.Equals("But the one I ultimately blame is Henry, who didn't stop my beheading despite the fact that he was so in love with me three years ago that he broke England away from the Church just to marry me."))
        {
            DLYH.Stop();
            text.text = "Called a \"rose without a thorn\", this queen's youth and vivacious nature drew men to her side, and she found herself in many relationships at a young age.";
            MoveToCatherineP();
            next.gameObject.SetActive(false);
            ChoicesAppear();
            TurnWhite();
        }

        else if (text.text.Equals("Yes, my first liason was with my music teacher, who took advantage of me when I was thirteen. I then fell in love with my grandmother's secretary, but that fizzled out we went our separate ways. He later used me to get a position in court."))
        {
            text.text = "Then I met Henry, who was in love with me despite our 30-year age difference. We married, but I soon fell for Henry's distant cousin, Thomas Culpeper. Henry was furious when he found out about the affair and ordered me beheaded. I was not even eighteen years old when I died.";
            MoveToKatherine();
        }

        else if (text.text.Equals("Then I met Henry, who was in love with me despite our 30-year age difference. We married, but I soon fell for Henry's distant cousin, Thomas Culpeper. Henry was furious when he found out about the affair and ordered me beheaded. I was not even eighteen years old when I died."))
        {
            AYWD.Stop();
            text.text = "That was the last one. Nice work! Thank you for taking the time to learn about who we are beyond just Henry's wives. We can now move on in peace, knowing that at least someone knows our stories.";
            MoveToCatherineA();
            next.gameObject.SetActive(false);
            ChoicesDisappear(-1);
            fade = true;
        }

        else
        {
            next.gameObject.SetActive(false);
            nextText.text = "Next";

            ChoicesAppear();

            speechBubble.rectTransform.sizeDelta = new Vector2(700, 550);
            textOffset = 90;

            text.text = "I'll go first! While Henry was busy waging war on France, this queen valiantly ruled England in his stead and led their armies to a major victory after Scotland declared war.";
            MoveToAnneC();
        }
    }

    // Makes if CatherineA button is clicked
    void OnClickCatherineA()
    {
        // Trivia game: Catherine A is correct
        if (text.text.Equals("I'll go first! While Henry was busy waging war on France, this queen valiantly ruled England in his stead and led their armies to a major victory after Scotland declared war."))
        {
            NoWay.Play();
            TurnGreen(CatherineA);
            ChoicesDisappear(0);
            next.gameObject.SetActive(true);
            text.text = "Correct! Unfortunately, I had to downplay my success for my husband's less significant victories in France so I didn't make him seem weak in front of the people or hurt his fragile ego.";
            MoveToCatherineA();
        }

        // Trivia game: Catherine A is incorrect
        else
        {
            TurnRed(CatherineA);
        }
    }

    // Makes changes if AnneB button is clicked
    void OnClickAnneB()
    {
        // Trivia game: Anne B is correct
        if (text.text.Equals("My turn! This queen died while fighting for anti-poverty legistation and protecting monastaries from being used for the Crown's profit."))
        {
            DLYH.Play();
            TurnGreen(AnneB);
            ChoicesDisappear(1);
            next.gameObject.SetActive(true);
            text.text = "That's right. However, everyone saw me as a temptress and opportunist. I highly suspect my opponent on both of these projects, Thomas Cromwell, used that to discredit me and get me arrested for adultery.";
            MoveToAnneB();
        }

        // Trivia game: Anne B is incorrect
        else
        {
            TurnRed(AnneB);
        }  
    }

    // Makes changes if Jane button is clicked
    void OnClickJane()
    {
        // Trivia game: Jane is correct
        if (text.text.Equals("I'll go next. This wife helped Henry reconcile with Mary, his daughter from his first marriage who later became the first Queen of England. She also gave him his long-desired son."))
        {
            HoS.Play();
            TurnGreen(Jane);
            ChoicesDisappear(2);
            next.gameObject.SetActive(true);
            text.text = "That's me. Henry married me eleven days after Anne Boleyn's death. I acted meek and demure to avoid a similar fate, and a year later, I gave him what he wanted most, a son. I was very ill during my pregnancy however, and you know what Henry said?";
            MoveToJane();
        }

        // Trivia game: Jane is incorrect
        else
        {
            TurnRed(Jane);
        }
    }

    // Makes changes if Anne C button is clicked
    void OnClickAnneC()
    {
        // Trivia game: Anne C is correct
        if (text.text.Equals("Next up, this wife recieved a generous settlement after Henry divorced her and was \"one of the most sweet, gracious and humane queens England have had.\""))
        {
            GetDown.Play();
            TurnGreen(AnneC);
            ChoicesDisappear(3);
            next.gameObject.SetActive(true);
            text.text = "Ah yes, the French had said that in one of their reports. Henry married me in hopes of gaining a spare heir, but after we met, he disliked me so much he complained about my looks to everyone around him. He eventually wanted divorce, and I agreed.";
            MoveToAnneC();
        }

        // Trivia Game: Anne C is incorrect
        else
        {
            TurnRed(AnneC);
        }
    }

    // Makes changes if Katherine button is clicked
    void OnClickKatherine()
    {
        // Trivia game: Katherine is correct
        if (text.text.Equals("Called a \"rose without a thorn\", this queen's youth and vivacious nature drew men to her side, and she found herself in many relationships at a young age."))
        {
            AYWD.Play();
            TurnGreen(Katherine);
            ChoicesDisappear(4);
            next.gameObject.SetActive(true);
            text.text = "Yes, my first liason was with my music teacher, who took advantage of me when I was thirteen. I then fell in love with my grandmother's secretary, but that fizzled out we went our separate ways. He later used me to get a position in court.";
            MoveToKatherine();
        }

        // Trivia game: Katherine is incorrect
        else
        {
            TurnRed(Katherine);
        }
    }

    // Makes changes if Catherine P button is clicked
    void OnClickCatherineP()
    {
        // Trivia game: Catherine P is correct
        if (text.text.Equals("This queen became a best-selling author and encouraged female nobility to get an education. She also ruled over England while Henry was off invading France yet again and provided a stable life for his children."))
        {
            IDNYL.Play();
            TurnGreen(CatherineP);
            ChoicesDisappear(5);
            next.gameObject.SetActive(true);
            text.text = "You're correct. I was the last of Henry's wives. I had already lost two husbands and was in love with Jane Seymour's younger brother when I caught Henry's eye. I married him out of duty, cared for him until his death, and then married my true love.";
            MoveToCatherineP();
        }

        // Trivia game: Catherine P is incorrect
        else
        {
            TurnRed(CatherineP);
        }
    }

    // The following 6 methods move the speech bubble, text, and next button to the wife that is speaking

    void MoveToCatherineA()
    {
        speechBubble.gameObject.transform.position = CatherineAVector;
        text.gameObject.transform.position = new Vector3(CatherineAVector.x, CatherineAVector.y + textOffset, CatherineAVector.z); ;
        next.gameObject.transform.position = new Vector3(CatherineAVector.x + 200, CatherineAVector.y - 80 - textOffset, CatherineAVector.z);
    }

    void MoveToAnneB()
    {
        speechBubble.gameObject.transform.position = AnneBVector;
        text.gameObject.transform.position = new Vector3(AnneBVector.x, AnneBVector.y + textOffset, AnneBVector.z); ;
        next.gameObject.transform.position = new Vector3(AnneBVector.x + 200, AnneBVector.y - 80 - textOffset, AnneBVector.z);
    }

    void MoveToJane()
    {
        speechBubble.gameObject.transform.position = JaneVector;
        text.gameObject.transform.position = new Vector3(JaneVector.x, JaneVector.y + textOffset, JaneVector.z);
        next.gameObject.transform.position = new Vector3(JaneVector.x + 200, JaneVector.y - 80 - textOffset, JaneVector.z);
    }

    void MoveToAnneC()
    {
        speechBubble.gameObject.transform.position = AnneCVector;
        text.gameObject.transform.position = new Vector3(AnneCVector.x, AnneCVector.y + textOffset, AnneCVector.z);
        next.gameObject.transform.position = new Vector3(AnneCVector.x + 200, AnneCVector.y - 80 - textOffset, AnneCVector.z);
    }

    void MoveToKatherine()
    {
        speechBubble.gameObject.transform.position = KatherineVector;
        text.gameObject.transform.position = new Vector3(KatherineVector.x, KatherineVector.y + textOffset, KatherineVector.z); ;
        next.gameObject.transform.position = new Vector3(KatherineVector.x + 200, KatherineVector.y - 80 - textOffset, KatherineVector.z);
    }

    void MoveToCatherineP()
    {
        speechBubble.gameObject.transform.position = CatherinePVector;
        text.gameObject.transform.position = new Vector3(CatherinePVector.x, CatherinePVector.y + textOffset, CatherinePVector.z);
        next.gameObject.transform.position = new Vector3(CatherinePVector.x + 200, CatherinePVector.y - 80 - textOffset, CatherinePVector.z);
    }

    // Moves each wife's button to the correct location
    void ChoicesSetup()
    {
        CatherineA.gameObject.transform.position = new Vector3(CatherineAVector.x - 250, CatherineAVector.y - 625, CatherineAVector.z);
        AnneB.gameObject.transform.position = new Vector3(AnneBVector.x - 225, AnneBVector.y - 625, AnneBVector.z);
        Jane.gameObject.transform.position = new Vector3(JaneVector.x - 300, JaneVector.y - 625, JaneVector.z);
        AnneC.gameObject.transform.position = new Vector3(AnneCVector.x - 250, AnneCVector.y - 625, AnneCVector.z);
        Katherine.gameObject.transform.position = new Vector3(KatherineVector.x - 250, KatherineVector.y - 625, KatherineVector.z);
        CatherineP.gameObject.transform.position = new Vector3(CatherinePVector.x - 250, CatherinePVector.y - 625, CatherinePVector.z);

        // make choices disappear for now
        ChoicesDisappear(-1);
    }

    // Turn the Button b green to indicate a correct choice
    void TurnGreen(Button b)
    {
        ColorBlock cb = b.colors;
        cb.normalColor = new Color32(0, 255, 0, 200);
        cb.highlightedColor = new Color32(0, 255, 0, 200);
        cb.pressedColor = new Color32(0, 255, 0, 200);
        cb.selectedColor = new Color32(0, 255, 0, 200);
        b.colors = cb;
    }

    // Turn the Button b red to indicate an incorrect choice
    void TurnRed(Button b)
    {
        ColorBlock cb = b.colors;
        cb.normalColor = new Color32(255, 0, 0, 200);
        cb.highlightedColor = new Color32(255, 0, 0, 200);
        cb.pressedColor = new Color32(255, 0, 0, 200);
        cb.selectedColor = new Color32(255, 0, 0, 200);
        b.colors = cb;
    }

    // Reset all buttons to white color
    void TurnWhite()
    {
        Button[] btnArr = { CatherineA, AnneB, Jane, AnneC, Katherine, CatherineP };
        for (int i = 0; i < btnArr.Length; i++)
        {
            ColorBlock cb = btnArr[i].colors;
            cb.normalColor = new Color32(255, 255, 255, 230);
            cb.highlightedColor = new Color32(255, 255, 255, 255);
            cb.pressedColor = new Color32(255, 255, 255, 255);
            cb.selectedColor = new Color32(255, 255, 255, 255);
            btnArr[i].colors = cb;
        }
    }

    // Make all wives choices disappear except for Button at index n
    void ChoicesDisappear(int n)
    {
        Button[] btnArr = { CatherineA, AnneB, Jane, AnneC, Katherine, CatherineP };
        for (int i = 0; i<btnArr.Length; i++)
        {
            if (n != i)
            {
                btnArr[i].gameObject.SetActive(false);
            }
        }
    }

    void ChoicesAppear()
    {
        Button[] btnArr = { CatherineA, AnneB, Jane, AnneC, Katherine, CatherineP };
        for (int i = 0; i < btnArr.Length; i++)
        {
                btnArr[i].gameObject.SetActive(true);
        }
    }

    void GhostDisappear()
    {
        alpha -= 0.001f;
        Color currColor = ghost.color;
        currColor.a = alpha;
        ghost.color = currColor;

        currColor = speechBubble.color;
        currColor.a = alpha;
        speechBubble.color = currColor;

        if (alpha < 0)
        {
            text.gameObject.SetActive(false);
            fog.SetActive(false);
        }
        else
            text.faceColor = new Color(0, 0, 0, alpha);
    }
}
