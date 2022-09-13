using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SecretMessage : MonoBehaviour
{
    private float alpha;

    public TextMeshPro text;
    public GameObject candle;
    public RawImage ghost;
    public RawImage speechBubble;
    public TextMeshProUGUI speech;
    public GameObject fog;

    private float GhostAlpha;

    void Start()
    {
        // secret message is invisible
        alpha = 0f;
        text.faceColor = new Color(0, 0, 0, alpha);

        // No ghost yet
        GhostAlpha = 1f;
        ghost.gameObject.SetActive(false);
        speechBubble.gameObject.SetActive(false);
        speech.gameObject.SetActive(false);
        fog.SetActive(false);
    }

    void Update()
    {
        text.faceColor = new Color(0, 0, 0, alpha);

        // candle is in bottom portion of image target
        if (candle.transform.position.x > text.transform.position.x - 0.15
            && candle.transform.position.x < text.transform.position.x + 0.15
            && candle.transform.position.z > text.transform.position.z - 0.2
            && candle.transform.position.z < text.transform.position.z + 0.02)
        {
            alpha += 0.005f;    // make secret message fade in
        }

        // secret message fully visible --> ghost can now move on
        if (alpha >= 1)
        {
            Ghost();    // Make ghost appear

            // Fade away ghost, speech bubble, and text 
            Color currColor = ghost.color;
            currColor.a = GhostAlpha;
            ghost.color = currColor;

            currColor = speechBubble.color;
            currColor.a = GhostAlpha;
            speechBubble.color = currColor;

            if (GhostAlpha < 0)
            {
                speech.gameObject.SetActive(false);
                fog.SetActive(false);
            } 
            else 
                speech.faceColor = new Color(0, 0, 0, GhostAlpha);
        }
    }

    void Ghost()
    {
        GhostAlpha -= 0.001f;
        ghost.gameObject.SetActive(true);
        speechBubble.gameObject.SetActive(true);
        speech.gameObject.SetActive(true);
        fog.SetActive(true);
    }
}
