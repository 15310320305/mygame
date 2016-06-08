using UnityEngine;
using System.Collections;
public enum FadeStatus
{
	FadeIn,
	FadeWaiting,
	FadeOut
}
public class LHSplashScreens : MonoBehaviour 
{
	public string levelToLoad;
	public bool waitForInput;
	public float timeFadingInFinished;
	public Sprite splashSprite;
	private float m_fadeSpeed;
	private float m_waitTime;
	private float m_alpha;
	private FadeStatus m_status;
	private SpriteRenderer m_splashSpriteRenderer;
	public LHSplashScreens()
	{
		levelToLoad = "";
		m_fadeSpeed = 0.3f;
		m_waitTime = 0.5f;
		m_status = FadeStatus.FadeIn;
	}
	void Awake()
	{
		Application.targetFrameRate = 60;
	}
	// Use this for initialization
	void Start () 
	{
		if (Application.levelCount <= 1 || levelToLoad == "")
		{
			Debug.LogWarning("Invalid levelToLoad value.");
		}
		GameObject m_splashSpriteGO = new GameObject("SplashSprite");
		m_splashSpriteGO.AddComponent<SpriteRenderer>();
		m_splashSpriteRenderer = m_splashSpriteGO.GetComponent<SpriteRenderer>();
		m_splashSpriteRenderer.sprite = splashSprite;
		Transform m_splashSpriteTransform = m_splashSpriteGO.gameObject.transform;
		m_splashSpriteTransform.position = new Vector2(0f, 0f);
		m_splashSpriteTransform.parent = this.transform;
	}
	// Update is called once per frame
	void Update () 
	{
		FadeStatus fadeStatus = m_status;
		if (fadeStatus == FadeStatus.FadeIn)
		{
			m_alpha += m_fadeSpeed * Time.deltaTime;
		}
		else if (fadeStatus == FadeStatus.FadeWaiting)
		{
			if ((!waitForInput && Time.time >= timeFadingInFinished + m_waitTime) || (waitForInput && Input.anyKey))
			{
				m_status = FadeStatus.FadeOut;
			}
		}
		else if (fadeStatus == FadeStatus.FadeOut)
		{
			m_alpha -= m_fadeSpeed * Time.deltaTime;
		}
		UpdateSplashAlpha();
	}
	private void UpdateSplashAlpha()
	{
		if (m_splashSpriteRenderer != null)
		{
			Color spriteColor = m_splashSpriteRenderer.material.color;
			spriteColor.a = m_alpha;
			m_splashSpriteRenderer.material.color = spriteColor;
			if (m_alpha > 1f)
			{
				m_status = FadeStatus.FadeWaiting;
				timeFadingInFinished = Time.time;
				m_alpha = 1f;
			}
			if (m_alpha < 0)
			{
				if (Application.levelCount >= 1 && levelToLoad != "")
				{
					Application.LoadLevel(levelToLoad);
				}
			}
		}
	}
}