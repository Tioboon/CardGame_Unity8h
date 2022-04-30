using System;
using System.Collections.Generic;
using Global;
using UnityEngine;

namespace Cards
{
    public class CardController : MonoBehaviour
    {
        private void Start()
        {
            GenerateHand(GlobalPlayer.instance.deck);
        }

        private void GenerateHand(List<Card> instanceDeck)
        {
            GameObject cardPrefab = GlobalCards.instance.cardPrefab; // Pega o prefab da carta
            foreach (Card card in instanceDeck) //Para cada carta no deck do jogador
            {
                GameObject newCard = Instantiate(cardPrefab, GlobalCards.instance.cardCanvas.transform); //Instancia a carta
                CardElements element = newCard.GetComponent<CardElements>(); //Pega o script com os elementos separados da carta
                //Aplica as informações da carta nos elementos
                element.cost.text = card.cost.ToString();
                element.image.sprite = card.image;
                element.text.text = GenerateDescription(card.effects);
            }
        }

        private string GenerateDescription(List<CardEffects> cardEffects)
        {
            string finalText = "";
            foreach (CardEffects effect in cardEffects) //Para cada efeito da carta
            {
                switch (effect.type) //Escolhe um parametro para checagem, no caso o tipo de efeito
                {
                    case EffectEnum.Damage: //Se o tipo for dano
                        finalText += $"Inflinge {effect.value} de dano."; //Adiciona essa frase a carta.
                        break;
                    case EffectEnum.Bleeding:
                        finalText += $"Adiciona +{effect.value} de sangramento ao inimigo.";
                        break;
                }
            }

            return finalText;
        }
    }
}