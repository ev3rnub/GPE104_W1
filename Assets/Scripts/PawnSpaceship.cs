using UnityEngine;

public class PawnSpaceship : Pawn
{

    public float moveSpeed = 3;
    public float turnSpeed = 180;

    public override void Move(Vector3 someVec3)
    {
        transform.position += someVec3 * moveSpeed * Time.deltaTime;
    }

    public override void Rotate(float someAngle)
    {
        transform.Rotate(0,0,someAngle * turnSpeed * Time.deltaTime);
    }

    public override void Teleport(Vector3 targetPosition)
    {
        transform.position = targetPosition;
    }
}
