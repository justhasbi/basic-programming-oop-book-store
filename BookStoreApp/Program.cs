using System;
using System.Collections.Generic;

namespace BookStoreApp
{
    class Program
    {
        public static List<Books> books = new List<Books>();
        public static List<Purchases> purchases = new List<Purchases>();

        static void Main(string[] args)
        {
            books.Add(new Books { Name = "Harry Potter", Price = 75000, Author = "JK Rowling" });
            books.Add(new Books { Name = "Mahir Pemrograman", Price = 85000, Author = "Andi" });
            books.Add(new Books { Name = "Membuat Aplikasi C#", Price = 65000, Author = "Bagaskara" });
            books.Add(new Books { Name = "Membuat Aplikasi MVC", Price = 100000, Author = "Sonya Kumara" });
            books.Add(new Books { Name = "Fundamental Cyber Security", Price = 45000, Author = "John Man" });

            // purchases.Add(new Purchases { name = "coba", price = 2000, numberOfBook = 12, totalPricePerBook = 30000 });
            Menu();
        }


        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("PROGRAM KASIR TOKO BUKU");
            Console.WriteLine("====MENU====");
            Console.WriteLine("1. Tambahkan Buku");
            Console.WriteLine("2. Lihat Buku");
            Console.WriteLine("3. Hapus Buku");
            Console.WriteLine("4. Beli Buku");
            Console.WriteLine("5. Lihat Pembelian");
            Console.WriteLine("6. Hapus Pembelian");
            Console.WriteLine("==================");

            Console.WriteLine();

            Console.Write("Pilih Menu: ");
            try
            {
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        AddBook();
                        break;
                    case 2:
                        ShowCatalog();
                        break;
                    case 3:
                        DeleteBook();
                        break;
                    case 4:
                        BuyBook();
                        break;
                    case 5:
                        ViewPurchase();
                        break;
                    case 6:
                        DeletePurchase();
                        break;
                    default:
                        Console.WriteLine("Pilihan Tidak Ada dalam Daftar Menu");
                        RedirectToMenu();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR : {e.Message}");
                RedirectToMenu();
            }
        }

        public static void RedirectToMenu()
        {
            Console.ReadKey(true);
            Menu();
        }

        public static void BookList()
        {
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {books[i].Name}, {books[i].Author} - Rp. {books[i].Price}");
            }
        }

        public static void ShowCatalog()
        {
            Console.Clear();
            Console.WriteLine("Katalog Buku:\n");

            BookList();

            RedirectToMenu();
        }

        public static void DeleteBook()
        {
            Console.Clear();

            BookList();

            Console.WriteLine();

            Console.Write("Masukan Indeks Buku yang Akan Dihapus: ");
            try
            {
                int index = Convert.ToInt32(Console.ReadLine());

                Console.Clear();
                Console.Write("\nApakah Anda yakin? ");
                Console.WriteLine("Pilih y|n");

                string deleteOption = Console.ReadLine();

                if (deleteOption.Equals("y"))
                {
                    books.RemoveAt(index - 1);

                    Console.WriteLine("Buku Terhapus");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR: {e.Message}");
                Console.WriteLine("Gagal Menghapus Buku");
            }
            
            RedirectToMenu();
        }

        public static void AddBook()
        {

            Console.Clear();
            string option;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Tambahkan Buku");
                    Console.Write("Masukkan Judul Buku: ");
                    string bookName = Console.ReadLine();

                    Console.Write("\nMasukkan Harga Buku: ");
                    int price = Convert.ToInt32(Console.ReadLine());

                    Console.Write("\nMasukkan Author Buku: ");
                    string author = Console.ReadLine();

                    books.Add(new Books { Name = bookName, Price = price, Author = author });
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine($"Gagal Menambahkan Data, ERROR: {e.Message}");
                    RedirectToMenu();
                }

                Console.Clear();
                Console.WriteLine("Apakah Anda ingin menambahkan buku lagi? ");
                Console.WriteLine("Pilih y|n");
                option = Console.ReadLine();

            } while (option.Equals("y"));
            
            RedirectToMenu();
        }

        public static void BuyBook()
        {
            Console.Clear();
            string option;

            do
            {
                Console.Clear();
                Console.WriteLine("Katalog Buku:\n");
                BookList();

                try
                {
                    Console.WriteLine("Pilih indeks buku yang akan dibeli");
                    int bookIndex = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Masukan jumlah buku");
                    int numberOfBook = Convert.ToInt32(Console.ReadLine());

                    string bookTitle = books[bookIndex - 1].Name;
                    int price = books[bookIndex - 1].Price;

                    double totalPricePerBook = TotalPricePerBook(numberOfBook, price);

                    purchases.Add(new Purchases { Name = bookTitle, Price = price, NumberOfBook = numberOfBook, TotalPricePerBook = totalPricePerBook });
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine($"ERROR: {e.Message}");
                    RedirectToMenu();
                }
                Console.Clear();
                Console.WriteLine("Apakah Anda ingin membeli buku lagi? ");
                Console.WriteLine("Pilih y|n");
                option = Console.ReadLine();

            } while (option.Equals("y"));

            RedirectToMenu();
        }

        public static double TotalPricePerBook(int numberOfBook, int price)
        {
            double discount;

            if (numberOfBook >= 5)
            {
                discount = 0.05;
                double priceAfterDiscount = (price * numberOfBook) - ((price * numberOfBook) * discount);
                return priceAfterDiscount;
            }
            else if (numberOfBook >= 10)
            {
                discount = 0.1;
                double priceAfterDiscount = (price * numberOfBook) - ((price * numberOfBook) * discount);
                return priceAfterDiscount;
            } else
            {
                double priceAfterDiscount = (price * numberOfBook);
                return priceAfterDiscount;
            }
        }

        public static void Purchase()
        {
            if (purchases.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Keranjang kosong");
                RedirectToMenu();
            } else
            {
                Console.Clear();
                Console.WriteLine("Keranjang Pembelian Buku\n");
                Console.WriteLine("==================================");
                for (int i = 0; i < purchases.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {purchases[i].Name}\tRp. {purchases[i].Price}\t{purchases[i].NumberOfBook}\tRp. {purchases[i].TotalPricePerBook}");
                }
                Console.WriteLine("==================================");
                double totalPrice = TotalPrice();
                Console.WriteLine($"Total Pembayaran: Rp. {totalPrice}");
            }
        }

        public static void ViewPurchase()
        {
            if (purchases.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Keranjang kosong");
                RedirectToMenu();
            } 
            else
            {
                Purchase();
                RedirectToMenu();
            }
        }

        public static void DeletePurchase()
        {
            Console.Clear();

            Purchase();

            Console.WriteLine();

            try
            {
                Console.Write("Masukan Indeks Buku yang Akan Dihapus: ");
                int index = Convert.ToInt32(Console.ReadLine());

                Console.Clear();
                Console.Write("\nApakah Anda yakin? ");
                Console.WriteLine("Pilih y|n");

                string deleteOption = Console.ReadLine();

                if (deleteOption.Equals("y"))
                {
                    purchases.RemoveAt(index - 1);
                    Console.WriteLine("Buku terhapus dari keranjang");
                }

                RedirectToMenu();
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine($"Gagal Menghapus, ERROR: {e.Message}");
                RedirectToMenu();
            }
        }

        public static double TotalPrice()
        {
            double total = 0.0;

            for (int i = 0; i < purchases.Count; i++)
            {
                total += purchases[i].TotalPricePerBook;
            }
            return total;
        }
    }
}
