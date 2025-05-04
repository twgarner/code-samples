public override GameObject BuildVisual(ItemPartSet partSet)
{
    GameObject root = new GameObject("GeneratedWeapon2D");

    Vector2 currentAnchor = Vector2.zero;

    foreach (var part in layout)
    {
        Sprite sprite = partSet.GetRandom2DPart(part.partType);
        if (sprite == null) continue;

        GameObject partObj = new GameObject(part.partType.ToString());
        partObj.transform.SetParent(root.transform, false);

        var renderer = partObj.AddComponent<SpriteRenderer>();
        renderer.sprite = sprite;
        renderer.sortingOrder = part.sortingOrder;

        Vector2 size = sprite.bounds.size;
        Vector2 pivotOffset = sprite.bounds.size * 0.5f - sprite.bounds.center;
        Vector2 offset = Vector2.zero;

        // Adjust position based on direction
        switch (part.anchorDirection)
        {
            case AnchorDirection.TopToBottom:
                offset = new Vector2(0, -size.y * 0.5f);
                break;
            case AnchorDirection.BottomToTop:
                offset = new Vector2(0, size.y * 0.5f);
                break;
            case AnchorDirection.LeftToRight:
                offset = new Vector2(-size.x * 0.5f, 0);
                break;
            case AnchorDirection.RightToLeft:
                offset = new Vector2(size.x * 0.5f, 0);
                break;
            case AnchorDirection.Center:
                offset = Vector2.zero;
                break;
        }

        Vector2 position = currentAnchor + offset - pivotOffset;
        partObj.transform.localPosition = position;

        // Set new anchor point for next part
        currentAnchor = position + GetNextAnchorOffset(part.anchorDirection, size);
    }

    return root;
}

private Vector2 GetNextAnchorOffset(AnchorDirection direction, Vector2 size)
{
    switch (direction)
    {
        case AnchorDirection.TopToBottom:
            return new Vector2(0, -size.y);
        case AnchorDirection.BottomToTop:
            return new Vector2(0, size.y);
        case AnchorDirection.LeftToRight:
            return new Vector2(size.x, 0);
        case AnchorDirection.RightToLeft:
            return new Vector2(-size.x, 0);
        default:
            return Vector2.zero;
    }
}
