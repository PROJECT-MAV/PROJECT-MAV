using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{
    private CharacterAnimations playerAnimations;
    public GameObject attackPointLeft;
    public GameObject attackPointRight;

    // Start is called before the first frame update
    void Awake()
    {
        playerAnimations = GetComponent<CharacterAnimations>();
    }

    // Update is called once per frame
    void Update()
    {
        // defend
        if (Input.GetKeyDown(KeyCode.B)) {
            playerAnimations.Defend(true);
        }

        if (Input.GetKeyUp(KeyCode.B)) {
            playerAnimations.Defend(false);
        }

        // attack
        if (Input.GetKeyDown(KeyCode.Z)) {

            // 레프트훅, 라이트훅 중 랜덤하게 하나 모션 나가게 하는 것
            if(Random.Range(0,2) > 0) {
                playerAnimations.Attack_1();
            } else {
                playerAnimations.Attack_2();
            }
        }
    }

    void Activate_AttackPoint_Left() {
        attackPointLeft.SetActive(true);
    }

    void Deactivate_AttackPoint_Left() {
        if (attackPointLeft.activeInHierarchy) { // setactive되어있으면
            attackPointLeft.SetActive(false);
        }
    }

    void Activate_AttackPoint_Right() {
        attackPointRight.SetActive(true);
    }

    void Deactivate_AttackPoint_Right() {
        if (attackPointRight.activeInHierarchy) { // setactive되어있으면
            attackPointRight.SetActive(false);
        }
    }
}
