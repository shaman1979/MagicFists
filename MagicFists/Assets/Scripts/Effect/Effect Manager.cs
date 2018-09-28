using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager
{
    Effect mainEffect = null;
    Effect secindary = null;

    public void setMainEffect(Effect effect)
    {
        mainEffect = effect;
    }
    public void setSecandaryEffect(Effect effect)
    {
        secindary = effect;
    }
}

public interface IEffect
{
    void ActionEffect();
}

public class Effect
{
    public enum State
    {
        mainEffect,
        secindary
    }
    State stateFigth;
    public void SetEffect(State state)
    {
        stateFigth = state;
    }
    public void ActiveEffect(int i)
    {

    }
}
 
