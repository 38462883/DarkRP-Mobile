using System.Collections.Generic;
using System;

public class JobManager
{
    public static JobManager Instance { get; private set; }

    private List<Job> _allJobs;
    public Job DefaultJob { get; private set; }

    public JobManager()
    {
        Instance = this;
        _allJobs = new List<Job>();

        // Oyunda kullanılacak temel eşyaları tanımlıyoruz
        Item pistol = new Item("pistol_id", "Tabanca", "Kendini savunmak için kullanılan basit bir silahtır.");
        Item shotgun = new Item("shotgun_id", "Pompalı Tüfek", "Yakın mesafede ölümcül olan ağır bir silahtır.");
        Item assaultRifle = new Item("assault_rifle_id", "Saldırı Tüfeği", "Hızlı ateş eden ve güçlü bir silahtır.");
        Item medkit = new Item("medkit_id", "İlk Yardım Kiti", "Yaralıları tedavi etmek için kullanılır.");
        Item handcuffs = new Item("handcuffs_id", "Kelepçe", "Suçluları tutuklamak için kullanılır.");
        Item lockpick = new Item("lockpick_id", "Maymuncuk", "Kapıları ve kasaları açmaya yarar.");
        Item moneyPrinter = new Item("money_printer_id", "Para Makinesi", "Yasadışı bir şekilde para üretir.");

        // --- Statüye Göre Ayarlanmış Meslekler ---
        DefaultJob = new Job("Vatandaş", "Sıradan bir şehir sakini.", 5000, new List<Item>());
        _allJobs.Add(DefaultJob);
        Job thief = new Job("Hırsız", "Gizlice eşyaları çalar ve hurdacıya satar.", 10000, new List<Item> { lockpick });
        _allJobs.Add(thief);
        Job gunDealer = new Job("Silahçı", "Oyunculara yasal, hafif silahlar satar.", 15000, new List<Item>());
        _allJobs.Add(gunDealer);
        Job junkDealer = new Job("Hurdacı", "Hırsızların çaldığı malları satın alır ve işler.", 20000, new List<Item>());
        _allJobs.Add(junkDealer);
        Job prostitute = new Job("Fahişe", "İnsanları kandırarak paralarını çalarak hayatını sürdürür.", 25000, new List<Item>());
        _allJobs.Add(prostitute);
        Job mercenary = new Job("Paralı Asker", "Para karşılığında koruma veya öldürme görevleri üstlenir.", 30000, new List<Item> { shotgun });
        _allJobs.Add(mercenary);
        Job policeOfficer = new Job("Polis Memuru", "Kanun ve düzeni sağlar. Suçluları yakalarsa ödül kazanır.", 35000, new List<Item> { pistol, handcuffs });
        _allJobs.Add(policeOfficer);
        Job blackMarketDealer = new Job("Karaborsacı", "Ağır teçhizatlı yasadışı silahlar satar.", 50000, new List<Item>());
        _allJobs.Add(blackMarketDealer);
        Job mafia = new Job("Mafya", "Yasadışı işler yapar ve dükkanlardan haraç alır.", 60000, new List<Item> { pistol, moneyPrinter });
        _allJobs.Add(mafia);
        Job bodyguard = new Job("Başkanın Koruması", "Başkanı canı pahasına korur.", 75000, new List<Item> { shotgun });
        _allJobs.Add(bodyguard);
        Job mercenaryLeader = new Job("Paralı Asker Lideri", "Paralı asker grubunu yönetir ve büyük sözleşmeler alır.", 85000, new List<Item> { assaultRifle });
        _allJobs.Add(mercenaryLeader);
        Job hitman = new Job("Hitman", "Para karşılığında suikast düzenler.", 100000, new List<Item> { pistol });
        _allJobs.Add(hitman);
        Job president = new Job("Başkan", "Şehrin en üst yöneticisi. İstediği kişiyi hapse atabilir.", 150000, new List<Item> { assaultRifle });
        _allJobs.Add(president);
    }
    
    public List<Job> GetAvailableJobs()
    {
        return new List<Job>(_allJobs);
    }
    
    public Job GetJobByName(string jobName)
    {
        foreach(var job in _allJobs)
        {
            if(job.Name == jobName)
            {
                return job;
            }
        }
        return null;
    }
}
