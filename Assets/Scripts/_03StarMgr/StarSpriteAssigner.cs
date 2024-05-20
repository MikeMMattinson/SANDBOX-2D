using UnityEngine;

public class StarSpriteAssigner : MonoBehaviour
{
    public Sprite OTypeSprite;
    public Sprite BTypeSprite;
    public Sprite ATypeSprite;
    public Sprite FTypeSprite;
    public Sprite GTypeSprite;
    public Sprite KTypeSprite;
    public Sprite MTypeSprite;

    private new SpriteRenderer renderer;

    void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        Debug.Log($"{this}_______StarSpriteAssigner");
    }

    public void AssignSpriteBasedOnClassification(string spectralType)
    {
        switch (spectralType)
        {
            case "O":
                renderer.sprite = OTypeSprite;
                break;
            case "B":
                renderer.sprite = BTypeSprite;
                break;
            case "A":
                renderer.sprite = ATypeSprite;
                break;
            case "F":
                renderer.sprite = FTypeSprite;
                break;
            case "G":
                renderer.sprite = GTypeSprite;
                break;
            case "K":
                renderer.sprite = KTypeSprite;
                break;
            case "M":
                renderer.sprite = MTypeSprite;
                break;
            default:
                Debug.LogWarning("Unknown spectral type: " + spectralType);
                break;
        }
    }
}