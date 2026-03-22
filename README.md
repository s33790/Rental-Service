# Rental-Service-apbd

Aplikacja konsolowa w C# obsługująca uczelnianą wypożyczalnię sprzętu. System rejestruje nowych użytkowników (studenta lub pracownika) i urządzenia (laptop, projektor, kamera). Wyświetla listę wszystkich urządzeń z ich statusem, sprzętu tylko do wypożyczenia oraz wypożyczenia danego użytkownika. Przy zwrocie sprawdza czy dane urządzenie nie jest oddane po terminie. Jeśli tak - wylicza karę na podstawie liczby dni opóźnienia. Sprzęt może być także niedostępny z powodu awarii/wizyty w serwisie. Aplikacja pozwala na wygenerowanie raportu generalnego zawierającego listę użytkowników oraz urządzeń.



Projekt został rozdzielony na podfoldery:

* Models - zawierający klasy reprezentujące sprzęt oraz użytkowników.
* UI - zawierający interfejs użytkownika odpowiedzialny za komunikacje w konsoli.
* Service - zawiera całą logikę serwisową(rejestry, manager wypożyczeń, walidacje, że dane urządzenie/user istnieje).



Instrukcja uruchomienia:

0\. EXIT

1\. Dodanie nowego użytkownika.

2\. Dodanie nowego sprzętu.

3\. Wyświetlenie listy całego sprzętu z aktualnym statusem.

4\. Wyświetlenie wyłącznie sprzętu dostępnego do wypożyczenia.

5\. Wypożyczenie sprzętu użytkownikowi.

6\. Zwrot sprzętu wraz z przeliczeniem ewentualnej kary za opóźnienie.

7\. Oznaczenie sprzętu jako niedostępnego, np. z powodu uszkodzenia lub serwisu.

8\. Wyświetlenie aktywnych wypożyczeń danego użytkownika.

9\. Wyświetlenie listy przeterminowanych wypożyczeń.

10\. Wygenerowanie krótkiego raportu podsumowującego stan wypożyczalni



Dalsze kroki dla poszczególnych modułów według tego co podaje program w konsoli.

