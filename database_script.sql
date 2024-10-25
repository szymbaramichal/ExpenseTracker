-- Podzapytanie 1: Wyciągnięcie wszystkich wydatków dla określonej kategorii z ostatniego miesiąca.
SELECT * 
FROM Expenses 
WHERE CategoryId IN (
    SELECT Id 
    FROM Categories 
    WHERE Name = 'Groceries'
) AND CreatedDateUtc >= DATE('now', '-1 month');

-- Podzapytanie 2: Znalezienie wszystkich rodzin, w których są użytkownicy o określonym ID.
SELECT * 
FROM Families 
WHERE Id IN (
    SELECT FamilyId 
    FROM UserFamilies 
    WHERE UserId = 123
);

-- Procedura 1: Automatyczna aktualizacja opisu kategorii na podstawie określonego koloru.
CREATE PROCEDURE UpdateCategoryDescription
@Color TEXT,
@NewDescription TEXT
AS
BEGIN
    UPDATE Categories
    SET Description = @NewDescription
    WHERE Color = @Color;
END;

-- Procedura 2: Generowanie raportu wydatków danej rodziny w określonym przedziale czasowym.
CREATE PROCEDURE GenerateFamilyExpenseReport
@FamilyId INT,
@StartDate TEXT,
@EndDate TEXT
AS
BEGIN
    SELECT * 
    FROM Expenses 
    WHERE FamilyId = @FamilyId 
    AND CreatedDateUtc BETWEEN @StartDate AND @EndDate;
END;

-- Funkcja: Suma wydatków dla danej rodziny.
CREATE FUNCTION GetTotalExpensesForFamily(@FamilyId INT)
RETURNS DECIMAL(10,2)
AS
BEGIN
    DECLARE @Total DECIMAL(10,2);
    SELECT @Total = SUM(Amount)
    FROM Expenses
    WHERE FamilyId = @FamilyId;
    RETURN @Total;
END;

-- Wyzwalacz: Aktualizowanie opisu rodziny po dodaniu nowego użytkownika.
CREATE TRIGGER UpdateFamilyDescriptionOnUserAdd
AFTER INSERT ON UserFamilies
FOR EACH ROW
BEGIN
    UPDATE Families
    SET Description = 'New member added!!'
    WHERE Id = NEW.FamilyId;
END;
