using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    public MyController someController; 

    public abstract void Move(Vector3 someMoveVector);
    public abstract void Rotate(float someAngle);
    public abstract void Teleport(Vector3 targetPosition);
}
