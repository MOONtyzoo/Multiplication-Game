using UnityEngine;

public class Cursor : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Vector3 hotspotOffset;
    
    void Awake() {
        UnityEngine.Cursor.visible = false;
    }

    void Update() {
        UpdateCursorPosition();
    }

    // Code from https://stackoverflow.com/questions/43802207/position-ui-to-mouse-position-make-tooltip-panel-follow-cursor
    private void UpdateCursorPosition() {
        Vector2 movePos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            Input.mousePosition, canvas.worldCamera,
            out movePos);

        Vector3 mousePos = canvas.transform.TransformPoint(movePos);
        mousePos = new Vector3(mousePos.x, mousePos.y, transform.position.z);
        
        transform.position = mousePos + hotspotOffset;
    }
}