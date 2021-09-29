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
                                                                       new MostriRepository(), new CategoriaRepository(), new ArmaRepository());
        #region MENU PRINCIPALE
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
                    continuare = false;
                }
            } while (continuare);
        }
        
        
        private static void MenuGiocatore(Utente u)
        {
            if (u.isAdmin)
            {
                //MenuAdmin(u);
            }
            else
            {
                MenuNonAdmin(u);
            }
        }
        #endregion
        #region MENU NORMALE
        private static void MenuNonAdmin(Utente u)
        {
            bool continuare = true;

            do
            {
                Console.WriteLine();
                Console.WriteLine("############# MENU GIOCATORE ################");
                Console.WriteLine("Selezionare un operazione da eseguire:");
                Console.WriteLine("1 - Gioca");
                Console.WriteLine("2 - Crea nuovo eroe");
                Console.WriteLine("3 - Elimina eroe");
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
                        Console.WriteLine("Ciao alla prossima partita!");
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("Scelta sbagliata riprova");
                        break;
                }
            } while (continuare);
        }
        #endregion

        #region MENU NORMALE METODI
        private static void Gioca(Utente u)
        {
            try
            {
                List<Eroe> eroi = bl.FetchEroi(u);
                if (eroi.Count() != 0)
                {
                    int i = 1;
                    foreach (var e in eroi)
                    {
                        Console.WriteLine($"{i} - {e.Print()}");
                        i++;
                    }
                    int sceltaEroe;
                    bool isInt;
                    do
                    {
                        Console.WriteLine("Quale eroe vuoi scegliere? Inserisci il numero.");
                        isInt = int.TryParse(Console.ReadLine(), out sceltaEroe);
                    } while (!isInt || sceltaEroe > eroi.Count() || sceltaEroe <= 0);
                    Eroe eroe = eroi.ElementAt(sceltaEroe - 1);
                    Mostro mostro = bl.GetRandomMostro(eroe.Livello);
                    bool risultato = IniziaBattaglia(eroe, mostro);
                    if (risultato)
                    {
                        Console.WriteLine("Hai vinto");
                        eroe.PuntiAccumulati += mostro.Livello * 10;
                        bl.UpdateEroe(eroe);
                    }
                    else
                    {
                        Console.WriteLine("Hai perso!");
                    }
                }
                else
                {
                    Console.WriteLine("Non hai nessun eroe nell'account. Creane uno.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static bool IniziaBattaglia(Eroe eroe, Mostro mostro)
        {
            Console.WriteLine($"### {eroe.Nome.ToUpper()} vs {mostro.Nome.ToUpper()} ###");
            Console.WriteLine("############# START! ################");
            do
            {
                mostro.PuntiVita = TurnoEroe(eroe, mostro);
                if(mostro.PuntiVita <= 0)
                {
                    break;
                }
                eroe.PuntiVita = TurnoMostro(eroe, mostro);
            } while (eroe.PuntiVita > 0 || mostro.PuntiVita > 0);
            if (eroe.PuntiVita <= 0 && mostro.PuntiVita > 0)
            {
                return false;
            }
            else return true;

            }
        private static int TurnoMostro(Eroe eroe, Mostro mostro)
        {
            Console.WriteLine($"E' il turno di {mostro.Nome}");
            eroe.PuntiVita -= mostro._Arma.puntiDanno;
            Console.WriteLine($"Il mostro ti ha inflitto {eroe._Arma.puntiDanno} danni");
            Console.WriteLine($"Tu ha ora {mostro.PuntiVita} hp\n");
            return eroe.PuntiVita;
        }

        private static int TurnoEroe(Eroe eroe, Mostro mostro)
        {
            Console.WriteLine("E' il tuo turno. Cosa vuoi fare?");
            Console.WriteLine("1 - Attacca! ");
            Console.WriteLine("2 - Tenta la fuga");
            string scelta;
            do
            {
                scelta = Console.ReadLine();
            } while (scelta != "1" && scelta != "2");
            switch (scelta)
            {
                case "1":
                    mostro.PuntiVita -= eroe._Arma.puntiDanno;
                    Console.WriteLine($"Hai inflitto al mostro {eroe._Arma.puntiDanno} danni");
                    Console.WriteLine($"Il mostro ha ora {mostro.PuntiVita} hp\n");
                    break;
                case "2":
                    //Fuga(eroe);
                    break;
            }
            return mostro.PuntiVita;
        }

        private static void EliminaEroe(Utente u)
        {
            try
            {   
                List<Eroe> eroi = bl.FetchEroi(u);
                if (eroi.Count() != 0)
                {
                    int i = 1;
                    foreach (var e in eroi)
                    {
                        Console.WriteLine($"{i} - {e.Print()}");
                        i++;
                    }
                    int sceltaEroe;
                    bool isInt;
                    do
                    {
                        Console.WriteLine("Quale eroe vuoi eliminare? Inserisci il numero.");
                        isInt = int.TryParse(Console.ReadLine(), out sceltaEroe);
                    } while (!isInt || sceltaEroe > eroi.Count() || sceltaEroe <= 0);
                    Eroe eroe = eroi.ElementAt(sceltaEroe - 1);
                    Console.WriteLine(bl.EliminaEroe(eroe));
                }
                else
                {
                    Console.WriteLine("Non hai nessun eroe nell'account. Creane uno.");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private static void CreaEroe(Utente u)
        {
            try
            {
                Eroe nuovoEroe = new Eroe();
                nuovoEroe.Nome = InserisciNome();
                nuovoEroe._Categoria = InserisciCategoria();
                nuovoEroe._Arma = InserisciArma(nuovoEroe._Categoria);
                nuovoEroe.IdGiocatore = u.Id;
                if (bl.InsertEroe(nuovoEroe).Id != 0)
                {
                    Console.WriteLine($"L'eroe {nuovoEroe.Nome} è stato inserito correttamente");
                }
            }catch(Exception ex)
            {
                throw ex;
            }


        }

        private static Arma InserisciArma(Categoria categoria)
        {
            List<Arma> armi = bl.FetchArma(categoria);
            int i = 1;
            foreach (var a in armi)
            {
                Console.WriteLine($"{i} - {a.Print()}");
                i++;
            }
            int armaScelta;
            bool isInt;
            do
            {
                Console.WriteLine("Quale arma vuoi selezionare? Inserisci il numero");
                isInt = int.TryParse(Console.ReadLine(), out armaScelta);
            } while (!isInt || armaScelta > armi.Count() || armaScelta <= 0);
            Arma arma = armi.ElementAt(armaScelta - 1);
            return arma;
        }

        private static Categoria InserisciCategoria()
        {

            List<Categoria> categorie = bl.FetchCategoria("Eroe");
            int i = 1;
            foreach(var c in categorie)
            {
                Console.WriteLine(i + " - " + c.Nome);
                i++;
            }
            int categoriaScelta;
            bool isInt;
            do
            {
                Console.WriteLine("Quale eroe vuoi selezionare? Inserisci il numero");
                isInt = int.TryParse(Console.ReadLine(), out categoriaScelta);
            } while (!isInt || categoriaScelta > categorie.Count() || categoriaScelta <= 0);
            Categoria categoria = categorie.ElementAt(categoriaScelta - 1);
            return categoria;
        }

        private static string InserisciNome()
        {
            string nome = String.Empty;
            do
            {
                Console.WriteLine("Inserisci nome eroe: ");
                nome = Console.ReadLine();

            } while (String.IsNullOrEmpty(nome));
            return nome;
        }

        #endregion


        #region MENU PRINCIPALE METODI
        private static Utente Registrati()
        {
            Utente user = new Utente();
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
                user = new Utente(username, password);
                if (bl.InsertUser(user) != null)
                {
                    Console.WriteLine("Registrazione avvenuta con successo.");
                }
                else
                {
                    Console.WriteLine("Errore nella fase di registrazione. Riprova.");
                }

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
    