using UnityEngine;

public class JumpModule : MonoBehaviour
{
    [Header("Set Input")]
    [SerializeField, Space] KeyCode ToJump = KeyCode.Space;
    [Header("Set setting to jump")]
    [SerializeField] int Layer = 6;
    [SerializeField] int CountJump = 1;
    [SerializeField, Space] float JumpForce = 1.5f;
    [Header("Player Components")]
    [SerializeField] Rigidbody rb;
    [SerializeField] Collider colliders;
    
    int count = 0;
    bool touchFloor = false;

    private void Start()
    {
        // Verify to colliders and Rigidbody
        if(colliders) return;
        Debug.LogError("Error Missing Collider !");
        if(rb) return;
        Debug.LogError("Error Missing Rigidbody !");
    }
    private void Update()
    {
        if(Input.GetKeyDown(ToJump) && count <= CountJump && touchFloor == true)
        {
            // Add force for jump
            rb.AddForce(transform.up * JumpForce);
            count++;
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Detection collision
        if(collision.gameObject.layer == Layer)
        {
            touchFloor = true;
            count = 0;
        }else
        {
            touchFloor = false;
        }
    }
}
