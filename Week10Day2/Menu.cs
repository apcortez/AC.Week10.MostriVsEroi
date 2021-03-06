using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week10Day2.AdoRepository;
using Week10Day2.Core;
using Week10Day2.Core.Entities;
using Week10Day2.MockRepository;

namespace Week10Day2
{
    public class Menu
    {
        private static readonly IBusinessLayer bl = new BusinessLayer(new UtentiRepository(), new EroiRepository(),
                                                                       new MostriRepository(), new CategoriaRepository(), new ArmaRepository());

        //ADORepository
        //private static readonly IBusinessLayer bl = new BusinessLayer(new UtentiSqlRepository(), new EroiSqlRepository(),
        //                                                               new MostriSqlRepository(), new CategoriaSqlRepository(), new ArmaSqlRepository());
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
                        Console.WriteLine("Arrivederci!");
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("Scelta sbagliata riprova");
                        break;
                }
                if (u != null)
                {       if (u.Id != 0)
                    {
                        MenuGiocatore(u);

                    }
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
                if (u.isAdmin)
                {
                    MenuAdmin(u);
                }
            }
        }
        #endregion

        #region MENU ADMIN
        private static void MenuAdmin(Utente u)
        {
            bool continuare = true;

            do
            {
                Console.WriteLine();
                Console.WriteLine("########## MENU GIOCATORE ADMIN #############");
                Console.WriteLine("Selezionare un operazione da eseguire:");
                Console.WriteLine("1 - Gioca");
                Console.WriteLine("2 - Crea nuovo eroe");
                Console.WriteLine("3 - Elimina eroe");
                Console.WriteLine("4 - Crea un nuovo mostro");
                Console.WriteLine("5 - Mostra classifica globale");
                Console.WriteLine("0 - Esci");
                Console.WriteLine("#############################################");

                Console.WriteLine();
                Console.WriteLine("Quale operazione vuoi scegliere?");
                string scelta = Console.ReadLine();
                Console.WriteLine();
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
                    case "4":
                        CreaMostro();
                        break;
                    case "5":
                        MostraClassifica();
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

        private static void MostraClassifica()
        {
            Console.WriteLine("########### CLASSIFICA ###############");
            List<Eroe> eroi = bl.FetchClassica();
            List<Utente> utenti = bl.FetchUtenti(eroi);
            int i = 1;
            foreach(var e in eroi)
            {
                Utente utente = utenti.Where(u => u.Id == e.IdGiocatore).FirstOrDefault();
                Console.WriteLine($"{i}) {e.Nome} - LVL: {e.Livello} - Punti: {e.PuntiAccumulati} - Giocatore: {utente.Username}");
                i++;
            }
        }
        #endregion
        #region MENU ADMIN METODI
        private static void CreaMostro()
        {
            try
            {
                Mostro nuovoMostro = new Mostro();
                nuovoMostro.Nome = InserisciNome();
                nuovoMostro._Categoria = InserisciCategoria("Mostro");
                nuovoMostro._Arma = InserisciArma(nuovoMostro._Categoria);
                nuovoMostro.Livello = InserisciLivello();
                if (bl.InsertMostro(nuovoMostro).Id != 0)
                {
                    Console.WriteLine($"Il mostro {nuovoMostro.Nome} è stato inserito correttamente");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static int InserisciLivello()
        {
            int livelloScelto;
            bool isInt;
            do
            {
                Console.WriteLine("Inserisci il livello del mostro tra 1 e 5: ");
                isInt = int.TryParse(Console.ReadLine(), out livelloScelto);
            } while (!isInt || livelloScelto>5 || livelloScelto <= 0);
            return livelloScelto;
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
                Console.WriteLine();
                switch (scelta)
                {
                    case "1":
                        Gioca(u);
                        if (u.isAdmin)
                        { continuare = false; }
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

        private static void Gioca(Utente u)
        {
            Eroe eroe = new Eroe();
            bool continuare;
            do
            {
                if (eroe != null)
                {
                    if (eroe.Id == 0)
                    {
                        
                        eroe = Pregioca(u, eroe);
                        if(eroe == null)
                        {
                            eroe = CreaEroe(u);
                        }
                }
                }
                
                Eroe eroeScelto = Gioca(u, eroe);
                Console.WriteLine("Vuoi continuare a giocare? Scrivi si per continuare");
                string risposta = Console.ReadLine().ToUpper();
                if (risposta == "SI")
                {
                    continuare = true;
                    Console.WriteLine("Vuoi continuare con lo stesso eroe? Scrivi si/no");
                    string sameEroe = Console.ReadLine().ToUpper();
                    if (sameEroe == "SI")
                    {
                            eroe = eroeScelto;
                    }
                    else
                    {
                        eroe = new Eroe();
                    }
                }
                else
                    continuare = false;
            } while (continuare);
        }

        private static Eroe Pregioca(Utente u, Eroe eroe)
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
                    eroe = eroi.ElementAt(sceltaEroe - 1);
                    return eroe;
                }
                else
                {
                    Console.WriteLine("Non hai nessun eroe nell'account. Creane uno.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
            #endregion

            #region MENU NORMALE METODI
            private static Eroe Gioca(Utente u, Eroe eroe)
            {
            
                        Mostro mostro = bl.GetRandomMostro(eroe.Livello);
                        int eroePV = eroe.PuntiVita;
                        int mostroPV = mostro.PuntiVita;
                        bool? fuga;
                        bool? risultato = IniziaBattaglia(eroe, mostro, out fuga);
                        eroe.PuntiVita = eroePV;
                        mostro.PuntiVita = mostroPV;
                        if (risultato == true) //caso vincita
                        {
                            Console.WriteLine("Hai vinto");
                            eroe.PuntiAccumulati += mostro.Livello * 10;
                            Console.WriteLine($"Punti accumulati: +{mostro.Livello * 10}");
                        }
                        else if (risultato == false) //caso perdita
                        {
                            Console.WriteLine("Hai perso!");
                        }
                        else //caso fuga
                        {
                            int punti = eroe.PuntiAccumulati;
                                Console.WriteLine("Bravo! Sei riuscito a fuggire dal mostro.");
                            if ((punti -= mostro.Livello * 5) >= 0)
                            {
                                eroe.PuntiAccumulati -= mostro.Livello * 5;
                                Console.WriteLine($"Punti accumulati : -{mostro.Livello * 5}");
                            }

                        }
                        CheckLivello(eroe);
                        if(eroe.Livello>=3 && u.isAdmin == false)
                        {
                            u.isAdmin = true;
                      
                        }
                        bl.UpdateEroe(eroe);

            return eroe;
           
        
        
        
        }

        private static void CheckLivello(Eroe eroe)
        {
            switch (eroe.Livello)
            {
                case 1:
                    if (eroe.PuntiAccumulati > 29)
                    {
                        eroe.Livello++;
                        eroe.PuntiAccumulati = 0;
                        eroe.PuntiVita = 40;

                    }
                    break;
                case 2:
                    if (eroe.PuntiAccumulati > 59)
                    {
                        eroe.Livello++;
                        eroe.PuntiAccumulati = 0;
                        eroe.PuntiVita = 60;
                    }
                    break;
                case 3:
                    if(eroe.PuntiAccumulati> 89)
                    {
                        eroe.Livello++;
                        eroe.PuntiAccumulati = 0;
                        eroe.PuntiVita = 80;
                        
                    }
                    break;
                case 4:
                    if (eroe.PuntiAccumulati > 119)
                    {
                        eroe.Livello++;
                        eroe.PuntiAccumulati = 0;
                        eroe.PuntiVita = 100;
                    }
                    break;
                case 5:
                    break;
            }
        }

        private static bool? IniziaBattaglia(Eroe eroe, Mostro mostro, out bool? fuga)
        {
            fuga = null;
            Console.WriteLine($"### {eroe.Nome.ToUpper()} vs {mostro.Nome.ToUpper()} ###");
            Console.WriteLine("############# START! ################");
            
            
            do
            {
                mostro.PuntiVita = TurnoEroe(eroe, mostro, out fuga);
                if((mostro.PuntiVita <= 0 && fuga == null) || fuga == true)
                {
                    break;
                }
                if(fuga == false)
                {
                    Console.WriteLine("Tentativo di fuga fallito.");
                    fuga = null;
                }
                eroe.PuntiVita = TurnoMostro(eroe, mostro);
            } while (eroe.PuntiVita > 0  && fuga == null);
            if (fuga == null)
            {
                if (eroe.PuntiVita <= 0 && mostro.PuntiVita > 0)
                {
                    return false;
                }
                else return true;
            }
            else
            {
                return null;
            }
        }
        private static int TurnoMostro(Eroe eroe, Mostro mostro)
        {
            Console.WriteLine($"E' il turno di {mostro.Nome}");
            eroe.PuntiVita -= mostro._Arma.PuntiDanno;

            Console.WriteLine($"Il mostro ti ha inflitto {mostro._Arma.PuntiDanno} danni");
            if (eroe.PuntiVita >= 0)
                { Console.WriteLine($"Tu ha ora {eroe.PuntiVita} hp\n"); }
            else
                { Console.WriteLine("Tu ha ora 0 hp\n"); }
            return eroe.PuntiVita;
        }

        private static int TurnoEroe(Eroe eroe, Mostro mostro, out bool? fuga)
        {
            fuga = null;
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
                    Console.WriteLine($"Hai inflitto al mostro {eroe._Arma.PuntiDanno} danni");
                    mostro.PuntiVita -= eroe._Arma.PuntiDanno;
                    if (mostro.PuntiVita >= 0)
                    {
                        Console.WriteLine($"Il mostro ha ora {mostro.PuntiVita} hp\n");
                    }
                    else
                    {
                        Console.WriteLine("Il mostro ha ora 0 hp\n");
                    }
                    break;
                case "2":
                    fuga = new Random().Next(100) % 2 == 0;
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

        private static Eroe CreaEroe(Utente u)
        {
            try
            {
                Eroe nuovoEroe = new Eroe();
                nuovoEroe.Nome = InserisciNome();
                nuovoEroe._Categoria = InserisciCategoria("Eroe");
                nuovoEroe.Livello = 1;
                nuovoEroe._Arma = InserisciArma(nuovoEroe._Categoria);
                nuovoEroe.IdGiocatore = u.Id;
                nuovoEroe = bl.InsertEroe(nuovoEroe);
                Console.WriteLine($"L'eroe {nuovoEroe.Nome} è stato inserito correttamente");
                return nuovoEroe;
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

        private static Categoria InserisciCategoria(string discriminator)
        {

            List<Categoria> categorie = bl.FetchCategoria(discriminator);
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
                Console.WriteLine("Inserisci nome: ");
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
                    if(user == null)
                    {
                        user = new Utente();
                    }
                } while (user.Id != 0);
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
                if (user.Id != 0)
                    return user;
                else
                {
                    Console.WriteLine("Username o password non validi");
                    return null;
                }
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
    