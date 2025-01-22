using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Estado<T> : MonoBehaviour
{
        protected T Controller;
        public virtual void OnEnterState(T Controller)
        {
            this.Controller = Controller;
        }

        public abstract void OnUpdateState();

        public abstract void OnExitState();

}

