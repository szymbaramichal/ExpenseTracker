### Wymagania Umiejętności

---

### U01: Implementacja i wdrożenie aplikacji internetowej w technologii .NET Core

Projekt został zrealizowany w technologii ASP.NET Core MVC (C#), co potwierdza znajomość nowoczesnego środowiska serwerowego .NET oraz architektury webowej. Aplikacja została wdrożona na repozytorium GitHub, wraz z przygotowanymi workflow do CI/CD (GitHub Actions). Jako bazę danych wykorzystano SQLite oraz Redis jako cache do optymalizacji wydajności.

---

### U02: Warstwa prezentacji — odpowiednik JSF w .NET Core

Warstwa prezentacji aplikacji została zaimplementowana w technologii ASP.NET Core MVC w oparciu o widoki Razor. Widoki te odpowiadają za dynamiczne generowanie treści HTML z wykorzystaniem danych przekazywanych z kontrolerów, co odpowiada roli JSF w Java EE.

---

### U03: Wykorzystanie komponentów sesyjnych, serwisów i encji

W aplikacji zastosowano Dependency Injection (wbudowany w .NET Core) do zarządzania serwisami aplikacyjnymi, odpowiedzialnymi za logikę biznesową. Dane użytkowników i wydatków przechowywane są w bazie danych z użyciem EF Core oraz encji. Redis został użyty jako komponent sesyjny/cache do przechowywania tymczasowych danych i optymalizacji operacji odczytu.

---

### U04: Praca zespołowa, analiza kodu i kontynuacja projektów

Projekt wykazuje zdolność do pracy zespołowej dzięki zastosowaniu repozytorium GitHub, pełnej historii zmian (Git), pull requestów oraz workflow CI/CD. Struktura projektu oparta o Clean Architecture ułatwia analizę kodu, jego rozwój oraz utrzymanie.

---

### U05: Integracja z zewnętrznymi systemami (odpowiednik JMS)

Aplikacja integruje się z publicznym API giełdowym (np. pobieranie kursów walut/akcji), co stanowi odpowiednik integracji aplikacji z innymi systemami (JMS w Java EE). Komunikacja odbywa się asynchronicznie poprzez wywołania REST API.

---

### U06: Stosowanie narzędzi i technologii .NET w rozwiązywaniu problemów

W projekcie zastosowano:
- ASP.NET Core MVC — struktura aplikacji
- EF Core — obsługa relacyjnej bazy danych SQLite
- Redis — cache danych
- DI — zarządzanie zależnościami
- Clean Architecture — separacja warstw
- GitHub Actions — CI/CD
- GitHub — kontrola wersji i praca zespołowa
- Tokeny JWT - autoryzacja użytkowników
- FluentValidation - walidacja zapytań do serwera pod kątem poprawności danch

Rozwiązania zostały dobrane świadomie, zgodnie z dobrymi praktykami stosowanymi w branży IT.

---

### U07: Planowanie pracy i realizacja projektu indywidualnego/z zespołem

Projekt został zaplanowany i zrealizowany indywidualnie z wykorzystaniem:
- GitHub Issues — zarządzanie zadaniami
- GitHub Projects — planowanie pracy
- Commitów z odpowiednimi opisami
- Pull requestów i code review (opcjonalnie)
Projekt osiągnął zakładane cele funkcjonalne w określonym czasie.
---


## Wymagania zgodne z sylabusem — Wiedza

### W01: Zasady działania serwera aplikacyjnego .NET Core

Projekt wykazuje znajomość działania serwera aplikacyjnego wspierającego technologię .NET Core, czyli środowiska umożliwiającego uruchamianie aplikacji webowych. ASP.NET Core działa w architekturze serwer-klient i obsługuje żądania HTTP/HTTPS, zapewniając routing, middleware, kontrolery, widoki oraz obsługę baz danych.

---

### W02: Cykl życia komponentów aplikacji ASP.NET Core

Projekt uwzględnia znajomość cyklu życia komponentów w .NET Core:
- Rejestracja serwisów w kontenerze Dependency Injection (DI)
- Czas życia serwisów (Scoped, Singleton, Transient)
- Obsługa żądań użytkowników (Request Pipeline)
- Middleware i filtry
- Przetwarzanie danych i zarządzanie sesją/cache (Redis)

---

### W03: Znajomość odpowiedników technologii EJB, JSF, JPA, JMS w .NET Core

| Java EE | Odpowiednik w .NET Core | Zastosowanie w projekcie |
|---------|-------------------------|--------------------------|
|EJB|Dependency Injection + Serwisy|Logika biznesowa w serwisach, zarządzanie wstrzykiwaniem zależności|
|JSF|ASP.NET Core MVC Razor Views|Warstwa prezentacji aplikacji (HTML + Razor)|
|JPA|Entity Framework Core|Obsługa bazy danych SQLite, mapowanie obiektowo-relacyjne|
|JMS|Integracja przez API + Redis|Komunikacja z publicznym API giełdowym + Redis jako cache |

---

### W04: Organizacja pracy indywidualnej i zespołowej

Projekt realizowany w sposób umożliwiający zarówno pracę indywidualną, jak i zespołową:
- Repozytorium GitHub
- GitFlow
- GitHub Actions (workflow CI/CD)
- Clean Architecture (czytelna struktura projektu)
- Taski i Issues w repozytorium
- Możliwość podziału pracy na moduły (np. Family, Expense, Auth)

---

## Kompetencje społeczne (K)

---

### K01: Świadomość odpowiedzialności programisty .NET Core

Autor projektu posiada świadomość roli i odpowiedzialności programisty:
- Przestrzeganie zasad bezpieczeństwa aplikacji (autoryzacja, rejestracja, walidacja danych)
- Ochrona danych użytkowników (SQLite, bezpieczna obsługa haseł)
- Praca w zespole z użyciem narzędzi kontroli wersji i code review

---

### K02: Współpraca w projekcie zespołowym ASP.NET Core

Projekt jest przygotowany w taki sposób, aby umożliwiał łatwe dołączanie kolejnych programistów:
- Dokumentacja w README
- Clean Architecture
- Jasny podział odpowiedzialności na warstwy
- CI/CD automatyzujące proces wdrożenia i testów

---

### K03: Korzystanie z różnych źródeł wiedzy

Podczas realizacji projektu wykorzystywano różne źródła wiedzy:
- Oficjalna dokumentacja Microsoft ASP.NET Core i EF Core
- Dokumentacje Redis, publicznego API giełdowego
- Artykuły techniczne i StackOverflow
- Wzorce projektowe i dobre praktyki Clean Architecture
- Kursy i tutoriale dostępne online
