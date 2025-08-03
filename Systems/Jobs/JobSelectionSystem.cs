using System;
using System.Collections.Generic;

public class JobSelectionSystem
{
    private Player _currentPlayer;

    public JobSelectionSystem(Player player)
    {
        _currentPlayer = player;
    }

    public void ShowJobSelection()
    {
        Console.WriteLine("--- MESLEK SEÇİM EKRANI ---");
        Console.WriteLine("Lütfen bir meslek seçmek için numarasını girin:");

        List<Job> allJobs = JobManager.Instance.GetAvailableJobs();
        int jobIndex = 1;

        foreach (var job in allJobs)
        {
            Console.WriteLine($"\n[{jobIndex}] {job.Name}");
            Console.WriteLine($"  Maaş: ${job.Salary:N0}");
            Console.WriteLine($"  Açıklama: {job.Description}");
            Console.WriteLine($"  Başlangıç Eşyaları: {GetStartingItemsText(job.StartingItems)}");
            jobIndex++;
        }

        Console.WriteLine("-----------------------------");

        // UI'da oyuncunun yaptığı seçimi yakalama mantığı
        int choice;
        if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice <= allJobs.Count)
        {
            Job selectedJob = allJobs[choice - 1];
            _currentPlayer.ChangeJob(selectedJob);
            Console.WriteLine($"Tebrikler! Artık bir '{selectedJob.Name}'sin.");
        }
        else
        {
            Console.WriteLine("Geçersiz seçim yaptınız.");
        }
    }

    private string GetStartingItemsText(List<Item> items)
    {
        if (items.Count == 0)
        {
            return "Yok";
        }

        string itemNames = "";
        foreach (var item in items)
        {
            itemNames += item.Name + ", ";
        }
        return itemNames.TrimEnd(',', ' ');
    }
}
