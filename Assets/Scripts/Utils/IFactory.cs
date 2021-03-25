using UnityEngine;

public interface IFactory<T> where T : MonoBehaviour
{    

   T Create(int id);

   T CreateRandom();

}