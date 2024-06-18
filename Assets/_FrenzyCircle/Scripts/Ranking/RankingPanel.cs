using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RankingPanel : MonoBehaviour
{
    public TextMeshProUGUI nameTextPanel;
    public TextMeshProUGUI rankTextPanel;
    public TextMeshProUGUI scoreTextPanel;
    public TextMeshProUGUI pointTextPanel;

    public bool targetChangedSize;
    public bool ignoreSetFontSize;
    public RectTransform targetRectTr;

    public DynamicScrollContentSize dynamicScrollSize;

    private void OnEnable()
    {
        RectTransform target = transform.parent.parent.GetComponent<RectTransform>();

        if (targetChangedSize)
        {
            target = targetRectTr;
        }

        GetComponent<LayoutElement>().minHeight = target.rect.height / 10f;
    }

    private void Start()
    {
        if (!ignoreSetFontSize)
        {
            if (dynamicScrollSize == null)
            {
                dynamicScrollSize = transform.parent.GetComponent<DynamicScrollContentSize>();
            }
        }
    }

    private void Update()
    {
        if (ignoreSetFontSize)
        {
            return;
        }

        if (Mathf.Abs(nameTextPanel.fontSize - dynamicScrollSize.basePanel.GetNameFontSize()) > 1f)
        {
            SetFontSizes();
        }
    }

    public void SetTexts(string userName, int rank, int score)
    {
        if (!string.IsNullOrEmpty(userName) && userName.Length >= 12)
        {
            userName = userName[..12] + "...";
        }

        nameTextPanel.text = userName;
        rankTextPanel.text = rank == 0 ? "-" : rank + "";
        scoreTextPanel.text = score == 0 ? "-" : score + "";
        pointTextPanel.text = "-";
    }

    private void SetFontSizes()
    {
        nameTextPanel.fontSize = dynamicScrollSize.basePanel.GetNameFontSize();
        rankTextPanel.fontSize = dynamicScrollSize.basePanel.GetRankTextSize();
        scoreTextPanel.fontSize = dynamicScrollSize.basePanel.GetScoreTextSize();
        pointTextPanel.fontSize = dynamicScrollSize.basePanel.GetPointTextSize();
        
        TurnOnOff(false);
        TurnOnOff(true);
    }

    private void TurnOnOff(bool turned)
    {
        nameTextPanel.gameObject.SetActive(turned);
        rankTextPanel.gameObject.SetActive(turned);
        scoreTextPanel.gameObject.SetActive(turned);
        pointTextPanel.gameObject.SetActive(turned);
    }

    private float GetNameFontSize()
    {
        return nameTextPanel.fontSize;
    }

    private float GetRankTextSize()
    {
        return rankTextPanel.fontSize;
    }

    private float GetScoreTextSize()
    {
        return scoreTextPanel.fontSize;
    }

    private float GetPointTextSize()
    {
        return pointTextPanel.fontSize;
    }
}