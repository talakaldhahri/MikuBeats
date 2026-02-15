using UnityEngine;

public class Button_Controller : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    public Sprite pressedSprite;
    public Sprite unpressedSprite;

    public KeyCode KeyToPress;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyToPress))
        {
            spriteRenderer.sprite = pressedSprite;
        }
        if(Input.GetKeyUp(KeyToPress)){
            spriteRenderer.sprite = unpressedSprite;
        }
    }
}
