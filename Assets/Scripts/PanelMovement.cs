using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMovement : MonoBehaviour
{
    private RectTransform rectTransform;
    public float xChestPosition = -1475f;
    public float yChestPosition = 70f;
    public float xShopPosition = -440f;
    public float yShopPosition = 70f;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void MoveToChest()
    {
        rectTransform.anchoredPosition = new Vector2(xChestPosition, yChestPosition);
    }

    public void MoveToShop()
    {
        rectTransform.anchoredPosition = new Vector2(xShopPosition, yShopPosition);
    }
}

