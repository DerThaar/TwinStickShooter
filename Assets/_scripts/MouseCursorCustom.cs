using UnityEngine;

public class MouseCursorCustom : MonoBehaviour
{
    public Texture2D mousePointer;

    void Start()
    {
        Vector2 hotspot = new Vector2(mousePointer.width / 2, mousePointer.height / 2);
        Cursor.SetCursor(mousePointer, hotspot, CursorMode.Auto);
    }
}
