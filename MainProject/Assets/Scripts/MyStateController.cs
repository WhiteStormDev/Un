using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class MyStateController : StateMachineBehaviour
    {
        public infState CurrentState;

        public void OnMyStateEnterCompleted()
        {
            if (CurrentState != null)
                Debug.Log(CurrentState.Name);
        }
    }
    
}