-- Exercise 22: Duplicate Registrations Check
-- Detect if a user has been registered more than once for the same event.

SELECT 
    r.user_id,
    u.full_name AS user_name,
    r.event_id,
    e.title AS event_title,
    COUNT(r.registration_id) AS registration_attempts_count
FROM Registrations r
JOIN Users u ON r.user_id = u.user_id
JOIN Events e ON r.event_id = e.event_id
GROUP BY r.user_id, u.full_name, r.event_id, e.title
HAVING COUNT(r.registration_id) > 1;
