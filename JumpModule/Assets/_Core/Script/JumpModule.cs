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
    
    int count = 0;

    private void Start()
    {
        // Verify to Rigidbody
        if(rb) return;
        Debug.LogError("Error Missing Rigidbody !");
    }
    private void Update()
    {
        if(Input.GetKeyDown(ToJump) && count < CountJump )
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

            count = 0;
        }
    }
}
