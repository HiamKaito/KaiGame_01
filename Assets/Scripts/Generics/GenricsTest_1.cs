using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenricsTest_1 : MonoBehaviour
{
    void Start()
    {
        CreateArray(6, 5);
        CreateArray("a", "B");
        TestMultiGenerics("a", 5);

        // MyClass<EnemyAtk> myClass_1 = new MyClass<EnemyAtk>(new EnemyAtk());
        // MyClass<EnemyDef> myClass_2 = new MyClass<EnemyDef>(new EnemyDef());
    }

    void CreateArray<T>(T firstElement , T secondElement) {
        Debug.Log("Test Create Array Generis " + firstElement + " and " + secondElement);
    }

    void TestMultiGenerics<T1, T2>(T1 firstElement, T2 secondElement) {
        Debug.Log("Test Multi Generis value " + firstElement + " and " + secondElement );
        Debug.Log("Test Multi Generis type " + firstElement.GetType() + " and " + secondElement.GetType() );
    }
}


// public class MyClass<T> where T : IEnemy<T>{
//     public T Value;

//     public MyClass(T Value) {
//         Value.Damage(Value);
//     }

//     T[] CreateArray(T firstElement, T secondElement) {
//         return new T[] {firstElement, secondElement};
//     }
// }

// public interface IEnemy<T> {
//     void Damage(T value);
// }

// public class EnemyAtk : IEnemy<int> {
//     public void Damage(int i)
//     {
//         Debug.Log("Enemy Atk Damage " + i);
//     }
// }

// public class EnemyDef : IEnemy<string> {
//     public void Damage(string s)
//     {
//         Debug.Log("Enemy Def Damage " + s);
//     }
// }
