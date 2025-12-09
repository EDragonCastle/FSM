using UnityEngine;

public class RunState : ICharaterState
{
    #region ICharacter Interface
    // Enter 초기 설정
    public void EnterState(Player state)
    {
        var animator = state.GetAnimator();

        animator.SetBool("isWalking", true);
        animator.SetBool("isRunning", true);
    }

    // Exit 상태에서 나갈 때 실행
    public void ExitState(Player state)
    {
        var animator = state.GetAnimator();
        animator.SetBool("isRunning", false);
    }

    // key Input 처리 후 다음 상태로 넘어갈 때
    public void HandleInput(Player state)
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            state.TransitionState(new SlideState());
        }
        else if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            state.TransitionState(new JumpState());
        }
        else if(Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.Z))
        {
            state.TransitionState(new WalkState());
        }
        else if(!Input.GetKey(KeyCode.UpArrow))
        {
            state.TransitionState(new IdleState());
        }
    }

    // Update에서 매 프레임 실행한다.
    public void ExecuteState(Player state)
    {

    }
    #endregion
}
