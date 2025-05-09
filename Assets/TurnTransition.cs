using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnTransition : MonoBehaviour
{
    public Image fadeScreen;
    public TMP_Text[] fadeTexts;
    public TMP_Text upkeepText;
    public TMP_Text moneyText;
    public float fadeTime = 1.0f;

    public void StartTransition()
    {
        StartCoroutine(HandleTurnTransition());
    }

    private IEnumerator HandleTurnTransition()
    {
        upkeepText.text = "";
        moneyText.text = "";
        
        yield return StartCoroutine(Fade(0f, 1f));
        
        yield return StartCoroutine(FadeTexts(0f, 1f));

        upkeepText.text = GameManager.instance.getUpkeepCost().ToString();

        moneyText.text = GameManager.instance.playerInventory.getResource(ResourceType.Money).ToString() + "-" + upkeepText.text;

        GameManager.instance.resetPlayer();
        
        yield return new WaitForSeconds(4.0f);
        
        moneyText.gameObject.SetActive(false);
        upkeepText.gameObject.SetActive(false);

        yield return StartCoroutine(FadeTexts(1.0f, 0.0f));

        yield return StartCoroutine(Fade(1.0f, 0.0f));
        
        GameManager.instance.StartTurn();
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0;
        Color color = fadeScreen.color;

        while (elapsedTime < fadeTime)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeTime);
            color.a = alpha;
            fadeScreen.color = color;
            yield return null;
        }
        
        color.a = endAlpha;
        fadeScreen.color = color;
    }

    private IEnumerator FadeTexts(float startAlpha, float endAlpha)
    {
        foreach (var text in fadeTexts)
        {
            float elapsedTime = 0;
            Color color = text.color;

            while (elapsedTime < fadeTime)
            {
                elapsedTime += Time.deltaTime;
                float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeTime);
                color.a = alpha;
                text.color = color;
                yield return null;
            }
        
            color.a = endAlpha;
            text.color = color;
        }
    }
    
}
