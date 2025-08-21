using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script allows a player to pick up and throw objects in 2D.
/// It supports two players using different keys.
/// </summary>
public class PlayerPickUpObject : MonoBehaviour {
    [Header("Pickup Settings")]
    public LayerMask layerMask;           // Which objects can be picked up
    public Transform pickupPoint;         // Where the object will be held
    public float pickupRadius = 0.5f;    // How far the player can reach to pick up
    public float throwForce = 3f;        // How strong the throw is
    public SpriteRenderer spriteRender;  // Shows if the player can pick somehting up
    
    [Header("Player Key Bind")]
    public KeyCode grabKeyBind = KeyCode.P;
    public KeyCode throwKeyBind = KeyCode.L;


    private bool _isInventoryMax = false;
    public int inventoryLimit;
    private List<GameObject> _heldObjectList;       // The object currently being held
    private PlayerMovement _playerMovement;
    private Collider2D _objectInRange;    // Object in pickup range
    // Called when the game starts
    private void Start() {
        _heldObjectList = new List<GameObject>();
        _playerMovement = GetComponentInParent<PlayerMovement>();  
    }

    // Called every frame
    private void Update() {
        // Check if there is an object in front of the player
        _objectInRange = Physics2D.OverlapCircle(pickupPoint.position, pickupRadius, layerMask);

        // Makes the idea sprite turn on/off based on if you can pick up an item
        spriteRender.enabled = !_isInventoryMax && _objectInRange != null;
        
        if (!_isInventoryMax && _objectInRange != null) {
            spriteRender.enabled = true;
            // Pick up object when the correct key is pressed
            if (Input.GetKeyDown(grabKeyBind)) {
                PickUpObjectMethod(_objectInRange);
            }
        }
        if (_heldObjectList.Count > 0) {
            // Throw object when the correct key is pressed
            if (Input.GetKeyDown(throwKeyBind)) {
                ThrowObjectMethod();
            }
        }
    }

    /// <summary>
    /// Picks up an object
    /// </summary>
    private void PickUpObjectMethod(Collider2D pickUp) {
        GameObject currentHeldObject = pickUp.gameObject;
        _heldObjectList.Add(currentHeldObject);
        if(_heldObjectList.Count > inventoryLimit)
        {
            _isInventoryMax = true;
        }

        // Disable physics so the object can be carried
        pickUp.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        currentHeldObject.GetComponent<Collider2D>().enabled = false;
        currentHeldObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

        // Move object to player's hand
        currentHeldObject.transform.SetParent(pickupPoint);
    }

    /// <summary>
    /// Throws the currently held object
    /// </summary>
    private void ThrowObjectMethod() {
        foreach (GameObject _heldObject in _heldObjectList)
        {
            // Re-enable physics
            _heldObject.GetComponent<Collider2D>().enabled = true;
            _heldObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            // Remove parent
            _heldObject.transform.SetParent(null);

            // Calculate throw direction based on player's rotation snapped to 45-degree increments
            float snappedAngle = Mathf.Round((transform.eulerAngles.z + 90f) / 45f) * 45f;
            float rad = snappedAngle * Mathf.Deg2Rad;

            Vector2 velocity = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));

            // Convert velocity to -1, 0, or 1 for direction only
            velocity.x = Mathf.Round(velocity.x);
            velocity.y = Mathf.Round(velocity.y);

            // Apply throw force and add player's movement
            velocity *= throwForce;
            velocity += _playerMovement.GetVelocity();

            // Set the object's velocity
            _heldObject.GetComponent<Rigidbody2D>().velocity = velocity;
        }

        // Clear held object reference
        _heldObjectList = new List<GameObject>();
    }

    // Draw a circle in the editor to show pickup range
    private void OnDrawGizmosSelected() {
        if (pickupPoint == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(pickupPoint.position, pickupRadius);
    }
}