using UnityEngine;

public class WalkState : ICharaterState
{
    #region ICharacter Interface
    // Enter 초기 설정
    public void EnterState(Player state)
    {
        var animator = state.GetAnimator();
        animator.SetBool("isWalking", true);
    }

    // Exit 상태에서 나갈 때 실행
    public void ExitState(Player state)
    {
        var animator = state.GetAnimator();
        animator.SetBool("isWalking", false);
    }

    // key Input 처리 후 다음 상태로 넘어갈 때
    public void HandleInput(Player state)
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            state.TransitionState(new JumpState());
        }


        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.Z))
        {
            state.TransitionState(new RunState());
        }
        else if(!Input.GetKey(KeyCode.UpArrow))
        {
            state.TransitionState(new IdleState());
        }
    }

    // Update에서 매 프레임 실행한다.
    public void ExecuteState(Player state)
    {
        Debug.Log("Walk 진행 중");
    }
    #endregion
}
