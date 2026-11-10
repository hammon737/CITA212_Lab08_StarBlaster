using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    InputAction moveAction;
    Vector3 moveVector;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        movePlayer();
    }

    void movePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();

        transform.position += moveVector * moveSpeed * Time.deltaTime;
    }

}
