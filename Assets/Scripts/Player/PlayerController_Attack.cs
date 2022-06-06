using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerController : MonoBehaviour
{
    [Header("Attack System")]
    [SerializeField] private int _comboCount = 0;
    public int ComboCount
    {
        get { return _comboCount; }
        set { _comboCount = value; }
    }
    [SerializeField] private int _maxComboCount = 2;

    public bool isPressAtkBtn() => Input.GetKeyDown(KeyCode.J);

    private void CheckCombo()
    {
        if (isPressAtkBtn()) { Start_Combo(); }
    }

    public void Start_Combo()
    {
        if (_comboCount < _maxComboCount && isPressAtkBtn()) { NextCombo(); }
        else { FinishCombo(); }
    }

    public void NextCombo()
    {
        _comboCount++;
        animator.SetTrigger("Attack_" + _comboCount);
    }

    public void FinishCombo() => _comboCount = 0;
}
