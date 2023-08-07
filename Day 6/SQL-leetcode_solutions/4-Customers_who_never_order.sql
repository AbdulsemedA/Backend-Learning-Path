-- Write your MySQL query statement below
SELECT name as Customers from Customers
LEFT JOIN Orders on Customers.id = Orders.customerId
WHERE Orders.id is NULL;