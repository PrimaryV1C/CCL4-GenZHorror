using UnityEngine;

public class KarmaKeeper : MonoBehaviour
{

    public int Karma { get; private set; }

    private void OnAnswerSelected(Answer answer)
    {
        Karma += answer.karma;
    }

    void Awake()
    {

        TextBubbleView[] textBubbleViews = FindObjectsByType<TextBubbleView>(FindObjectsSortMode.None);

        foreach (TextBubbleView textBubbleView in textBubbleViews)
        {

            textBubbleView.answerSelected.AddListener(OnAnswerSelected);

        }
    }
}
