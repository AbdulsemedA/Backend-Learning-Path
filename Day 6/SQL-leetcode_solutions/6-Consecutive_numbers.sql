-- Write your MySQL query statement below
SELECT DISTINCT num as ConsecutiveNums
FROM (
    SELECT 
        num,
        LAG(num) OVER (ORDER BY id) as prev,
        LEAD(num) OVER (ORDER BY id) as next
    FROM Logs
) AS cons
WHERE num = prev AND num = next;