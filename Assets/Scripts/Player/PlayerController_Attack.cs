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
    [SerializeField] private bool _isOnComboStatus = false;

    private bool isPressAtkBtn() => Input.GetKeyDown(KeyCode.J);

    private void CheckCombo()
    {
        if (isPressAtkBtn() && !_isOnComboStatus) { Start_Combo(); }
    }

    public void ComboStatus_True()
    {
        _isOnComboStatus = true;
    }

    public void ComboStatus_False()
    {
        _isOnComboStatus = false;
    }

    public void Start_Combo()
    {
        if (_comboCount < _maxComboCount && isPressAtkBtn()) { NextCombo(); }
        //! BUG combo count
        else { if (_comboCount == _maxComboCount && isPressAtkBtn()) { FinishCombo(); } }
    }

    private void NextCombo()
    {
        ComboStatus_True();

        _comboCount++;
        animator.SetTrigger("Attack_" + _comboCount);
        // Debug.Log("Hero is going attact combo " + _comboCount);
    }

    private void FinishCombo() => _comboCount = 0;
}
