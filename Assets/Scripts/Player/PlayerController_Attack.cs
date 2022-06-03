using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerController : MonoBehaviour
{
    [Header("Attack System")]
    [SerializeField] private int _comboCount = 0;
    [SerializeField] private int _maxComboCount = 2;


    [SerializeField] private Collider2D atkCollider2d;

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

        atkCollider2d.enabled = true;
    }

    public void FinishCombo()
    {
        _comboCount = 0;

        atkCollider2d.enabled = false;
    }
}
