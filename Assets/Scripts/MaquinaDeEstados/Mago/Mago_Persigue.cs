using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mago_Persigue : Estado<Mago_Controller>
{
    public override void OnEnterState(Mago_Controller Controller)
    {
        Debug.Log("Persigue_Enter");
        base.OnEnterState(Controller);

    }
    public override void OnUpdateState()
    {
        Debug.Log("Persigue_Update");

    }


    public override void OnExitState()
    {
        Debug.Log("Persigue_Exit");

    }
}
