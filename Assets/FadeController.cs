using UnityEngine;
using System.Collections;
using DG.Tweening;

public class FadeController : MonoBehaviour
{
    public SpriteRenderer blackSprite;
    public float waitTime;
    public float fadeOutTime;
    public bool goToPlayScene;
    public bool goToTitleScene;

    private float fadeOutNowTime = 0.0f;

    private bool fadeOut = false;

    private float alpha = 0.0f;

    private void Start()
    {
        FadeIn();
    }

    public void FadeOut()
    {
        if (goToPlayScene)
        {
            blackSprite.DOFade(1.0f, fadeOutTime).OnComplete(Scene.Instance.GoToPlayScene);
            return;
        }

        if (goToTitleScene)
        {
            blackSprite.DOFade(1.0f, fadeOutTime).OnComplete(Scene.Instance.GoToTitleScene);
            return;
        }

        blackSprite.DOFade(1.0f, fadeOutTime);

    }

    public void FadeIn()
    {
        blackSprite.DOFade(0.0f, 5.0f);
    }

    private void Update()
    {
        if (fadeOutNowTime < waitTime)
        {
            fadeOutNowTime += Time.deltaTime;
            return;
        }

        if (!fadeOut)
        {
            fadeOut = true;
            FadeOut();
        }

    }
}
