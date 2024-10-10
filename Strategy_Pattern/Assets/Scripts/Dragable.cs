using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class DragablePoint : MonoBehaviour
{
    public bool IsDragging = false;
    public BoxCollider2D boxCollider;  // Ensure using BoxCollider2D for 2D physics
    public SpriteRenderer spriteRenderer;
    private int initialSortingOrder;
    private Rigidbody2D rb;  // Rigidbody2D for physics-based movement

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();  // Using BoxCollider2D for 2D physics
        rb = GetComponent<Rigidbody2D>();  // Reference to Rigidbody2D
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Ensure Rigidbody2D is set to kinematic to manually control movement while dragging
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        if (spriteRenderer != null)
        {
            initialSortingOrder = spriteRenderer.sortingOrder;
        }
    }

    private void OnMouseDown()
    {
        IsDragging = true;
    }

    private void OnMouseUp()
    {
        IsDragging = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (IsDragging)
        {
            // Move the object by calculating the mouse position in world space
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            // Update the position using Rigidbody2D for physics-based movement
            rb.MovePosition(new Vector2(worldPos.x, worldPos.y));

            if (spriteRenderer != null)
            {
                spriteRenderer.sortingOrder = initialSortingOrder + 1;  // Bring the dragged object to the front
            }
        }
        else
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.sortingOrder = initialSortingOrder;  // Restore original sorting order
            }
        }
    }
}
