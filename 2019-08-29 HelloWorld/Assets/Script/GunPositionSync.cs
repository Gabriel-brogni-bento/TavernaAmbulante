using UnityEngine;
using UnityEngine.Networking;

public class GunPositionSync : NetworkBehaviour
{
    [SerializeField] Transform cameraTransform;
    [SerializeField] Transform armaPivot;
    [SerializeField] float threshold = 10f;
    [SerializeField] float smoothing = 5f;

    [SyncVar] float pitch;
    Vector3 lastOffset;
    float lastSyncedPitch;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        if (isLocalPlayer)
            armaPivot.parent = cameraTransform;
    }

    void Update()
    {
        if (isLocalPlayer)
        {
            pitch = cameraTransform.localRotation.eulerAngles.x;
            if (Mathf.Abs(lastSyncedPitch - pitch) >= threshold)
            {
                CmdUpdatePitch(pitch);
                lastSyncedPitch = pitch;
            }
        }
        else
        {
            Quaternion newRotation = Quaternion.Euler(pitch, 0f, 0f);
            

            armaPivot.localRotation = Quaternion.Lerp(armaPivot.localRotation,
                newRotation, Time.deltaTime * smoothing);
        }
    }

    [Command]
    void CmdUpdatePitch(float newPitch)
    {
        pitch = newPitch;
    }

    void OnAnimatorIK()
    {
        if (!anim)
            return;

        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
        anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);

        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
        anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);
    }
}
