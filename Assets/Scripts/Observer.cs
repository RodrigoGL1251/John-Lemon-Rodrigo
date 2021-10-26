using UnityEngine;

public class Observer : MonoBehaviour
{    
    public Transform player;
    public GameEnding gameEnding;

    bool m_IsPlayerInRange = false;   

    // Update is called once per frame
    void Update()
    {

        CheckVisualField();

    }

    void CheckVisualField ()
    {

        if(m_IsPlayerInRange)
        {

            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if(Physics.Raycast(ray, out raycastHit))
            {

                if(raycastHit.collider.transform == player)
                {

                    gameEnding.CaugthPlayer(); 

                }

            }

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform == player)
        {

            m_IsPlayerInRange = true;
            Debug.Log("esta en el rango");

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform == player)
        {

            m_IsPlayerInRange = false;
            Debug.Log("ya no esta en el rango");

        }
    }

}
