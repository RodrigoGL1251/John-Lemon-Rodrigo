using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;

    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public CanvasGroup caughtBackgroundImageCanvasGroupe;
    public AudioSource exitAudio;
    public AudioSource caugthAudio;
        
    bool m_IsPlayerAtExit;
    bool m_IsPlayeCaught;
    bool m_HasAudioPlayed;
    float m_timer;

    public Button buttonReload;
    public Button buttonNext;
    public Button buttonMenuScene;

    int m_Scene;

    private void Start()
    {
        m_Scene = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if (m_IsPlayeCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroupe, true, caugthAudio);
        } 

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    public void CaugthPlayer()
    {
        m_IsPlayeCaught = true;
    }

    void EndLevel(CanvasGroup imageCanvasGroupe, bool doRestar, AudioSource audioSource)
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<AudioSource>().enabled = false;
        player.GetComponent<Animator>().enabled = false;

        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }

        m_timer += Time.deltaTime;
        imageCanvasGroupe.alpha = m_timer / fadeDuration;

        if ((m_timer > (fadeDuration + displayImageDuration)))
        {
            if(doRestar )
            {
                buttonMenuScene.gameObject.SetActive(true);
                buttonReload.gameObject.SetActive(true);
            }
            else
            {
                buttonMenuScene.gameObject.SetActive(true);
                buttonReload.gameObject.SetActive(true);

                if(m_Scene != SceneManager.sceneCountInBuildSettings + 1)
                {
                    buttonNext.gameObject.SetActive(true);
                }
            }
        }
    }
}
