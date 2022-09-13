using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class StartToARScene : MonoBehaviour
{
    public TextMeshProUGUI ghostText;
    public TextMeshProUGUI huntingText;
    public TextMeshProUGUI fairuse;
    public TextMeshProUGUI sourcesText;

    public Button start;
    public Button sources;
    public Button back;
    public RawImage ghost;

    public TextMeshProUGUI intro1;
    public TextMeshProUGUI intro2;
    public TextMeshProUGUI intro3;
    public Button play;
    public TextMeshProUGUI playText;

    private float alpha = 0f;

    void Start()
    {
        // Make starting scene stuff visible
        ghostText.gameObject.SetActive(true);
        huntingText.gameObject.SetActive(true);
        fairuse.gameObject.SetActive(true);
        start.gameObject.SetActive(true);
        sources.gameObject.SetActive(true);
        ghost.gameObject.SetActive(true);

        // Make intro stuff invisible
        intro1.gameObject.SetActive(false);
        intro2.gameObject.SetActive(false);
        intro3.gameObject.SetActive(false);
        play.gameObject.SetActive(false);
        playText.gameObject.SetActive(false);

        // Start off with 0 alpha for intro stuff
        intro1.faceColor = new Color(255, 255, 255, alpha);
        intro2.faceColor = new Color(255, 255, 255, alpha);
        intro3.faceColor = new Color(255, 255, 255, alpha);
        playText.faceColor = new Color(0, 0, 0, alpha);
        ColorBlock cb = play.colors;
        cb.normalColor = new Color(255, 255, 255, alpha);
        play.colors = cb;

        // Make Sources stuff invisible
        sourcesText.gameObject.SetActive(false);
        back.gameObject.SetActive(false);
    }

    public void playGame()
    {
        // Switch scenes
        SceneManager.LoadScene("ARScene");
    }

    public void showSources()
    {
        // Turn off starting scene stuff
        ghostText.gameObject.SetActive(false);
        huntingText.gameObject.SetActive(false);
        fairuse.gameObject.SetActive(false);
        start.gameObject.SetActive(false);
        sources.gameObject.SetActive(false);
        ghost.gameObject.SetActive(false);

        // Turn on Sources stuff
        sourcesText.gameObject.SetActive(true);
        back.gameObject.SetActive(true);
    }

    public void onClickBack()
    {
        // Make Sources stuff invisible
        sourcesText.gameObject.SetActive(false);
        back.gameObject.SetActive(false);

        // Turn on starting scene stuff
        ghostText.gameObject.SetActive(true);
        huntingText.gameObject.SetActive(true);
        fairuse.gameObject.SetActive(true);
        start.gameObject.SetActive(true);
        sources.gameObject.SetActive(true);
        ghost.gameObject.SetActive(true);


    }

    public void startIntro()
    {
        // Make starting scene stuff invisible
        ghostText.gameObject.SetActive(false);
        huntingText.gameObject.SetActive(false);
        fairuse.gameObject.SetActive(false);
        start.gameObject.SetActive(false);
        sources.gameObject.SetActive(false);
        ghost.gameObject.SetActive(false);

        // Timed entrances of all text clusters and play button
        StartCoroutine(Intro());

    }
    
    IEnumerator Intro()
    {
        intro1.gameObject.SetActive(true);

        // Fade in
        alpha = 0;
        while (alpha < 1f)
        {
            alpha += 0.01f;
            intro1.faceColor = new Color(255, 255, 255, alpha);
            yield return new WaitForSeconds(0.001f);
        }

        yield return new WaitForSeconds(5);

        intro2.gameObject.SetActive(true);

        // Fade in
        alpha = 0;
        while (alpha < 1f)
        {
            alpha += 0.01f;
            intro2.faceColor = new Color(255, 255, 255, alpha);
            yield return new WaitForSeconds(0.001f);
        }

        yield return new WaitForSeconds(5);

        intro3.gameObject.SetActive(true);

        // Fade in
        alpha = 0;
        while (alpha < 1f)
        {
            alpha += 0.01f;
            intro3.faceColor = new Color(255, 255, 255, alpha);
            yield return new WaitForSeconds(0.001f);
        }

        yield return new WaitForSeconds(3);

        play.gameObject.SetActive(true);
        playText.gameObject.SetActive(true);

        // Fade in
        alpha = 0;
        while (alpha < 1f)
        {
            alpha += 0.01f;
            playText.faceColor = new Color(0, 0, 0, alpha);
            ColorBlock cb = play.colors;
            cb.normalColor = new Color(255, 255, 255, alpha);
            play.colors = cb;
            yield return new WaitForSeconds(0.001f);
        }
    }
}
