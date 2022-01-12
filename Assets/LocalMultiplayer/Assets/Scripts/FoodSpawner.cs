using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Atari.VCS.Demo.LocalMultiplayer
{
    public class FoodSpawner : MonoBehaviour
    {
        public Food food;

        private List<Food> foodResources = new List<Food>();

        private static FoodSpawner instance;

        public static FoodSpawner Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<FoodSpawner>();
                }

                return instance;
            }
        }
        private void Start()
        {
            StartCoroutine(SpawnFood());
        }

        IEnumerator SpawnFood()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.25f);

                if (foodResources.Count < 20)
                {
                    float x = Random.Range(-7.0f, 7.0f);
                    float y = Random.Range(-3.0f, 3.0f);

                    Food _food = Instantiate(food);

                    _food.transform.position = new Vector2(x, y);

                    foodResources.Add(_food);
                }
            }
        }

        public void RemoveFood(Food _disposableFood)
        {
            foodResources.Remove(_disposableFood);

            Destroy(_disposableFood.gameObject);
        }
    }
}