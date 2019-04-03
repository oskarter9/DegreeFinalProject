using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenreCodesPaper : Interactable {

    public Item _genreCodesPaperItem;

    public override void Interact()
    {
        base.Interact();
        if (ReferencesManager.instance.POneControllerContainer.GetComponent<PuzzleOneController>().enablePaper)
        {
            Debug.Log("Papel recogido");
            Inventory.instance.Add(_genreCodesPaperItem);
            GetComponentInParent<PuzzleOneController>().puzzleSolved = true;
            Destroy(gameObject);
        }
    }
}
