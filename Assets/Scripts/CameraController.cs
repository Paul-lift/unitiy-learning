using UnityEngine;

public class CameraController : MonoBehaviour{
    //Targets
    public Transform FollowTarget, LookTarget;
    
    //Follow-Smoothing
    public float FollowSmoothTime = 0.25f;
    private Vector3 followVelocity;
    
    //Offset
    public Vector3 Offset = new Vector3(0, 2f, -4f);

    
    


    private void LateUpdate(){
        /*var targetPosition = FollowTarget.position;
        transform.position = Vector3.Lerp(transform.position, targetPosition, FollowSpeed * Time.deltaTime);
        transform.LookAt(LookTarget);
        
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition,)*/
        
        Vector3 targetPosition = FollowTarget.position + Offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref followVelocity, FollowSmoothTime);
        transform.LookAt(LookTarget);
        
        
    }
}