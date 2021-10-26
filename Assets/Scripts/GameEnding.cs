using UnityEngine;
using UnityEngine.SceneManagement;

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

                SceneManager.LoadScene(0);

            }
            else
            {

                Application.Quit();

            }

        }

    }

}
