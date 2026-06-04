-- Exercise 1: User Upcoming Events
-- Show a list of all upcoming events a user is registered for in their city, sorted by date.

SELECT 
    u.user_id,
    u.full_name AS user_name,
    u.city AS user_city,
    e.event_id,
    e.title AS event_title,
    e.start_date AS event_start_date
FROM Registrations r
JOIN Users u ON r.user_id = u.user_id
JOIN Events e ON r.event_id = e.event_id
WHERE e.status = 'upcoming' 
  AND e.city = u.city
ORDER BY e.start_date ASC;
