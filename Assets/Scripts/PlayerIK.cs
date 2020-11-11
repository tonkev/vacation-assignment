using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerIK : MonoBehaviour {

    public delegate void OnFootHitGround(RaycastHit hit);

    public event OnFootHitGround onFootHitGround;

    float prevLeftFootBlend = 0f;
    float prevRightFootBlend = 0f;

    Animator anim;

    private void Start() {
        anim = GetComponent<Animator>();
    }

    void OnAnimatorIK(int layerIndex) {
        RaycastHit hit;

        float leftFootBlend = 0f;
        Transform leftFoot = anim.GetBoneTransform(HumanBodyBones.LeftFoot);
        if (Physics.Raycast(leftFoot.position, Vector3.down, out hit, 3, LayerMask.GetMask("Ground"))) {
            anim.SetIKPosition(AvatarIKGoal.LeftFoot, hit.point);
            Quaternion targetRotation = Quaternion.FromToRotation(Vector3.up, hit.normal) * transform.rotation;
            anim.SetIKRotation(AvatarIKGoal.LeftFoot, targetRotation);
            leftFootBlend = anim.GetFloat("leftFoot");
            if (leftFootBlend > 0.99f && prevLeftFootBlend <= 0.99f)
                onFootHitGround.Invoke(hit);
        }
        anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, leftFootBlend);
        anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, leftFootBlend);
        prevLeftFootBlend = leftFootBlend;

        float rightFootBlend = 0f;
        Transform rightFoot = anim.GetBoneTransform(HumanBodyBones.RightFoot);
        if (Physics.Raycast(rightFoot.position, Vector3.down, out hit, 3, LayerMask.GetMask("Ground"))) {
            anim.SetIKPosition(AvatarIKGoal.RightFoot, hit.point);
            Quaternion targetRotation = Quaternion.FromToRotation(Vector3.up, hit.normal) * transform.rotation;
            anim.SetIKRotation(AvatarIKGoal.RightFoot, targetRotation);
            rightFootBlend = anim.GetFloat("rightFoot");
            if (rightFootBlend > 0.99f && prevRightFootBlend <= 0.99f)
                onFootHitGround.Invoke(hit);
        }
        anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, rightFootBlend);
        anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, rightFootBlend);
        prevRightFootBlend = rightFootBlend;
    }
}
