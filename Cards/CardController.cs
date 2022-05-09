using System;
using System.Collections.Generic;
using Global;
using UnityEngine;

namespace Cards
{
    public class CardController : MonoBehaviour
    {
        public float cardYOffset;

        private void Start()
        {
            GenerateHand(GlobalPlayer.instance.deck);
        }

        private void GenerateHand(List<Card> instanceDeck)
        {
            GameObject cardPrefab = GlobalCards.instance.cardPrefab; // Pega o prefab da carta
            List<GameObject> allGameObjectCards = new List<GameObject>();
            foreach (Card card in instanceDeck) //Para cada carta no deck do jogador
            {
                GameObject newCard = Instantiate(cardPrefab, GlobalCards.instance.cardCanvas.transform); //Instancia a carta
                allGameObjectCards.Add(newCard);
                CardElements element = newCard.GetComponent<CardElements>(); //Pega o script com os elementos separados da carta
                //Aplica as informações da carta nos elementos
                element.cost.text = card.cost.ToString();
                element.image.sprite = card.image;
                element.text.text = GenerateDescription(card.effects);
            }

            AttCardsPosition(allGameObjectCards);
        }

        private void AttCardsPosition(List<GameObject> allGameObjectCards)
        {
            //Vector2 screenSize = new Vector2(Screen.width, Screen.height); Vamos utilizar para criar um "respiro"
            int cardIdx = 0;
            foreach (var cardGO in allGameObjectCards)
            {
                RectTransform cardTransform = cardGO.GetComponent<RectTransform>(); //Pega o rect transform do objeto da carta
                Vector2 cardSize = cardTransform.anchorMax - cardTransform.anchorMin; //Adquire o tamnho da carta
                cardTransform.anchorMin = new Vector2(cardSize.x * cardIdx, 0); //Posiciona o x minimo da ancora no tamanho da carta * o index dela
                cardTransform.anchorMax = cardTransform.anchorMin + cardSize;  //Com base na posição minima, adiciona o tamanho da carta para gerar a posição máxima da ancora
                cardTransform.offsetMax = new Vector2(0, -cardYOffset); //Ajusta os valores do tamanho da imagem em pixel para ficar perto das ancoras
                cardTransform.offsetMin = new Vector2(0, -cardYOffset);
                cardIdx++;
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