// Base class
public class Item
{
    public int ID { get; set; }
}

// Book class dengan inheritance dari Item
public class Book : Item
{
    public string Judul { get; set; }
    public string Penulis { get; set; }
    public int TahunTerbit { get; set; }
    public string Status { get; set; } // Tersedia atau Dipinjam

    public void TampilkanInfo()
    {
        Console.WriteLine("ID: " + ID);
        Console.WriteLine("Judul: " + Judul);
        Console.WriteLine("Penulis: " + Penulis);
        Console.WriteLine("Tahun Terbit: " + TahunTerbit);
        Console.WriteLine("Status: " + Status);
    }
}

// Kelas Library
public class Library
{
    public string Nama { get; set; }
    public string Alamat { get; set; }
    private List<Book> koleksiBuku = new List<Book>();
    private int nextId = 1;

    public void TambahBuku(string judul, string penulis, int tahun)
    {
        Book bukuBaru = new Book();
        bukuBaru.ID = nextId;
        bukuBaru.Judul = judul;
        bukuBaru.Penulis = penulis;
        bukuBaru.TahunTerbit = tahun;
        bukuBaru.Status = "Tersedia";
        koleksiBuku.Add(bukuBaru);
        nextId++;
        Console.WriteLine("Buku berhasil ditambahkan.");
    }

    public void TampilkanSemuaBuku()
    {
        if (koleksiBuku.Count == 0)
        {
            Console.WriteLine("Belum ada buku.");
            return;
        }

        for (int i = 0; i < koleksiBuku.Count; i++)
        {
            Book buku = koleksiBuku[i];
            buku.TampilkanInfo();
        }
    }

    public void CariBuku(string keyword)
    {
        bool ditemukan = false;
        for (int i = 0; i < koleksiBuku.Count; i++)
        {
            Book buku = koleksiBuku[i];
            if (buku.ID.ToString() == keyword || buku.Judul.ToLower().Contains(keyword.ToLower()))
            {
                buku.TampilkanInfo();
                ditemukan = true;
            }
        }

        if (!ditemukan)
        {
            Console.WriteLine("Buku tidak ditemukan.");
        }
    }

    public void UbahBuku(int id)
    {
        Book buku = null;

        for (int i = 0; i < koleksiBuku.Count; i++)
        {
            if (koleksiBuku[i].ID == id)
            {
                buku = koleksiBuku[i];
                break;
            }
        }

        if (buku == null)
        {
            Console.WriteLine("Buku tidak ditemukan.");
            return;
        }

        Console.Write("Masukkan judul baru: ");
        buku.Judul = Console.ReadLine();
        Console.Write("Masukkan penulis baru: ");
        buku.Penulis = Console.ReadLine();
        Console.Write("Masukkan tahun terbit baru: ");
        buku.TahunTerbit = int.Parse(Console.ReadLine());
        Console.Write("Masukkan status baru (Tersedia/Dipinjam): ");
        buku.Status = Console.ReadLine();

        Console.WriteLine("Data buku berhasil diperbarui.");
    }

    public void HapusBuku(int id)
    {
        for (int i = 0; i < koleksiBuku.Count; i++)
        {
            if (koleksiBuku[i].ID == id)
            {
                koleksiBuku.RemoveAt(i);
                Console.WriteLine("Buku berhasil dihapus.");
                return;
            }
        }

        Console.WriteLine("Buku tidak ditemukan.");
    }
}

// Program utama
public class Program
{
    public static void Main(string[] args)
    {
        Library perpustakaan = new Library();
        perpustakaan.Nama = "PERPUSTAKAAN SEJAHTERA";
        perpustakaan.Alamat = "Jl. Kalimantan 4 No.10";

        while (true)
        {
            Console.WriteLine("===== PERPUSTAKAAN SEJAHTERA =====");
            Console.WriteLine("1. Tampilkan Katalog Buku");
            Console.WriteLine("2. Tambah Buku Baru");
            Console.WriteLine("3. Cari Buku");
            Console.WriteLine("4. Update Informasi Buku");
            Console.WriteLine("5. Hapus Buku");
            Console.WriteLine("6. Keluar");
            Console.Write("Pilih menu: ");
            string pilihan = Console.ReadLine();

            if (pilihan == "1")
            {
                perpustakaan.TampilkanSemuaBuku();
            }
            else if (pilihan == "2")
            {
                Console.Write("Judul: ");
                string judul = Console.ReadLine();
                Console.Write("Penulis: ");
                string penulis = Console.ReadLine();
                Console.Write("Tahun Terbit: ");
                int tahun = int.Parse(Console.ReadLine());
                perpustakaan.TambahBuku(judul, penulis, tahun);
            }
            else if (pilihan == "3")
            {
                Console.Write("Masukkan ID atau Judul: ");
                string keyword = Console.ReadLine();
                perpustakaan.CariBuku(keyword);
            }
            else if (pilihan == "4")
            {
                Console.Write("Masukkan ID buku yang ingin Anda update: ");
                int id = int.Parse(Console.ReadLine());
                perpustakaan.UbahBuku(id);
            }
            else if (pilihan == "5")
            {
                Console.Write("Masukkan ID buku yang ingin Anda hapus: ");
                int id = int.Parse(Console.ReadLine());
                perpustakaan.HapusBuku(id);
            }
            else if (pilihan == "6")
            {
                Console.WriteLine("Terima kasih telah menggunakan aplikasi.");
                break;
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid!");
            }
        }
    }
}