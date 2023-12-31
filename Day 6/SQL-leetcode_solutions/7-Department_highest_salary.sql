-- Write your MySQL query statement below
SELECT d.name AS Department, e.name AS Employee, e.salary AS Salary
FROM Employee e INNER JOIN Department d ON e.departmentId = d.id 
WHERE (e.departmentId, e.salary) IN (
  SELECT departmentId, Max(salary) FROM Employee
  GROUP BY departmentId
);