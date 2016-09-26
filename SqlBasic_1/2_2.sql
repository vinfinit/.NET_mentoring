SELECT ContactName, Country
FROM Customers
WHERE Country IN ('USA', 'Canada')
ORDER BY ContactName, Country;

SELECT ContactName, Country
FROM Customers
WHERE Country NOT IN ('USA', 'Canada')
ORDER BY ContactName;

SELECT DISTINCT Country
FROM Customers
ORDER BY Country DESC;