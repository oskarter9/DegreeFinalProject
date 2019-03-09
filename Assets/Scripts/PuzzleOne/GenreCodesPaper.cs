using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenreCodesPaper : Interactable {

    public Item _genreCodesPaperItem;

    public override void Interact()
    {
        base.Interact();
        Inventory.instance.Add(_genreCodesPaperItem);
        GetComponentInParent<PuzzleOneController>().powerEnabled = true;
        Destroy(gameObject);
    }
}
