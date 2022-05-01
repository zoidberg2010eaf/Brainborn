using System;
using UnityEngine;
 public interface IBaseStage
{
    void PrepareView();
    void StartStage();
    void AnswerRight();
    void AnswerWrong();
}