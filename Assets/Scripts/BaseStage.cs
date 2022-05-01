using System;
using UnityEngine;
using UnityEngine.EventSystems;
public abstract class BaseStage : MonoBehaviour
{
    private float _clickDetectTimer;

    public bool _canDrag;

    public GameObject m_view;

    [HideInInspector]
    public bool IsShowPassAnimation;

    private bool _IsGameOver;
    public bool IsGameOver
    {
        get;
        set;
    }
    public int StageNum
    {
        get
        {
            return int.Parse(base.name.Substring(5, 3));
        }
    }
    public abstract void PrepareView();
    public virtual void StartStage()
    {
        this.IsGameOver = false;
        this.m_view.SetActive(true);
    }
    public virtual void EndStage()
    {
        this.IsGameOver = true;
        base.StopAllCoroutines();
    }
    public void ContinueStage()
    {
        this.PrepareView();
        this.StartStage();
        this.m_view.SetActive(true);
        this.IsGameOver = false;
    }
    public virtual void ResumeStage()
    {
    }

    public virtual void Awake()
    {
        _clickDetectTimer = 0.0f;
        Camera.main.backgroundColor = Color.white;
    }    

    public virtual void Update()
    {
        if(_canDrag)
          _clickDetectTimer += Time.deltaTime;
    }

    public void AnswerRight()
    {
        if (GameManager._Instance.isLevelClear)
            return;
        if (!GameManager._Instance.isLevelClear)
            GameManager._Instance.isLevelClear = true;
    }
    public void AnswerRight(BaseEventData data)
    {
        if (GameManager._Instance.isLevelClear)
            return;
        if (_clickDetectTimer <= 0.2f)
        {
            if (!GameManager._Instance.isLevelClear)
                GameManager._Instance.isLevelClear = true;
            PointerEventData pointerEventData = (PointerEventData)data;
            GameObject pointerDrag = pointerEventData.pointerDrag;
            RectTransform component = pointerDrag.GetComponent<RectTransform>();
            UIPanelManager._Insance.ShowRight(component.localPosition);
        }
           
    }

    public void AnswerRightClick(BaseEventData data)
    {
        if (GameManager._Instance.isLevelClear)
            return;
        if (_clickDetectTimer <= 0.2f)
        {
            if (!GameManager._Instance.isLevelClear)
                GameManager._Instance.isLevelClear = true;
            PointerEventData pointerEventData = (PointerEventData)data;
            UIPanelManager._Insance.ShowRight(pointerEventData.position.ToCanvasPoint());
        }

    }

    public void AnswerRight(Vector2 imgPos)
    {
        if (GameManager._Instance.isLevelClear)
            return;
        if (_clickDetectTimer <= 0.2f)
        {
            if (!GameManager._Instance.isLevelClear)
                GameManager._Instance.isLevelClear = true;
            UIPanelManager._Insance.ShowRight(imgPos);
        }
    }
    public void AnswerWrong(Vector2 imgPos)
    {
        if (GameManager._Instance.isLevelClear)
            return;
        if (_clickDetectTimer <= 0.2f)
        {
            UIPanelManager._Insance.ShowWrong(imgPos);
        }
    }

    public void PressStart()
    {
        _clickDetectTimer = 0.0f;
        Debug.Log("Down");
    }
   
    public void AnswerWrong(BaseEventData data)
    {

        if (GameManager._Instance.isLevelClear)
            return;
        Debug.Log("UP");
        if (_clickDetectTimer <= 0.2f)
        {
            PointerEventData pointerEventData = (PointerEventData)data;
            GameObject pointerDrag = pointerEventData.pointerDrag;
            RectTransform component = pointerDrag.GetComponent<RectTransform>();
            UIPanelManager._Insance.ShowWrong(component.localPosition);
        }
        
       
    }

    public void AnswerWrongClick(BaseEventData data)
    {

        if (GameManager._Instance.isLevelClear)
            return;
        if (_clickDetectTimer <= 0.2f)
        {
            PointerEventData pointerEventData = (PointerEventData)data;
            UIPanelManager._Insance.ShowWrong(pointerEventData.position.ToCanvasPoint());
        }


    }

    public virtual void ShowExplain()
    {
    }
    public void OnPointerDownStageItem(BaseEventData eventData)
    {
       // StageReaction.New(((PointerEventData)eventData).pointerEnter).OnClick();
    }
}





