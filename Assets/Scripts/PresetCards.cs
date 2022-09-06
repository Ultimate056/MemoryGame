using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PresetCards : MonoBehaviour
{
    private int CardMax;
    [SerializeField] private Sprite _backsprite = null;
    [SerializeField] private List<Sprite> _allSprites = null;

    private void Awake()
    {
        switch(SceneManager.GetActiveScene().buildIndex)
        {
            // Easy
            case 1:
                CardMax = 9;
                break;
            // Normal
            case 2:
                CardMax = 13;
                break;
            // Hard
            case 3:
                CardMax = 18;
                break;
            // VeryHard
            case 4:
                CardMax = 25;
                break;
        }
    }

    // Обложка карта
    public Sprite GetBackSprite()
    {
        return _backsprite;
    }

    // Из общего списка выбираем сколько нам нужно
    public List<Sprite> GetPlayCardsSprites()
    {
        List<Sprite> sprites = new List<Sprite>(_allSprites);
        while(CardMax < sprites.Count)
        {
            sprites.RemoveAt(Random.Range(0, sprites.Count));
        }
        return sprites;
    }

    // Перемешиваем массив индексов карт в случайном порядке
    public int[] GetCardIndex()
    {
        int[] cardIndex = new int[CardMax];
        for (int i = 0; i < cardIndex.Length; i++)
        {
            cardIndex[i] = i;
        }
        for (int i = 0; i < cardIndex.Length; i++)
        {
            int temp = cardIndex[i];
            int rnd = Random.Range(0, cardIndex.Length);
            cardIndex[i] = cardIndex[rnd];
            cardIndex[rnd] = temp;
        }
        return cardIndex;
    }
}
