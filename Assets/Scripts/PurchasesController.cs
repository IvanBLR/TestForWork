using System;
using DefaultNamespace;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Purchasing;

public class PurchasesController : MonoBehaviour
{
    public Action LifeAdded;
    
    [UsedImplicitly] // добавлен на успешную покупку
    public void OnPurchaseComplete(Product product)
    {
        switch (product.definition.id)
        {
            case "com.DefaultCompany.MyTestWork.doubleTime":
                AddDoubleTime();
                break;
            case "com.DefaultCompany.MyTestWork.addLife":
                AddLife();
                break;
            case "com.DefaultCompany.MyTestWork.addSomeEffect":
                AddEffect();
                break;
            case "com.DefaultCompany.MyTestWork.addTempSkill":
                AddTempSkill();
                break;
            case "com.DefaultCompany.MyTestWork.addAllTimeSkill":
                AddFullTimeSkill();
                break;
            case "com.DefaultCompany.MyTestWork.addSmth":
                AddSmth();
                break;
        }
    }

    [UsedImplicitly] // добавлен на отказ от покупки
    public void OnPurchaseCancel(Product product, PurchaseFailureReason reason)
    {
        switch (product.definition.id)
        {
            case "com.DefaultCompany.MyTestWork.doubleTime":
            case "com.DefaultCompany.MyTestWork.addLife":
            case "com.DefaultCompany.MyTestWork.addSomeEffect":
            case "com.DefaultCompany.MyTestWork.addTempSkill":
            case "com.DefaultCompany.MyTestWork.addAllTimeSkill":
            case "com.DefaultCompany.MyTestWork.addSmth":
                Debug.Log($"Игрок отказался от покупки по причине {reason}");
                break;
        }
    }

    private void AddSmth()
    {
        Debug.Log("Добавили тебе кистояки на уши))) хз зачем, просто это очень мило)");
    }

    private void AddFullTimeSkill()
    {
        PlayerPrefs.SetInt(GameConstants.ALL_TIME_SKILL, 1);
        Debug.Log("Поздравляем! Теперь Ваш перс будет под постоянной защитой Зевса!");
    }

    private void AddTempSkill()
    {
        Debug.Log("Артемида благоволит тебе! +50 маны в первую минуту");
    }

    private void AddEffect()
    {
        Debug.Log("Твои стрелы будут пропитаны ядом в следующем уровне!");
    }

    private void AddDoubleTime()
    {
        Debug.Log("Мы удвоили Вам время на прохождение уровня");
    }

    private void AddLife()
    {
        LifeAdded?.Invoke();
        PlayerPrefs.SetInt(GameConstants.LONG_LIFE, 1);
        Debug.Log("Постоянный эффект: +125 жизни. Постарайся не умереть на полпути к цели!");
    }
}