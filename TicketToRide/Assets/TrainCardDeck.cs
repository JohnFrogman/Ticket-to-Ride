using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrainCardDeck : MonoBehaviour
{

	private int totalCards = 110;
	private List<TrainCard> trainCards = new List<TrainCard>();
	private List<TrainCard> discardPile = new List<TrainCard>();

	void Start()
	{
		// Initialises the train deck 
		trainCards.Add(new TrainCard{colour = "pink", quantity = 12});
		trainCards.Add(new TrainCard{colour = "white", quantity = 12});
		trainCards.Add(new TrainCard{colour = "blue", quantity = 12});
		trainCards.Add(new TrainCard{colour = "yellow", quantity = 12});
		trainCards.Add(new TrainCard{colour = "orange", quantity = 12});
		trainCards.Add(new TrainCard{colour = "black", quantity = 12});
		trainCards.Add(new TrainCard{colour = "red", quantity = 12});
		trainCards.Add(new TrainCard{colour = "green", quantity = 12});
		trainCards.Add(new TrainCard{colour = "rainbow", quantity = 15});

		// Initialises the discard pile
		discardPile.Add(new TrainCard{colour = "pink", quantity = 0});
		discardPile.Add(new TrainCard{colour = "white", quantity = 0});
		discardPile.Add(new TrainCard{colour = "blue", quantity = 0});
		discardPile.Add(new TrainCard{colour = "yellow", quantity = 0});
		discardPile.Add(new TrainCard{colour = "orange", quantity = 0});
		discardPile.Add(new TrainCard{colour = "black", quantity = 0});
		discardPile.Add(new TrainCard{colour = "red", quantity = 0});
		discardPile.Add(new TrainCard{colour = "green", quantity = 0});
		discardPile.Add(new TrainCard{colour = "rainbow", quantity = 0});
	}

	// Draws a card at random from the deck.
	public string draw()
	{
		// Check if the deck is empty and refills it if it is.
		if (totalCards == 0) 
		{
			outOfCards();
		}

		// Spin the roulette
		int spin = totalCards*Random.value ();
		// Card is removed
		totalCards--;
		// Find out which card you drew
		int total = 0;
		foreach (var card in trainCards)
		{
			total += card.quantity;
			if (spin > total)
			{
				card.quantity--;
				return card.colour;
			}
		}
	}
	// Sends a card to the discard pile from an external script.
	public void discardCard(string colour)
	{
		foreach (TrainCard card in discardPile) 
		{
			if (card.colour == colour)
			{
				card.quantity++;
			}
		}
	}

	// Empties the discard pile into the active pile when the cards run out.
	static void outOfCards()
	{
		trainCards.Clear();
		foreach (var card in discardPile) 
		{
			trainCards.Add (card);
			card.quantity = 0;
		}
	}
}