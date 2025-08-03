using System;

public static class CurrencySystem
{
    public static event Action<int> OnCurrencyChanged;
    
    private static int _currentMoney = 500; // Başlangıç parası

    public static int CurrentMoney
    {
        get { return _currentMoney; }
        private set
        {
            _currentMoney = value;
            OnCurrencyChanged?.Invoke(_currentMoney);
        }
    }

    public static void AddMoney(int amount)
    {
        if (amount > 0)
        {
            CurrentMoney += amount;
            Console.WriteLine($"Eklendi: {amount}. Yeni bakiye: {CurrentMoney}");
        }
    }

    public static bool TryRemoveMoney(int amount)
    {
        if (amount > 0 && CurrentMoney >= amount)
        {
            CurrentMoney -= amount;
            Console.WriteLine($"Çıkarıldı: {amount}. Yeni bakiye: {CurrentMoney}");
            return true;
        }
        Console.WriteLine("Yetersiz bakiye.");
        return false;
    }
}
