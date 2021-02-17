using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giereczka_vol._2
{
    class Program
    {
        static void wprowadzenie()
        {
            Console.WriteLine("                                  WPROWADZENIE:                                           ");
            Console.WriteLine("==========================================================================================");
            Console.WriteLine("Witaj graczu w Giereczka BETA 1.1");
            Console.WriteLine("To jest krótkie wprowadzenie abyś mógł poznać zasady gry");
            Console.WriteLine("Celem gry jest rozbudowa imperium oraz pokonanie 5 przeciwników");
            Console.WriteLine("opcję musisz niestety samemu wpisywać i zatwierdzać przyciskiem ENTER");
            Console.WriteLine("Po pokonaniu każdego przeciwnika wypadają zasoby :)");
            Console.WriteLine("Dbaj o ekonomie oraz pokonaj każdego przeciwnika aby ukonczyć grę");
            Console.WriteLine("Możesz kupować budynki generujące zasoby oraz jednostki");
            Console.WriteLine("Każda czynność trwa 1 dzień");
            Console.WriteLine("Swoje surowce oraz jednostki będziesz miał wyświetlone na planszy dalej");
            Console.WriteLine("Punkty potęgi pokazują czy jesteś gotowy na walkę z przeciwnikiem");
            Console.WriteLine("Są 4 poziomy pokazywania czy jesteś gotowy na wroga");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("* Bardzo łatwy");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("* Masz spore szanse");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("* Wyrównana walka");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("* Bardzo trudny");
            Console.ResetColor();
            Console.WriteLine("Niedopuść, aby Twoje zasoby spadły poniżej 0 ponieważ przegrasz");
            Console.WriteLine("                                  CENNIK:                                           ");
            Console.WriteLine("==========================================================================================");
            Console.WriteLine("Tartak: -50drewno, -25kamień -25złoto");
            Console.WriteLine("Kamieniołom: -40drewno, -30kamień, -30złoto");
            Console.WriteLine("Mennica: -45drewno, -35kamień, -33złoto");
            Console.WriteLine("Chłopi: ilość:5, atak:1(każdy), -22drewno, -10kamień, -20złoto");
            Console.WriteLine("Wojownicy: ilość:3, atak:2(każdy), -45drewno, -25kamień, -35złoto");
            Console.WriteLine("Dotacja na krucjate: dodaje 2 krzyżowców: atak:5(każdy), -85drewno, -55kamień, -70złoto");
            Console.WriteLine("Mutant: ilość:1, atak:7, -110drewno, -92kamień, -130złoto");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Aby przejść dalej wciśnij ENTER");
        }
    
        static void Main(string[] args)             
        {
            int drewno = 300, kamień = 200, złoto = 200, tartak = 1, kkamień = 1, mennica = 1;
            int chłop = 10, wojownik = 5, krzyżowiec = 0, mutant = 0;
            int siła = 0;
            int punkty = 0;
            int win = 0;
            int tydzień = 0, dzień = 1;
            // wczytanie danych
            Console.WriteLine("Witaj w Giereczka");
            Console.WriteLine("1. Nowa Gra");
            Console.WriteLine("2. Wczytaj Gre");
            Console.WriteLine("3. Autorzy");
            Console.WriteLine("4. Wyjście z Gry");
            while (true)
            {
                #region Obsługa Wyjątków 1
                int wybór = 0; //nadanie wartości ponieważ brak zasięgu
                while (true)
                {
                    try
                    {
                        wybór = int.Parse(Console.ReadLine()); // przypisanie wartości i sprawdzenie powstania wyjątku
                        break; // musi być break; ponieważ nie przechodzi dalej
                    }
                    catch (Exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Proszę wybraę odpowiednię opcję!!");
                        Console.ResetColor();
                    }
                }
                #endregion

                switch (wybór)
                {
                    #region MainSwitch
                    case 1:
                        wprowadzenie();
                        System.Console.ReadKey(true);
                        Console.Clear();
                        Console.WriteLine("Podaj swój nick bohaterze");
                        string nick = Console.ReadLine();
                        // Powitanie Gracza

                        for (; ; )
                        {
                            #region infinite mode

                            if (nick == "Pietras")
                            {
                                nick = "Infinite mode";
                                drewno = 250000;
                                kamień = 250000;
                                złoto = 250000;
                            }
                            else

                                if (nick == "Pietrasfull")
                            {
                                nick = "Infinite mode ++";
                                drewno = 250000;
                                kamień = 250000;
                                złoto = 250000;
                                tartak = 200;
                                kkamień = 200;
                                mennica = 200;
                            }
                            else
                            if (nick == "Warmode")
                            {
                                nick = "Infinite War Mode";
                                drewno = 250000;
                                kamień = 250000;
                                złoto = 250000;
                                tartak = 200;
                                kkamień = 200;
                                mennica = 200;
                                chłop = 1000;
                                wojownik = 400;
                                krzyżowiec = 400;
                                mutant = 280;
                            }
                            else
                            #endregion

                            #region Warunek przegrania
                        if (drewno < 0 || kamień < 0 || złoto < 0)
                            {
                                Console.WriteLine("                    PRZEGRAŁEŚ                        ");
                                Console.WriteLine("Pilnuj ekonomii !!!!");
                                Console.WriteLine("Zdobyte punkty: " + punkty);
                                System.Environment.Exit(1);
                            }
                            else
                            #endregion

                            #region warunek wygrania
                        if (win == 5)
                            {
                                Console.WriteLine("Gratulajce " + nick);
                                Console.WriteLine("Pokonałeś Każdego przeciwnika w grze i zostałeś niezwyciężony");
                                Console.WriteLine("Twoje Statystyki: ");
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine("ilość zdobytych punktów: " + punkty);
                                Console.WriteLine("Spędzone tygodnie: " + tydzień + " Spędzone dni: " + dzień);
                                Console.WriteLine("                                                                 ZASOBY                                           ");
                                Console.WriteLine("==================================================================================================================================================");
                                Console.WriteLine("Pozostałe drewno: " + drewno + " Pozostały kamień: " + kamień + " Pozostałe złoto: " + złoto);
                                Console.WriteLine("==================================================================================================================================================");
                                Console.WriteLine("                                                                 BUDYNKI                   ");
                                Console.WriteLine("==================================================================================================================================================");
                                Console.WriteLine("Pozostałe tartaki: " + tartak + " Pozostałe kamieniołomy: " + kkamień + " Pozostałe mennice: " + mennica);
                                Console.WriteLine("==================================================================================================================================================");
                                Console.WriteLine("                                                                 JEDNOSTKI                  ");
                                Console.WriteLine("==================================================================================================================================================");
                                Console.WriteLine("Pozostali chłopi: " + chłop + " Pozostali wojownicy: " + wojownik + " Pozostali krzyżowcy: " + krzyżowiec + " Pozostali mutanci: " + mutant);
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine("WCIŚNIJ DOWOLNY KLAWISZ, ABY ZAKONCZYĆ GRE");
                                System.Console.ReadKey(true);
                                System.Environment.Exit(1);
                            }
                            else
                            #endregion

                            #region licznik_tygodni
                    if (dzień >= 8)
                            {
                                dzień = 1; tydzień++;
                                punkty += 5;
                            }
                            else
                                #endregion

                            siła = chłop + (wojownik * 2) + (krzyżowiec * 5) + (mutant * 7);
                            drewno += tartak * 4;
                            kamień += kkamień * 3;
                            złoto += mennica * 2;
                            // obliczanie ptk siły w for(;;)
                            Console.WriteLine("Gracz: " + nick);
                            Console.WriteLine("tydzień: " + tydzień + " dzień: " + dzień);
                            Console.WriteLine("=====================================================================");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Twoje surowce: ");
                            Console.ResetColor();

                            #region kolorki zasoby
                            if (drewno <= 50)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Twoje Drewno: " + drewno);
                                Console.ResetColor();
                            }
                            else
                           if (drewno <= 50)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Twój kamień: " + kamień);
                                Console.ResetColor();
                            }
                            else
                           if (drewno <= 50)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Twoje złoto: " + złoto);
                                Console.ResetColor();
                            }
                            else

                                #endregion

                            Console.WriteLine("Twoje Drewno: " + drewno);
                            Console.WriteLine("Twój kamień: " + kamień);
                            Console.WriteLine("Twoje złoto: " + złoto);
                            Console.WriteLine("Twoje Tartaki: " + tartak);
                            Console.WriteLine("Twoje Kamieniołomy: " + kkamień);
                            Console.WriteLine("Twoje Mennice: " + mennica);
                            Console.WriteLine("=====================================================================");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Twoje Jednostki: ");
                            Console.ResetColor();
                            Console.WriteLine("Twoi chłopi: " + chłop);
                            Console.WriteLine("Twoi wojownicy: " + wojownik);
                            Console.WriteLine("Twoi krzyzowcy: " + krzyżowiec);
                            Console.WriteLine("Twoi mutanci: " + mutant);

                            #region kolor_siła
                            if (siła >= 3000)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Twoje punkty potegi: " + siła);
                                Console.ResetColor();
                            }
                            else
                                #endregion

                                Console.WriteLine("Twoje punkty potęgi: " + siła);
                            // wyświetlanie danych
                            #region opcję rozgrywki
                            Console.WriteLine("");
                            Console.WriteLine("1. Kup Tartak");
                            Console.WriteLine("2. Kup kamieniołom");
                            Console.WriteLine("3. Kup Mennice");
                            Console.WriteLine("4. Kup chłopów");
                            Console.WriteLine("5. Kup wojowników");
                            Console.WriteLine("6. Dotacje na krucjate");
                            Console.WriteLine("7. Kup mutanta");
                            Console.WriteLine("8. Pomin ture");
                            Console.WriteLine("9. Zapisz Gre");
                            Console.WriteLine("10. Walka z przeciwnikami");
                            Console.WriteLine("0. wyjśćie z gry");

                            #region Obsługa Wyjątków 2
                            int wybór2 = 0; //nadanie wartosci poniewaz brak zasiegu
                            while (true)
                            {
                                try
                                {
                                    wybór2 = int.Parse(Console.ReadLine()); // przypisanie wartosci i sprawdzenie powstania wyjatku
                                    break; // musi byc break; poniewaz nie przechodzi dalej
                                }
                                catch (Exception)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Proszę wybrać odpowiednią opcję!!");
                                    Console.ResetColor();
                                }
                            }
                            #endregion

                            #endregion
                            #region rozgrywkaswitch
                            switch (wybór2)
                            {
                                case 1:
                                    tartak++;
                                    drewno -= 50;
                                    kamień -= 25;
                                    złoto -= 25;
                                    Console.WriteLine("Kupileś Tartak");
                                    Console.WriteLine("Drewno -50, kamień -25, złoto -25");
                                    Console.WriteLine("");
                                    Console.WriteLine("Aby przejść dalej wciśnij ENTER");
                                    System.Console.ReadKey(true);
                                    Console.Clear();
                                    dzień++;
                                    punkty += 10;
                                    break;

                                case 2:
                                    kkamień++;
                                    drewno -= 40;
                                    kamień -= 30;
                                    złoto -= 30;
                                    Console.WriteLine("Kupiłeś kamieniołom");
                                    Console.WriteLine("Drewno -40, kamień -30, złoto -30");
                                    Console.WriteLine("");
                                    Console.WriteLine("Aby przejść dalej wciśnij ENTER");
                                    System.Console.ReadKey(true);
                                    Console.Clear();
                                    dzień++;
                                    punkty += 15;
                                    break;

                                case 3:
                                    mennica++;
                                    drewno -= 45;
                                    kamień -= 35;
                                    złoto -= 33;
                                    Console.WriteLine("Kupiłeś mennice");
                                    Console.WriteLine("Drewno -45, kamień -35, złoto -33");
                                    Console.WriteLine("");
                                    Console.WriteLine("Aby przejść dalej wciśnij ENTER");
                                    System.Console.ReadKey(true);
                                    Console.Clear();
                                    dzień++;
                                    punkty += 15;
                                    break;

                                case 4:
                                    chłop = chłop + 5;
                                    drewno -= 22;
                                    kamień -= 10;
                                    złoto -= 20;
                                    Console.WriteLine("Kupiłeś grupę chłopów");
                                    Console.WriteLine("Drewno -22, kamień -10, złoto -20");
                                    Console.WriteLine("Dodano 5 chłopów");
                                    Console.WriteLine("");
                                    Console.WriteLine("Aby przejść dalej wciśnij ENTER");
                                    System.Console.ReadKey(true);
                                    Console.Clear();
                                    dzień++;
                                    punkty += 5;
                                    break;

                                case 5:
                                    wojownik = wojownik + 3;
                                    drewno -= 45;
                                    kamień -= 25;
                                    złoto -= 35;
                                    Console.WriteLine("Kupiłeś kilku wojowników");
                                    Console.WriteLine("Drewno -45, kamień -25, złoto -35");
                                    Console.WriteLine("Dodano 3 wojowników");
                                    Console.WriteLine("");
                                    Console.WriteLine("Aby przejść dalej wciśnij ENTER");
                                    System.Console.ReadKey(true);
                                    Console.Clear();
                                    dzień++;
                                    punkty += 5;
                                    break;

                                case 6:
                                    krzyżowiec = krzyżowiec + 2;
                                    drewno -= 85;
                                    kamień -= 55;
                                    złoto -= 70;
                                    Console.WriteLine("Dałeś dotację na słuszny cel");
                                    Console.WriteLine("Twoje zasługi nie zostaną zapomniane");
                                    Console.WriteLine("Do Twojej armii dołączają krzyżowcy w ilośći 2 w ramach podzięki");
                                    Console.WriteLine("");
                                    Console.WriteLine("Aby przejść dalej wciśnij ENTER");
                                    System.Console.ReadKey(true);
                                    Console.Clear();
                                    punkty += 8;
                                    dzień++;
                                    break;

                                case 7:
                                    mutant++;
                                    drewno -= 110;
                                    kamień -= 92;
                                    złoto -= 130;
                                    Console.WriteLine("Zakupiłeś najgroźniejszego potwora w grze");
                                    Console.WriteLine("Możesz teraz budzić postrach");
                                    Console.WriteLine("");
                                    Console.WriteLine("Aby przejść dalej wciśnij ENTER");
                                    System.Console.ReadKey(true);
                                    Console.Clear();
                                    dzień++;
                                    punkty += 15;

                                    break;

                                case 8:
                                    Console.WriteLine("Pominąłeś ture");
                                    Console.WriteLine("");
                                    Console.WriteLine("Aby przejść dalej wciśnij ENTER");
                                    System.Console.ReadKey(true);
                                    Console.Clear();
                                    dzień++;
                                    break;

                                case 9:
                                    Console.WriteLine("Już nie długo");
                                    Console.WriteLine("");
                                    Console.WriteLine("Aby przejść dalej wciśnij ENTER");
                                    break;

                                #region walka


                                case 10:
                                    Console.WriteLine("                 TRYB WALKI                       ");
                                    Console.WriteLine("Wybierz przeciwnika z którym chcesz walczyć");
                                    Console.WriteLine("1. Upadły smok");
                                    Console.WriteLine("2. Górski trol");
                                    Console.WriteLine("3. Dalaver Gruhn'a Yrcen Medvin");
                                    Console.WriteLine("4. Czarnoksiężnik z krainy Oz");
                                    Console.WriteLine("5. Falagrim von Gorazin");
                                    Console.WriteLine("6. Ucieczka");

                                        #region Obsługa Wyjątków 3 WALKA
                                    int x = 0; //nadanie wartości ponieważ brak zasięgu
                                    while (true)
                                    {
                                        try
                                        {
                                            x = int.Parse(Console.ReadLine()); // przypisanie wartości i sprawdzenie powstania wyjątku
                                            break; // musi być break; ponieważ nie przechodzi dalej
                                        }
                                        catch (Exception)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Proszę wybrać odpowiednią opcję!!");
                                            Console.ResetColor();
                                        }
                                    }
                                    #endregion

                                        #region Upadły smok
                                    switch (x)
                                    {
                                        case 1:
                                            Console.WriteLine("Upadły smok");
                                            Console.WriteLine("Poziom bosa to: ");
                                            Console.WriteLine(" ");
                                            Console.WriteLine(" ");
                                            if (siła < 20)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.WriteLine("Bardzo trudny");
                                                Console.ResetColor();
                                            }
                                            else if (siła >= 21 && siła <= 47)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.WriteLine("Wyrównana walka");
                                                Console.ResetColor();
                                            }
                                            else if (siła >= 48 && siła <= 60)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                Console.WriteLine("Masz spore szanse");
                                                Console.ResetColor();
                                            }

                                            else
                                                Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Bardzo łatwy");
                                            Console.ResetColor();

                                            Console.WriteLine(" ");
                                            Console.WriteLine("Chcesz walczyć?");
                                            Console.WriteLine("1. Atakuję");
                                            Console.WriteLine("2. Wycofuję się ");

                                            #region Obsługa Wyjątków 4
                                            int p = 0; //nadanie wartosci poniewaz brak zasiegu
                                            while (true)
                                            {
                                                try
                                                {
                                                    p = int.Parse(Console.ReadLine()); // przypisanie wartosci i sprawdzenie powstania wyjatku
                                                    break; // musi byc break; poniewaz nie przechodzi dalej
                                                }
                                                catch (Exception)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Proszę wybrać odpowiednią opcję!!");
                                                    Console.ResetColor();
                                                }
                                            }
                                            #endregion

                                            if (p == 1)
                                            {
                                                if (siła > 998)
                                                {
                                                    Console.WriteLine("Gratulacje pokonałeś Upadłego smoka");
                                                    Console.WriteLine("Niestety śmierć poniosło kilka twoich jednostek");
                                                    Console.WriteLine("Zdobyłeś za pokonanie pierwszego przeciwnika: ");
                                                    Console.WriteLine("drewno: 50, kamień: 40, złoto: 50");
                                                    drewno += 50;
                                                    kamień += 40;
                                                    złoto += 50;
                                                    dzień++;
                                                    punkty += 100;
                                                    win += 1;
                                                    Console.WriteLine("");
                                                    Console.WriteLine("Aby przejść dalej wciśnij ENTER");
                                                    System.Console.ReadKey(true);
                                                }
                                                else
                                                if (siła <= 998)
                                                {
                                                    Console.WriteLine("Niestety Twoje wojska nie dały rady w bitwie");
                                                    Console.WriteLine("Poniosłeś porażkę");
                                                    Console.WriteLine("      KONIEC GRY       ");
                                                    Console.WriteLine("");
                                                    Console.WriteLine("Aby przejść dalej wciśnij ENTER");
                                                    System.Console.ReadKey(true);
                                                    System.Environment.Exit(1);
                                                }

                                            }
                                            if (p == 2)
                                            {
                                                Console.WriteLine("Zdobądź potężniejszą armie i spróbuj ponownie");
                                                Console.WriteLine("");
                                                Console.WriteLine("Aby przejść dalej wciśnij ENTER");
                                                System.Console.ReadKey(true);
                                            }


                                            break;
                                        #endregion

                                        #region Górski trol
                                        case 2:
                                            Console.WriteLine("Górski trol");
                                            Console.WriteLine("Poziom bosa to: ");
                                            Console.WriteLine(" ");
                                            Console.WriteLine(" ");
                                            if (siła < 150)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.WriteLine("Bardzo trudny");
                                                Console.ResetColor();
                                            }
                                            else if (siła >= 150 && siła <= 211)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.WriteLine("Wyrównana walka");
                                                Console.ResetColor();
                                            }
                                            else if (siła >= 211 && siła <= 250)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                Console.WriteLine("Masz spore szanse");
                                                Console.ResetColor();
                                            }

                                            else
                                                Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Bardzo łatwy");
                                            Console.ResetColor();


                                            Console.WriteLine(" ");
                                            Console.WriteLine("Chcesz walczyć?");
                                            Console.WriteLine("1. Atakuję");
                                            Console.WriteLine("2. Wycofuję się ");

                                            #region Obsługa Wyjątków 5
                                            int a = 0; //nadanie wartosci poniewaz brak zasiegu
                                            while (true)
                                            {
                                                try
                                                {
                                                    a = int.Parse(Console.ReadLine()); // przypisanie wartosci i sprawdzenie powstania wyjatku
                                                    break; // musi byc break; poniewaz nie przechodzi dalej
                                                }
                                                catch (Exception)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Proszę wybrać odpowiednią opcję!!");
                                                    Console.ResetColor();
                                                }
                                            }
                                            #endregion

                                            if (a == 1)
                                            {
                                                if (siła > 210)
                                                {
                                                    Console.WriteLine("Gratulacje Pokonałeś Górskiego trola");
                                                    Console.WriteLine("Niestety śmierć poniosło kilka twoich jednostek");
                                                    Console.WriteLine("Zdobyłeś za pokonanie pierwszego przeciwnika: ");
                                                    Console.WriteLine("drewno: 80, kamień: 85, złoto: 90 ");
                                                    drewno += 80;
                                                    kamień += 85;
                                                    złoto += 90;
                                                    dzień++;
                                                    punkty += 200;
                                                    win++;
                                                    Console.WriteLine("");
                                                    Console.WriteLine("Aby przejść dalej wciśnij ENTER");
                                                    System.Console.ReadKey(true);
                                                }
                                                else
                                                if (siła <= 210)
                                                {
                                                    Console.WriteLine("Niestety Twoje wojska nie dały rady w bitwie");
                                                    Console.WriteLine("Poniosłeś porażkę");
                                                    Console.WriteLine("      KONIEC GRY       ");
                                                    Console.WriteLine("");
                                                    Console.WriteLine("Aby przejść dalej wciśnij ENTER");
                                                    System.Console.ReadKey(true);
                                                    System.Environment.Exit(1);
                                                }

                                            }
                                            if (a == 2)
                                            {
                                                Console.WriteLine("Zdobądź potężniejszą armie i spróbuj ponownie");
                                                Console.WriteLine("");
                                                Console.WriteLine("Aby przejść dalej wciśnij ENTER");
                                                System.Console.ReadKey(true);
                                            }
                                            break;
                                        #endregion

                                        #region Dalver Gruha'n Yercen Medvin
                                        case 3:
                                            Console.WriteLine("Dalver Gruha'n Yrcen Medvin ");
                                            Console.WriteLine("Poziom bosa to: ");
                                            Console.WriteLine(" ");
                                            Console.WriteLine(" ");
                                            if (siła < 169)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.WriteLine("Bardzo trudny");
                                                Console.ResetColor();
                                            }
                                            else if (siła >= 450 && siła <= 470)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.WriteLine("Wyrównana walka");
                                                Console.ResetColor();
                                            }
                                            else if (siła >= 450 && siła <= 500)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                Console.WriteLine("Masz spore szanse");
                                                Console.ResetColor();
                                            }

                                            else
                                                Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Bardzo łatwy");
                                            Console.ResetColor();
                                            Console.WriteLine(" ");
                                            Console.WriteLine("Chcesz walczyć?");
                                            Console.WriteLine("1. Atakuję");
                                            Console.WriteLine("2. Wycofuję się ");

                                            #region Obsługa Wyjątków 6
                                            int b = 0; //nadanie wartosci poniewaz brak zasiegu
                                            while (true)
                                            {
                                                try
                                                {
                                                    b = int.Parse(Console.ReadLine()); // przypisanie wartosci i sprawdzenie powstania wyjatku
                                                    break; // musi byc break; poniewaz nie przechodzi dalej
                                                }
                                                catch (Exception)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Proszę wybrać odpowiednią opcję!!");
                                                    Console.ResetColor();
                                                }
                                            }
                                            #endregion

                                            if (b == 1)
                                            {
                                                if (siła > 475)
                                                {
                                                    Console.WriteLine("Gratulacje Pokonałeś Dalver Gruha'n Yrcen Medvin");
                                                    Console.WriteLine("Niestety śmierć poniosło kilka twoich jednostek");
                                                    Console.WriteLine("Zdobyłeś za pokonanie pierwszego przeciwnika: ");
                                                    Console.WriteLine("drewno: 150, kamień: 120, złoto: 150 ");
                                                    drewno += 150;
                                                    kamień += 120;
                                                    złoto += 150;
                                                    dzień++;
                                                    punkty += 370;
                                                    win++;
                                                    Console.WriteLine("");
                                                    Console.WriteLine("Aby przejść dalej wciśnij ENTER");
                                                    System.Console.ReadKey(true);
                                                }
                                                else
                                                if (siła <= 475)
                                                {
                                                    Console.WriteLine("Niestety Twoje wojska nie dały rady w bitwie");
                                                    Console.WriteLine("Poniosłeś porażkę");
                                                    Console.WriteLine("      KONIEC GRY       ");
                                                    Console.WriteLine("");
                                                    Console.WriteLine("Aby przejść dalej wciśnij ENTER");
                                                    System.Console.ReadKey(true);
                                                    System.Environment.Exit(1);
                                                }

                                            }
                                            if (b == 2)
                                            {
                                                Console.WriteLine("Zdobądź potężniejszą armie i spróbuj ponownie");
                                                Console.WriteLine("");
                                                Console.WriteLine("Aby przejść dalej wciśnij ENTER");
                                                System.Console.ReadKey(true);
                                            }

                                            break;
                                        #endregion

                                        #region Czarnoksiężnik z krainy Oz

                                        case 4:

                                            Console.WriteLine("Czarnoksiężnik z krainy Ozi");
                                            Console.WriteLine("Poziom bosa to: ");
                                            Console.WriteLine(" ");
                                            Console.WriteLine(" ");
                                            if (siła < 960)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.WriteLine("Bardzo trudny");
                                                Console.ResetColor();
                                            }
                                            else if (siła >= 960 && siła <= 999)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.WriteLine("Wyrównana walka");
                                                Console.ResetColor();
                                            }
                                            else if (siła >= 1000 && siła <= 1600)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                Console.WriteLine("Masz spore szanse");
                                                Console.ResetColor();
                                            }

                                            else
                                                Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Bardzo łatwy");
                                            Console.ResetColor();
                                            Console.WriteLine(" ");
                                            Console.WriteLine("Chcesz walczyć?");
                                            Console.WriteLine("1. Atakuję");
                                            Console.WriteLine("2. Wycofuję się ");

                                            #region Obsługa Wyjątków 7
                                            int c = 0; //nadanie wartosci poniewaz brak zasiegu
                                            while (true)
                                            {
                                                try
                                                {
                                                    c = int.Parse(Console.ReadLine()); // przypisanie wartosci i sprawdzenie powstania wyjatku
                                                    break; // musi byc break; poniewaz nie przechodzi dalej
                                                }
                                                catch (Exception)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Proszę wybrać odpowiednią opcję!!");
                                                    Console.ResetColor();
                                                }
                                            }
                                            #endregion

                                            if (c == 1)
                                            {
                                                if (siła > 998)
                                                {
                                                    Console.WriteLine("Gratulacje Pokonałeś Czarnoksiężnika z krainy Oz");
                                                    Console.WriteLine("Niestety śmierć poniosło kilka twoich jednostek");
                                                    Console.WriteLine("Zdobyłeś za pokonanie pierwszego przeciwnika: ");
                                                    Console.WriteLine("drewno: 450, kamień: 330, złoto: 400 ");
                                                    drewno += 450;
                                                    kamień += 330;
                                                    złoto += 400;
                                                    dzień++;
                                                    punkty += 500;
                                                    win++;
                                                    Console.WriteLine("");
                                                    Console.WriteLine("Aby przejść dalej wciśnij ENTER");
                                                    System.Console.ReadKey(true);
                                                }
                                                else
                                                if (siła <= 998)
                                                {
                                                    Console.WriteLine("Niestety Twoje wojska nie dały rady w bitwie");
                                                    Console.WriteLine("Poniosłeś porażkę");
                                                    Console.WriteLine("      KONIEC GRY       ");
                                                    Console.WriteLine("");
                                                    Console.WriteLine("Aby przejść dalej wciśnij ENTER");
                                                    System.Console.ReadKey(true);
                                                    System.Environment.Exit(1);
                                                }

                                            }
                                            if (c == 2)
                                            {
                                                Console.WriteLine("Zdobądź potężniejszą armie i spróbuj ponownie");
                                                Console.WriteLine("");
                                                Console.WriteLine("Aby przejść dalej wciśnij ENTER");
                                                System.Console.ReadKey(true);
                                            }

                                            break;
                                        #endregion

                                        #region Falagrim von Gorazin
                                        case 5:

                                            Console.WriteLine("Falagrim von Gorazin");
                                            Console.WriteLine("Poziom bosa to: ");
                                            Console.WriteLine(" ");
                                            Console.WriteLine(" ");
                                            if (siła < 1900)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.WriteLine("Bardzo trudny");
                                                Console.ResetColor();
                                            }
                                            else if (siła >= 1900 && siła <= 2400)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.WriteLine("Wyrównana walka");
                                                Console.ResetColor();
                                            }
                                            else if (siła >= 2400 && siła <= 3800)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                                Console.WriteLine("Masz spore szanse");
                                                Console.ResetColor();
                                            }

                                            else
                                                Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("Bardzo łatwy");
                                            Console.ResetColor();
                                            Console.WriteLine(" ");
                                            Console.WriteLine("Chcesz walczyć?");
                                            Console.WriteLine("1. Atakuję");
                                            Console.WriteLine("2. Wycofuję się ");

                                            #region Obsługa Wyjątków 8
                                            int d = 0; //nadanie wartosci poniewaz brak zasiegu
                                            while (true)
                                            {
                                                try
                                                {
                                                    d = int.Parse(Console.ReadLine()); // przypisanie wartosci i sprawdzenie powstania wyjatku
                                                    break; // musi byc break; poniewaz nie przechodzi dalej
                                                }
                                                catch (Exception)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Proszę wybrać odpowiednią opcję!!");
                                                    Console.ResetColor();
                                                }
                                            }
                                            #endregion

                                            if (d == 1)
                                            {
                                                if (siła > 998)
                                                {
                                                    Console.WriteLine("Gratulacje Pokonałeś Falagrim von Gorazin");
                                                    Console.WriteLine("Niestety śmierć poniosło kilka twoich jednostek");
                                                    Console.WriteLine("Zdobyłeś za pokonanie pierwszego przeciwnika: ");
                                                    Console.WriteLine("drewno: 550, kamień: 450, złoto: 800 ");
                                                    drewno += 550;
                                                    kamień += 450;
                                                    złoto += 800;
                                                    dzień++;
                                                    punkty += 770;
                                                    win++;
                                                    Console.WriteLine("");
                                                    Console.WriteLine("Aby przejść dalej wciśnij ENTER");
                                                    System.Console.ReadKey(true);
                                                }
                                                else
                                                if (siła <= 998)
                                                {
                                                    Console.WriteLine("Niestety Twoje wojska nie dały rady w bitwie");
                                                    Console.WriteLine("Poniosłeś porażkę");
                                                    Console.WriteLine("      KONIEC GRY       ");
                                                    Console.WriteLine("");
                                                    Console.WriteLine("Aby przejść dalej wciśnij ENTER");
                                                    System.Console.ReadKey(true);
                                                    System.Environment.Exit(1);
                                                }

                                            }
                                            if (d == 2)
                                            {
                                                Console.WriteLine("Zdobądź potężniejszą armie i spróbuj ponownie");
                                                Console.WriteLine("");
                                                Console.WriteLine("Aby przejść dalej wciśnij ENTER");
                                                System.Console.ReadKey(true);
                                            }

                                            break;
                                        #endregion

                                        case 6:
                                            Console.WriteLine("Prawdopodobnie mądra decyzja, uzbieraj większą armię i spróbuj ponownie");
                                            Console.WriteLine("");
                                            Console.WriteLine("Aby przejść dalej wciśnij ENTER");
                                            System.Console.ReadKey(true);
                                            break;
                                        default:
                                            Console.WriteLine("Wybierz odpowiednią opcję");
                                            Console.WriteLine("");
                                            Console.WriteLine("Aby przejść dalej wciśnij ENTER");
                                            System.Console.ReadKey(true);
                                            break;


                                    }




                                    break;
                                #endregion

                                case 0:
                                    Console.WriteLine("Żegnaj bohaterze " + nick);
                                    Console.WriteLine("Zdobyłeś punktów: " + punkty);
                                    Console.WriteLine("");
                                    Console.WriteLine("Aby wyjść z gry wciśnij ENTER");
                                    System.Console.ReadKey(true);
                                    System.Environment.Exit(1);
                                    break;
                                default:
                                    Console.WriteLine("Proszę wybrać odpowiednią opcję");
                                    Console.WriteLine("");
                                    Console.WriteLine("Kliknij dowolny przycisk");
                                    System.Console.ReadKey(true);
                                    break;
                            }
                        }
                    #endregion

                    #endregion
                    case 2:
                        Console.WriteLine("Już wkrótce");
                        Console.WriteLine("");
                        Console.WriteLine("Aby przejść dalej wciśnij ENTER");
                        break;

                    case 3:
                        Console.WriteLine("Dawid Kaczmarek");
                        Console.WriteLine("");
                        Console.WriteLine("Aby przejść dalej wciśnij ENTER");
                        break;

                    case 4:
                        Console.WriteLine("Aby wyjść z gry wciśnij ENTER");
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Proszę wybrać odpowiednią opcję");
                        Console.WriteLine("");
                        Console.WriteLine("Aby przejść dalej wciśnij ENTER");
                        break;

                }
            }
        }
    }
}
