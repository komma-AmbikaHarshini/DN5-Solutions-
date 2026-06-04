-- Exercise 10: Feedback Gap
-- Identify events that had registrations but received no feedback at all.

SELECT DISTINCT 
    r.event_id,
    e.title AS event_title
FROM Registrations r
JOIN Events e ON r.event_id = e.event_id
WHERE r.event_id NOT IN (
    SELECT DISTINCT event_id 
    FROM Feedback
);
