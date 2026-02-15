using UnityEngine;

public class NotesObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;

    // This variable will remember exactly where the button is
    private float targetYPosition; 

    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if(canBePressed)
            {
                gameObject.SetActive(false); 

                // Calculate distance based on the AUTO-DETECTED position
                float distance = Mathf.Abs(transform.position.y - targetYPosition);

                // DEBUG: This prints the math to the console so we can see what's happening
                Debug.Log("Hit Distance: " + distance);

                if (distance > 0.25f)
                {
                    GameManager.instance.Normal_Hit();
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                }
                else if (distance > 0.05f)
                {
                    GameManager.instance.Good_Hit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                }
                else 
                {
                    GameManager.instance.Perfect_Hit();
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Activator")
        {
            canBePressed = true;
            
            // HERE IS THE FIX:
            // We grab the EXACT World Position of the button we just touched.
            targetYPosition = collision.transform.position.y;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Activator" && gameObject.activeSelf)
        {
            canBePressed = false;
            GameManager.instance.Note_Missed();
            Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        }
    }
}