using UnityEngine;

public class Cursor : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Vector3 hotspotOffset;

    [Space, Header("Sounds")]
    [SerializeField] private AudioClip mouseDownSound;
    [SerializeField] private AudioClip mouseUpSound;

    private Animator animator;
    private AudioSource audioSource;

    void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        //UnityEngine.Cursor.visible = false;
    }

    void Update()
    {
        UpdateCursorPosition();

        if (Input.GetMouseButtonDown(0))
        {
            animator.Play("ClickDown", 0, 0.0f);
            audioSource.clip = mouseDownSound;
            audioSource.Play();
        }

        if (Input.GetMouseButtonUp(0))
        {
            animator.Play("ClickUp", 0, 0.0f);
            audioSource.clip = mouseUpSound;
            audioSource.Play();
        }
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