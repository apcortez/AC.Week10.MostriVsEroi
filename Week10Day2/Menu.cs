using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week10Day2.Core;
using Week10Day2.Core.Entities;
using Week10Day2.MockRepository;

namespace Week10Day2
{
    public class Menu
    {
        private static readonly IBusinessLayer bl = new BusinessLayer(new UtentiRepository(), new EroiRepository(),
                                                                       new MostriRepository());
        internal static void Start()
        {
            bool continuare = true;
            Console.WriteLine("################# BENVENUTO! ################");
            do
            {
                Console.WriteLine();
                Console.WriteLine("#############################################");
                Console.WriteLine("Selezionare un operazione da eseguire:");
                Console.WriteLine("1 - Accedi");
                Console.WriteLine("2 - Registrati");
                Console.WriteLine("0 - Esci");
                Console.WriteLine("#############################################");

                Console.WriteLine();
                Console.WriteLine("Quale operazione vuoi scegliere?");
                string scelta = Console.ReadLine();
                Utente u = new Utente();
                switch (scelta)
                {
                    case "1":
                        u = Accedi();
                        break;
                    case "2":
                        u = Registrati();
                        break;
                    case "0":
                        Console.WriteLine("Ciao alla prossima partita!");
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("Scelta sbagliata riprova");
                        break;
                }

                if (u != null)
                {
                    MenuGiocatore(u);
                }
            } while (continuare);
        }

        private static void MenuGiocatore(Utente u)
        {
            if (u.isAdmin)
            {
                MenuAdmin(u);
            }
            else
            {
                MenuNonAdmin(u);
            }
        }

        private static void MenuNonAdmin(Utente u)
        {
            bool continuare = true;

            do
            {
                Console.WriteLine("############# MENU GIOCATORE ################");
                Console.WriteLine("Selezionare un operazione da eseguire:");
                Console.WriteLine("1 - Gioca");
                Console.WriteLine("2 - Crea nuovo eroe");
                Console.WriteLine("2 - Elimina eroe");
                Console.WriteLine("0 - Esci");
                Console.WriteLine("#############################################");

                Console.WriteLine();
                Console.WriteLine("Quale operazione vuoi scegliere?");
                string scelta = Console.ReadLine();
                switch (scelta)
                {
                    case "1":
                        Gioca(u);
                        break;
                    case "2":
                        CreaEroe(u);
                        break;
                    case "3":
                        EliminaEroe(u);
                        break;
                    case "0":
                        Console.WriteLine("Arrivederci. A presto!");
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("Scelta sbagliata riprova");
                        break;
                }
            } while (continuare);
        }
        #region MENU-GIOCATORE
        private static void EliminaEroe(Utente u)
        {
            throw new NotImplementedException();
        }

        private static void CreaEroe(Utente u)
        {
            throw new NotImplementedException();
        }


        //pending GIOCA
        private static void Gioca(Utente u)
        {
            List<Eroe> eroi = bl.FetchEroi(u);
            foreach(var e in eroi)
            {
                Console.WriteLine(e.Id + " - " + e.Nome + e._Categoria);
            }
            Console.WriteLine("Quale eroe vuoi scegliere? Inserisci l'Id.");
            int sceltaEroe = int.Parse(Console.ReadLine());
        }

        #endregion
        #region MENU
        private static Utente Registrati()
        {
            Utente user;
            string username;
            string password;
            try
            {
                do
                {
                    username = InserisciUsername();
                    password = InserisciPassword();
                    user = bl.GetUtente(username);
                } while (user != null);
                user.Password = password;
                user = bl.InsertUser(user);
                Console.WriteLine("Registrazione avvenuta con successo.");
                return user;
            } catch (Exception ex)
            {
                throw ex;
            }
        }
        private static Utente Accedi()
        {
            string username = InserisciUsername();
            string password = InserisciPassword();
            Utente user = bl.AccediUtente(username, password);
            if (user != null)
            {
                return user;
            }
            else
            {
                Console.WriteLine("Username o password non validi");
                return null;
            }
        }
        private static string InserisciPassword()
        {
            string password = String.Empty;
            do
            {
                Console.WriteLine("Password: ");
                password = Console.ReadLine();

            } while (String.IsNullOrEmpty(password));
            return password;
        }

        private static string InserisciUsername()
        {
            string user = String.Empty;
            do
            {
                Console.WriteLine("Username: ");
                user = Console.ReadLine();

            } while (String.IsNullOrEmpty(user));
            return user;
        }


    }
    #endregion
}
    