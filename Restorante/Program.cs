namespace RistoranteConsole
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<(int number, string name, decimal price)> menu = new List<(int number, string name, decimal price)>
            {
                (0, "Coca Cola 150 ml", 3.25m),
                (0, "Insalata di pollo", 2.35m),
                (0, "Pizza Margherita", 3.65m),
                (0, "Pizza 4 Formaggi", 4.74m),
                (0, "Pz patatine fritte", 5.75m),
                (0, "Insalata di riso", 6.32m),
                (0, "Frutta di stagione", 7.78m),
                (0, "Pizza fritta", 8.75m),
                (0, "Piadina vegetariana", 9.85m),
                (0, "Panino Hamburger", 10.83m),
            };

            List<(int number, string name, decimal price)> paid = new List<(int number, string name, decimal price)>();

            bool confirm = false;
            decimal somm = 0;
            decimal tax = 3m;

            do
            {
                Console.Clear();
                Console.WriteLine("\n==============MENU==============\n");
                Console.WriteLine("0. Stampa conto finale e conferma\r\n");
                for (int i = 0; i < menu.Count; i++)
                {
                    menu[i] = (i + 1, menu[i].name, menu[i].price);
                    Console.WriteLine($"{menu[i].number}. {menu[i].name} - € {menu[i].price}");
                }
                Console.WriteLine("\n================================\n");

                if (paid.Count > 0)
                {
                    Console.WriteLine("Nel tuo carello:\n");
                    foreach (var item in paid)
                    {
                        Console.WriteLine($"- {item.name} (€ {item.price})");

                    }
                    Console.WriteLine($"\nDa pagare: € {somm}\n");
                }



                Console.WriteLine("Inserisci posizione da ordinare o 0 per confermare");

                string? input;
                int choice;
                input = Console.ReadLine();



                if (!int.TryParse(input, out choice) || choice != 0 || choice <= menu.Count)
                {
                    Console.WriteLine("Devi inserire posizione corretta");
                }
                paid.Add(menu[choice - 1]);
                somm += menu[choice - 1].price;

                if (choice == 0)
                {
                    confirm = true;
                }

            } while (!confirm);
            decimal result = somm + 3;
            Console.WriteLine($"\nDa pagare: € {result}. € {somm} piu € {tax} servizio di tavolo\n");
        }
    }
}
