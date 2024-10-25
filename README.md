# 💰 Expense Tracker - Menedżer Budżetu 'Rodzinnego'

Witaj w **Expense Tracker**! Aplikacja umożliwia zarządzanie wydatkami w ramach rodzinnych grup użytkowników. Dodawaj, śledź i rozdzielaj wydatki, zapraszaj innych do dołączenia do grupy – Expense Tracker to Twój niezawodny asystent finansowy.

## 📜 Spis Treści
- [🌟 Funkcje](#-funkcje)
- [⚙️ Wymagania Systemowe](#️-wymagania-systemowe)
- [🚀 Instalacja](#-instalacja)
- [🔧 Konfiguracja](#-konfiguracja)
- [📝 Instrukcja Użytkowania](#-instrukcja-użytkowania)

---

## 🌟 Funkcje

- **Tworzenie Rodzin** 🏠: Twórz grupy do wspólnego zarządzania wydatkami.
- **Zarządzanie Członkami** 👥: Dodawaj i usuwaj członków rodziny.
- **Autoryzacja Użytkowników** 🔑: Rejestruj się i loguj bezpiecznie.
- **Śledzenie Wydatków** 📊: Dodawaj i kategoryzuj wydatki dla rodziny.
- **Kody Zaproszeń** 📨: Generuj kod, aby zaprosić innych do swojej rodziny.

---

## ⚙️ Wymagania Systemowe

Przed instalacją upewnij się, że środowisko spełnia poniższe wymagania:

- **.NET Core SDK**: Wersja 8.0+
- **Baza Danych**: SQLite
- **System Operacyjny**: Windows, macOS lub Linux

---

## 🚀 Instalacja

Wykonaj poniższe kroki, aby zainstalować Expense Tracker na swoim komputerze.

### 1. Sklonuj repozytorium:
```bash
git clone https://github.com/szymbaramichal/expensetracker.git
cd expensetracker
```

### 2. Zainstaluj zależności:
Przejdź do katalogu projektu i przywróć zależności:
```bash
dotnet restore
```

### 3. Konfiguracja Bazy Danych:
- Skonfiguruj swoją bazę, aktualizując łańcuch połączenia w pliku `appsettings.json`.


### 4. Uruchom Migracje na bazie:
Aby skonfigurować schemat bazy danych, wykonaj:
```bash
dotnet ef database update
```

### 5. Uruchom aplikację:
```bash
dotnet run
```

---

## 🔧 Konfiguracja

### Łańcuch Połączenia z Bazą Danych
W pliku `appsettings.json` skonfiguruj połączenie z bazą danych:

```json
"ConnectionStrings": {
    "DefaultConnection": "Data source=TwojaBazaDanych.db"
}
```

### Użytkownicy Testowi
Na początek aplikacja zawiera domyślnych użytkowników testowych:
- `TestUser1` / Hasło: `TestUser1`
- `TestUser2` / Hasło: `TestUser2`
- `TestUser3` / Hasło: `TestUser3`
- `TestUser4` / Hasło: `TestUser4`

---

## 📝 Instrukcja Użytkowania

Poniższa instrukcja opisuje użytkowanie aplikacji z perspektywy użytkownika.

### 1. **Rejestracja / Logowanie**
   - Zarejestruj nowe konto lub zaloguj się na istniejące.
   - Po zalogowaniu zobaczysz główny pulpit, gdzie można przeglądać i zarządzać wydatkami.

### 2. **Tworzenie Grupy Rodzinnej**
   - Przejdź do "Utwórz Rodzinę", aby rozpocząć nową grupę wydatkową.
   - Dodaj opis, utwórz grupę i zarządzaj nią jako właściciel!

### 3. **Zapraszanie Członków**
   - W ustawieniach rodziny wygeneruj kod zaproszenia, aby zaprosić nowych członków.
   - Udostępnij ten kod, a inni mogą dołączyć do rodziny po jego wpisaniu.

### 4. **Dodawanie Wydatków**
   - Będąc częścią rodziny, wybierz "Dodaj Wydatek", aby wprowadzić nowy wydatek.
   - Dodaj opis, kwotę oraz kategorię. Wydatki można filtrować według kategorii.

### 5. **Zarządzanie Członkami**
   - Właściciele rodziny mogą zarządzać i usuwać członków według potrzeby.

### 6. **Śledzenie Salda i Długów**
   - Saldo lub dług każdego członka jest automatycznie obliczane, co ułatwia zarządzanie finansami.
