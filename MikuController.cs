using UnityEngine;

public class MikuController : MonoBehaviour
{
    [Header("Components")]
    public SpriteRenderer spriteRenderer;

    [Header("Pose Sprites")]
    public Sprite idlePose;
    public Sprite leftPose;
    public Sprite rightPose;
    public Sprite upPose;
    public Sprite downPose;

    [Header("Key Controls")]
    // Change these in the inspector if your keys are different
    public KeyCode leftKey = KeyCode.LeftArrow;
    public KeyCode rightKey = KeyCode.RightArrow;
    public KeyCode upKey = KeyCode.UpArrow;
    public KeyCode downKey = KeyCode.DownArrow;

    void Start()
    {
        // Automatically find the renderer if not assigned
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    void Update()
    {
        // 1. Check Input and Assign the correct sprite
        // We use 'Else If' so she doesn't try to do two poses at once.
        
        if (Input.GetKey(leftKey))
        {
            spriteRenderer.sprite = leftPose;
        }
        else if (Input.GetKey(rightKey))
        {
            spriteRenderer.sprite = rightPose;
        }
        else if (Input.GetKey(upKey))
        {
            spriteRenderer.sprite = upPose;
        }
        else if (Input.GetKey(downKey))
        {
            spriteRenderer.sprite = downPose;
        }
        else
        {
            // 2. If NO keys are pressed, return to Idle
            spriteRenderer.sprite = idlePose;
        }
    }
}

