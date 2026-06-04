-- Exercise 18: Resource Availability Check
-- List all events that do not have any resources uploaded.

SELECT 
    event_id,
    title AS event_title,
    city AS event_city,
    status AS event_status
FROM Events
WHERE event_id NOT IN (
    SELECT DISTINCT event_id 
    FROM Resources
);
